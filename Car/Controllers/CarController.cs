using Car.Model;
using Car.BusinessLogic.Contracts;
using Car.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Car.BusinessLogic.Implementations;
using Car.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarService _car;
        public CarController(ICarService car)
        {
            _car = car;
        }
        // GET: api/<CarController>
        [HttpGet]
        public ActionResult <IEnumerable<CarC>> Get()
        {
            return Ok(_car.Gets());
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_car.Get(id));
        }

        // POST api/<CarController>
        [HttpPost]
        public IActionResult Post(CarViewModel carView)
        {
            _car.Create(carView);
            return Ok();
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, CarViewModel carView)
        {
            _car.Update(id, carView);
            return Ok();
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _car.Delete(id);
            return Ok();
        }
    }
}
