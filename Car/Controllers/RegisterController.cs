using Car.Model;
using Car.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public RegisterController(ApplicationContext context)
        {
            _context = context;
        }

        // POST api/<ValuesController>
        [HttpPost("rester")]
        public async Task <ActionResult<Person>> Register(RegisterView resterView)
        {
            if (await PersonExists(resterView.Name)) 
            {
                return BadRequest("Name Is Already Taken");
            }
            var hmac = new HMACSHA512();

            var person = new Person
            {
                Name = resterView.Name.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(resterView.Password)),
                PasswordSalt = hmac.Key,
            };

            _context.People.Add(person);
            await _context.SaveChangesAsync();
            return Ok(person);
        }

        private async Task<bool>PersonExists(string name)
        {
            return await _context.People.AnyAsync(x => x.Name == name.ToLower());
        }

        [HttpPost("login")]
        public async Task<ActionResult<Person>> Login(LoginView loginView)
        {
            var person = await _context.People
                .SingleOrDefaultAsync(x => x.Name == loginView.Name);

            if (person == null) return Unauthorized("Invalid UserName");

            var hmac = new HMACSHA512(person.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginView.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != person.PasswordHash[i]) return Unauthorized("Invalid Password");
            }

            return person;
        }
    }
}
