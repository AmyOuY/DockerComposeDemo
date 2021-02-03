using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController
    {
        private readonly PeopleContext _db;

        public PeopleController(PeopleContext db)
        {
            _db = db;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var people = await _db.People.ToListAsync();

            return new JsonResult(people);
        }
               
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var person = await _db.People.FirstOrDefaultAsync(p => p.Id == id);

            return new JsonResult(person);
        }


        [HttpPost]
        public async Task<IActionResult> Post(Person person)
        {
            _db.People.Add(person);
            await _db.SaveChangesAsync();

            return new JsonResult(person.Id);
        }


        [HttpPut]
        public async Task<IActionResult> Put(int id, Person person)
        {
            var existingPerson = await _db.People.FirstOrDefaultAsync(p => p.Id == id);
            existingPerson.FirstName = person.FirstName;
            existingPerson.LastName = person.LastName;
            existingPerson.Email = person.Email;
            existingPerson.Phone = person.Phone;
            var success = (await _db.SaveChangesAsync()) > 0;

            return new JsonResult(success);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await _db.People.FirstOrDefaultAsync(p => p.Id == id);
            _db.Remove(person);
            var success = (await _db.SaveChangesAsync()) > 0;

            return new JsonResult(success);
        }
    }
}
