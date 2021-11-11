using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using CrudEFCoreWithSwagger.Models;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudEFCoreWithSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly DbUnversity1Context dbUnversity1 = new DbUnversity1Context();

        public StudentsController()
        {
            dbUnversity1 = new DbUnversity1Context();
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return dbUnversity1.Students.ToList();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return dbUnversity1.Students.SingleOrDefault(temp => temp.StudentId == id);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            dbUnversity1.Students.Add(student);
            dbUnversity1.SaveChanges();
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Student student)
        {
            dbUnversity1.Students.Update(student);
            dbUnversity1.SaveChanges();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var student = dbUnversity1.Students.Find(id);
            if (student is not null)
            {
                dbUnversity1.Students.Remove(student);
                dbUnversity1.SaveChanges();
            }
        }
    }
}
