using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using EventApi.Models;
using EventApi.ViewModels;
using EventServiceApi.Models;

namespace EventServiceApi.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly EventServiceApiContext _eventApiContext = new EventServiceApiContext();

        // GET: api/Company
        public IHttpActionResult Get()
        {
            var companiesList = _eventApiContext.Companies.ToList();

            var viewModel = companiesList.Select(c => c.ConvertToViewModel());

            return Ok(viewModel);
        }

        // GET: api/Company/5
        [HttpGet]
        [Route("Api/Company/GetById")]
        [ResponseType(typeof(CompanyViewModel))]
        public IHttpActionResult GetById(long id)
        {
            var company = _eventApiContext.Companies.FirstOrDefault(c => c.Id == id);
            if (company == null)
                return NotFound();

            var viewModel = company.ConvertToViewModel();

            return Ok(viewModel);
        }

        [HttpGet]
        [Route("Api/Company/GetByInn")]
        [ResponseType(typeof(CompanyViewModel))]
        public IHttpActionResult GetByInn(string inn)
        {
            var company = _eventApiContext.Companies.FirstOrDefault(c => c.Inn == inn);
            if (company == null)
                return NotFound();

            var viewModel = company.ConvertToViewModel();

            return Ok(viewModel);
        }

        // PUT: api/Company/5
        [ResponseType(typeof(CompanyViewModel))]
        public IHttpActionResult Put(long id, CompanyViewModel companyViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var company = _eventApiContext.Companies.FirstOrDefault(c => c.Id == id);
                if (company == null)
                    return Conflict();

                company.Inn = companyViewModel.CompanyInn;
                company.Name = companyViewModel.CompanyName;
                company.Phone = companyViewModel.CompanyPhone;
                company.Email = companyViewModel?.CompanyEmail;
                company.Website = companyViewModel?.CompanyWebsite;

                _eventApiContext.Entry(company).State = EntityState.Modified;
                _eventApiContext.SaveChanges();

                var viewModel = company.ConvertToViewModel();
                return Ok(viewModel);
            }
            catch
            {
                return InternalServerError();
            }

        }

        // POST: api/Company
        [ResponseType(typeof(CompanyViewModel))]
        public IHttpActionResult Post(CompanyViewModel companyViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var company = _eventApiContext.Companies.FirstOrDefault(c => c.Inn == companyViewModel.CompanyInn);
                if (company != null)
                    return Conflict();

                company = _eventApiContext.Companies.Create();

                company.Inn = companyViewModel.CompanyInn;
                company.Name = companyViewModel.CompanyName;
                company.Phone = companyViewModel.CompanyPhone;
                company.Email = companyViewModel.CompanyEmail;
                company.Website = companyViewModel.CompanyWebsite;

                _eventApiContext.Companies.Add(company);
                _eventApiContext.SaveChanges();

                var viewModel = company.ConvertToViewModel();
                return Ok(viewModel);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
            }
        }

        // DELETE: api/Company/5
        [ResponseType(typeof(Company))]
        public IHttpActionResult Delete(long id)
        {
            var company = _eventApiContext.Companies.FirstOrDefault(c => c.Id == id);
            if (company == null)
                return NotFound();

            try
            {
                _eventApiContext.Companies.Remove(company);
                _eventApiContext.SaveChanges();

                var viewModel = company.ConvertToViewModel();

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

        private bool CompanyExists(long id)
        {
            return _eventApiContext.Companies.Count(e => e.Id == id) > 0;
        }
    }
}