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
    public class PolyclinicController : ApiController
    {
        private readonly EventServiceApiContext _eventApiContext = new EventServiceApiContext();

        public IHttpActionResult Get()
        {
            var polyclinicsList = _eventApiContext.Polyclinics.ToList();

            var viewModel = polyclinicsList.Select(c => c.ConvertToViewModel());

            return Ok(viewModel);
        }

        [HttpGet]
        [Route("Api/Company/GetById")]
        [ResponseType(typeof(PolyclinicViewModel))]
        public IHttpActionResult GetById(long id)
        {
            var polyclinic = _eventApiContext.Polyclinics.FirstOrDefault(c => c.Id == id);
            if (polyclinic == null)
                return NotFound();

            var viewModel = polyclinic.ConvertToViewModel();

            return Ok(viewModel);
        }

        [ResponseType(typeof(PolyclinicViewModel))]
        public IHttpActionResult Put(long id, PolyclinicViewModel polyclinicViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var polyclinic = _eventApiContext.Polyclinics.FirstOrDefault(c => c.Id == id);
                if (polyclinic == null)
                    return Conflict();

                polyclinic.Name = polyclinicViewModel.PolyclinicName;
                polyclinic.RequiredPhoneNumber = polyclinicViewModel.RequiredPhoneNumber;
                polyclinic.AdditionalPhoneNumber = polyclinicViewModel?.AdditionalPhoneNumber;
                polyclinic.City = polyclinicViewModel?.PolyclinicCity;
                polyclinic.District = polyclinicViewModel?.PolyclinicDistrict;

                _eventApiContext.Entry(polyclinic).State = EntityState.Modified;
                _eventApiContext.SaveChanges();

                var viewModel = polyclinic.ConvertToViewModel();
                return Ok(viewModel);
            }
            catch
            {
                return InternalServerError();
            }

        }

        [ResponseType(typeof(PolyclinicViewModel))]
        public IHttpActionResult Post(PolyclinicViewModel polyclinicViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var polyclinic = _eventApiContext.Polyclinics.FirstOrDefault(c => c.Id == polyclinicViewModel.PolyclinicId);
                if (polyclinic != null)
                    return Conflict();

                polyclinic = _eventApiContext.Polyclinics.Create();

                polyclinic.Name = polyclinicViewModel.PolyclinicName;
                polyclinic.RequiredPhoneNumber = polyclinicViewModel.RequiredPhoneNumber;
                polyclinic.AdditionalPhoneNumber = polyclinicViewModel?.AdditionalPhoneNumber;
                polyclinic.City = polyclinicViewModel?.PolyclinicCity;
                polyclinic.District = polyclinicViewModel?.PolyclinicDistrict;

                _eventApiContext.Polyclinics.Add(polyclinic);
                _eventApiContext.SaveChanges();

                var viewModel = polyclinic.ConvertToViewModel();
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
            var polyclinic = _eventApiContext.Polyclinics.FirstOrDefault(c => c.Id == id);
            if (polyclinic == null)
                return NotFound();

            try
            {
                _eventApiContext.Polyclinics.Remove(polyclinic);
                _eventApiContext.SaveChanges();

                var viewModel = polyclinic.ConvertToViewModel();

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

        private bool PolyclinicExists(long id)
        {
            return _eventApiContext.Polyclinics.Count(e => e.Id == id) > 0;
        }
    }
}