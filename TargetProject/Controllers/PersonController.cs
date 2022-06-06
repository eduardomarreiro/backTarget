using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TargetProject.Interfaces.IRepository;
using TargetProject.Models;

namespace TargetProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repo;
        public PersonController(IPersonRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            try
            {
                if (person == null) return NoContent();
                else
                {
                    _repo.Add(person);
                    return StatusCode(200);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error trying to add a person. Error {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetPeople()
        {
            try
            {
                var people =  _repo.GetAll();
                if (people == null) return NoContent();
                return Ok(people);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error trying to retrieve people. Error {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonById(int id)
        {
            try
            {
                var person = _repo.GetById(id);
                if (person == null) return NoContent();
                return Ok(person);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error trying to retrieve a person. Error {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeople(int id, Person person)
        {
            try
            {
                if (id == null)
                {
                    return NoContent();
                }
                else
                {
                    Person personUpdated = new Person();
                    personUpdated = _repo.GetById(id);
                    personUpdated.Phone = person.Phone;             
                    personUpdated.FullName = person.FullName;
                    personUpdated.Username = person.Username;
                    personUpdated.Born = person.Born;

                    _repo.Update(personUpdated);
                    return StatusCode(200);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error trying to update person. Error {ex.Message}");
            }
            
        }

        [HttpDelete]
        public IActionResult DeletePerson(int id)
        {
            try
            {
                var personId = _repo.GetById(id);
                if (personId == null) return NoContent();
                _repo.Delete(personId);
                return Ok("Person deleted");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error trying to delete person. Error {ex.Message}");
            }
        }
    }
}
