using Microsoft.AspNetCore.Mvc;
using Car.BusinessLogic.Contracts;
using Car.Model.ViewModel;
using AutoMapper;
using Car.Model;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _company;
       

        public CompanyController(ICompanyService company)
        {
            _company = company;
        }

        // GET: api/<CompanyController>
        [HttpGet]
        public ActionResult<IEnumerable<CompanyViewModel>> Get()
        {
            return Ok(_company.Gets());
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_company.Get(id));
        }

        // POST api/<CompanyController>
        [HttpPost]
        public IActionResult Post(CompanyViewModel companyView)
        {
            _company.Create(companyView);
            return Ok();
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, CompanyViewModel companyView)
        {
            _company.Update(id, companyView);
            return Ok();
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _company.Delete(id);
            return Ok();
        }
    }
}
