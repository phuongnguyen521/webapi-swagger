using Microsoft.AspNetCore.Mvc;
using MySQLWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MySQLWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private se1510Context context;
        public StudentsController()
        {
            context = new se1510Context();
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return context.Students.ToList();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return context.Students.SingleOrDefault(temp => temp.IdStudent == id);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Student student)
        {
            context.Students.Update(student);
            context.SaveChanges();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var student = context.Students.Find(id);
            if (student is not null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }
    }
}
