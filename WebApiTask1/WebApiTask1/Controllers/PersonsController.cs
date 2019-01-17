using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiTask1.Models;
using WebApiTask1.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiTask1.Controllers
{
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public PersonsController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult <List<Person>> Get()
        {
            return _personRepository.Read();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult <List<Person>> Get(int id)
        {
            var persons = _personRepository.Read(id);
            return new JsonResult(persons);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<Person> Post(Person person)
        {
            var newPerson = _personRepository.Create(person);
            return new JsonResult(newPerson);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult<Person> Put(int id, [FromBody] Person person)
        {
            Person updatedPerson = _personRepository.Update(id, person);
            return new JsonResult(updatedPerson);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _personRepository.Delete(id);
            return new OkResult();
        }
    }
}
