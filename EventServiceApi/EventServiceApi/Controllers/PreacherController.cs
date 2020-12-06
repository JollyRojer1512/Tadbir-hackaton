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
    public class PreacherController : ApiController
    {
        private readonly EventServiceApiContext _eventApiContext = new EventServiceApiContext();

        public IHttpActionResult Get()
        {
            var preachersList = _eventApiContext.Preachers.ToList();

            var viewModel = preachersList.Select(c => c.ConvertToViewModel());

            return Ok(viewModel);
        }

        [HttpGet]
        [Route("Api/Company/GetById")]
        [ResponseType(typeof(PreacherViewModel))]
        public IHttpActionResult GetById(long id)
        {
            var preacher = _eventApiContext.Preachers.FirstOrDefault(c => c.Id == id);
            if (preacher == null)
                return NotFound();

            var viewModel = preacher.ConvertToViewModel();

            return Ok(viewModel);
        }

        [ResponseType(typeof(PreacherViewModel))]
        public IHttpActionResult Put(long id, PreacherViewModel preacherViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var preacher = _eventApiContext.Preachers.FirstOrDefault(c => c.Id == id);
                if (preacher == null)
                    return Conflict();

                preacher.FirstName = preacherViewModel.PreacherFirstName;
                preacher.LastName = preacherViewModel.PreacherLastName;
                preacher.RequiredPhoneNumber = preacherViewModel.PreacherRequiredPhoneNumber;
                preacher.AdditionalPhoneNumber= preacherViewModel.PreacherAdditionalPhoneNumber;
                preacher.City = preacherViewModel.PreacherCity;
                preacher.District = preacherViewModel.PreacherDistrict;

                _eventApiContext.Entry(preacher).State = EntityState.Modified;
                _eventApiContext.SaveChanges();

                var viewModel = preacher.ConvertToViewModel();
                return Ok(viewModel);
            }
            catch
            {
                return InternalServerError();
            }

        }

        [ResponseType(typeof(PreacherViewModel))]
        public IHttpActionResult Post(PreacherViewModel preacherViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var preacher = _eventApiContext.Preachers.FirstOrDefault(c => c.Id == preacherViewModel.PreacherId);
                if (preacher != null)
                    return Conflict();

                preacher = _eventApiContext.Preachers.Create();

                preacher.FirstName = preacherViewModel.PreacherFirstName;
                preacher.LastName = preacherViewModel.PreacherLastName;
                preacher.RequiredPhoneNumber = preacherViewModel.PreacherRequiredPhoneNumber;
                preacher.AdditionalPhoneNumber = preacherViewModel.PreacherAdditionalPhoneNumber;
                preacher.City = preacherViewModel.PreacherCity;
                preacher.District = preacherViewModel.PreacherDistrict;

                _eventApiContext.Preachers.Add(preacher);
                _eventApiContext.SaveChanges();

                var viewModel = preacher.ConvertToViewModel();
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
            var preacher = _eventApiContext.Preachers.FirstOrDefault(c => c.Id == id);
            if (preacher == null)
                return NotFound();

            try
            {
                _eventApiContext.Preachers.Remove(preacher);
                _eventApiContext.SaveChanges();

                var viewModel = preacher.ConvertToViewModel();

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

        private bool PreacherExists(long id)
        {
            return _eventApiContext.Preachers.Count(e => e.Id == id) > 0;
        }
    }
}