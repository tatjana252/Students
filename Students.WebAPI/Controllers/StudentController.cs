using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Students.Data.UnitOfWork;
using Students.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Students.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork uow;

        public StudentController(IUnitOfWork context)
        {
            this.uow = context;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return uow.Student.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("~/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromForm] Student value, [FromHeader]int page)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
