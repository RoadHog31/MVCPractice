using AutoMapper;
using MVCPractice.Data;
using MVCPractice.Dtos;
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
        public IEnumerable<PersonDto> GetPersons() {

          return  _context.Persons.ToList().Select(Mapper.Map<Person, PersonDto>);
        }

        //Get /api/person/1
        public PersonDto GetPerson(int id)
        {
            var person = _context.Persons.SingleOrDefault(p => p.Id == id);

            if (person == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Mapper.Map<Person, PersonDto>(person);
        } 

        //Post /api/persons
        //TODO finish api section- Mosh
        [HttpPost]
        public PersonDto CreatePerson(PersonDto persondto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }          

            var person = Mapper.Map<PersonDto, Person>(persondto);
            _context.Persons.Add(person);
            _context.SaveChanges();

            persondto.Id = person.Id;

            return persondto;
        }

        //PUT /api/persons/1
        [HttpPut]
        public void UpdatePerson(int Id, PersonDto persondto)
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

            Mapper.Map(persondto, personInDb);        

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
