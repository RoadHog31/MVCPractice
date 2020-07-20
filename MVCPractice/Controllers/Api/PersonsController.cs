using MVCPractice.Data;
using MVCPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCPractice.Controllers.Api
{
    public class PersonsController : ApiController
    {

        private ApplicationDbContext _context;

        public PersonsController()
        {
            _context = new ApplicationDbContext();
        }

        //Get /api/persons
        public IEnumerable<Person> GetPersons() {

          return  _context.Persons.ToList();
        }

        //Get /api/person/1
        public Person GetPerson(int id)
        {
            var person = _context.Persons.SingleOrDefault(p => p.Id == id);

            if (person == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return person;
        } 

        //Post /api/persons
        [HttpPost]
        public Person CreatePerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _context.Persons.Add(person);
            _context.SaveChanges();

            return person;
        }

        //PUT /api/persons/1
        [HttpPut]
        public void UpdatePerson(int Id, Person person)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);               
            }

            var personInDb = _context.Persons.SingleOrDefault(p => p.Id == Id);

            if (personInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            //TO DO: Use AutoMapper here to map these...
            personInDb.FirstName = person.FirstName;
            personInDb.LastName = person.LastName;
            personInDb.Age = person.Age;
            personInDb.IsActive = person.IsActive;

            _context.SaveChanges();
        }

        //Delete /api/person/1
        [HttpDelete]
        public void DeletePerson(int Id)
        {
            var personInDb = _context.Persons.SingleOrDefault(p => p.Id == Id);

            if (personInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.Persons.Remove(personInDb);
            _context.SaveChanges();
        }
    }
}
