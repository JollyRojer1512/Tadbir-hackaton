using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using EventServiceApi.Models;
using EventServiceApi.ViewModels;

namespace EventServiceApi.Controllers
{
    public class TransportController : ApiController
    {
        private readonly EventServiceApiContext _eventApiContext = new EventServiceApiContext();

        public IHttpActionResult Get()
        {
            var transportList = _eventApiContext.Transports.ToList();

            var viewModel = transportList.Select(c => c.ConvertToViewModel());

            return Ok(viewModel);
        }

        [HttpGet]
        [Route("Api/Company/GetById")]
        [ResponseType(typeof(TransportViewModel))]
        public IHttpActionResult GetById(long id)
        {
            var transport = _eventApiContext.Transports.FirstOrDefault(c => c.Id == id);
            if (transport == null)
                return NotFound();

            var viewModel = transport.ConvertToViewModel();

            return Ok(viewModel);
        }

        [ResponseType(typeof(TransportViewModel))]
        public IHttpActionResult Put(long id, TransportViewModel transportViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var transport = _eventApiContext.Transports.FirstOrDefault(c => c.Id == id);
                if (transport == null)
                    return Conflict();

                transport.StateNumber = transportViewModel.TransportStateNumber;
                transport.DriverFirstName = transportViewModel.DriverFirstName;
                transport.DriverLastName = transportViewModel.DriverLastName;
                transport.DriverRequiredPhoneNumber = transportViewModel.DriverRequiredPhoneNumber;
                transport.DriverAdditionalPhoneNumber = transportViewModel.DriverAdditionalPhoneNumber;
                transport.City = transportViewModel.TransportCity;
                transport.District = transportViewModel.TransportDistrict;

                _eventApiContext.Entry(transport).State = EntityState.Modified;
                _eventApiContext.SaveChanges();

                var viewModel = transport.ConvertToViewModel();
                return Ok(viewModel);
            }
            catch
            {
                return InternalServerError();
            }

        }

        [ResponseType(typeof(TransportViewModel))]
        public IHttpActionResult Post(TransportViewModel transportViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var transport = _eventApiContext.Transports.FirstOrDefault(c => c.Id == transportViewModel.TransportId);
                if (transport != null)
                    return Conflict();

                transport = _eventApiContext.Transports.Create();

                transport.StateNumber = transportViewModel.TransportStateNumber;
                transport.DriverFirstName = transportViewModel.DriverFirstName;
                transport.DriverLastName = transportViewModel.DriverLastName;
                transport.DriverRequiredPhoneNumber = transportViewModel.DriverRequiredPhoneNumber;
                transport.DriverAdditionalPhoneNumber = transportViewModel.DriverAdditionalPhoneNumber;
                transport.City = transportViewModel.TransportCity;
                transport.District = transportViewModel.TransportDistrict;

                _eventApiContext.Transports.Add(transport);
                _eventApiContext.SaveChanges();

                var viewModel = transport.ConvertToViewModel();
                return Ok(viewModel);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
            }
        }

        [ResponseType(typeof(Company))]
        public IHttpActionResult Delete(long id)
        {
            var transport = _eventApiContext.Transports.FirstOrDefault(c => c.Id == id);
            if (transport == null)
                return NotFound();

            try
            {
                _eventApiContext.Transports.Remove(transport);
                _eventApiContext.SaveChanges();

                var viewModel = transport.ConvertToViewModel();

                return Ok(viewModel);
            }
            catch
            {
                return InternalServerError();
            }
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _eventApiContext.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransportExists(long id)
        {
            return _eventApiContext.Transports.Count(e => e.Id == id) > 0;
        }
    }
}