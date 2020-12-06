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
    public class CemeteryController : ApiController
    {
        private readonly EventServiceApiContext _eventApiContext = new EventServiceApiContext();

        public IHttpActionResult Get()
        {
            var cemeteriesList = _eventApiContext.Cemeteries.ToList();

            var viewModel = cemeteriesList.Select(c => c.ConvertToViewModel());

            return Ok(viewModel);
        }

        [HttpGet]
        [Route("Api/Company/GetById")]
        [ResponseType(typeof(CemeteryViewModel))]
        public IHttpActionResult GetById(long id)
        {
            var cemetery = _eventApiContext.Cemeteries.FirstOrDefault(c => c.Id == id);
            if (cemetery == null)
                return NotFound();

            var viewModel = cemetery.ConvertToViewModel();

            return Ok(viewModel);
        }

        [ResponseType(typeof(CemeteryViewModel))]
        public IHttpActionResult Put(long id, CemeteryViewModel cemeteryViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var cemetery = _eventApiContext.Cemeteries.FirstOrDefault(c => c.Id == id);
                if (cemetery == null)
                    return Conflict();

                cemetery.Name = cemeteryViewModel.CemeteryName;
                cemetery.RequiredPhoneNumber = cemeteryViewModel.CemeteryRequiredPhoneNumber;
                cemetery.AdditionalPhoneNumber = cemeteryViewModel.CemeteryAdditionalPhoneNumber;
                cemetery.City = cemeteryViewModel.CemeteryCity;
                cemetery.District = cemeteryViewModel.CemeteryDistrict;

                _eventApiContext.Entry(cemetery).State = EntityState.Modified;
                _eventApiContext.SaveChanges();

                var viewModel = cemetery.ConvertToViewModel();
                return Ok(viewModel);
            }
            catch
            {
                return InternalServerError();
            }

        }

        [ResponseType(typeof(CemeteryViewModel))]
        public IHttpActionResult Post(CemeteryViewModel cemeteryViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var cemetery = _eventApiContext.Cemeteries.FirstOrDefault(c => c.Id == cemeteryViewModel.CemeteryId);
                if (cemetery != null)
                    return Conflict();

                cemetery = _eventApiContext.Cemeteries.Create();

                cemetery.Name = cemeteryViewModel.CemeteryName;
                cemetery.RequiredPhoneNumber = cemeteryViewModel.CemeteryRequiredPhoneNumber;
                cemetery.AdditionalPhoneNumber = cemeteryViewModel.CemeteryAdditionalPhoneNumber;
                cemetery.City = cemeteryViewModel.CemeteryCity;
                cemetery.District = cemeteryViewModel.CemeteryDistrict;

                _eventApiContext.Cemeteries.Add(cemetery);
                _eventApiContext.SaveChanges();

                var viewModel = cemetery.ConvertToViewModel();
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
            var cemetery = _eventApiContext.Cemeteries.FirstOrDefault(c => c.Id == id);
            if (cemetery == null)
                return NotFound();

            try
            {
                _eventApiContext.Cemeteries.Remove(cemetery);
                _eventApiContext.SaveChanges();

                var viewModel = cemetery.ConvertToViewModel();

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

        private bool CemeteryExists(long id)
        {
            return _eventApiContext.Cemeteries.Count(e => e.Id == id) > 0;
        }
    }
}