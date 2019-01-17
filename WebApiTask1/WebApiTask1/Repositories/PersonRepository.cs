using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using WebApiTask1.Models;

namespace WebApiTask1.Repositories
{
    public class PersonRepository : IPersonRepository
    {

        private readonly PersondbContext _context;

        public PersonRepository(PersondbContext context)
        {
            _context = context;

        }


        public Person Create(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
            return person;
        }

        public List<Person> Read()
        {
            return _context.Person
                .Include(p=>p.Phone)
                .ToList();
        }

        public Person Read(int id)
        {
            return _context.Person
                .Include(p=>p.Phone)
                .FirstOrDefault(p => p.Id == id);
        }

        public Person Update(int id, Person person)
        {
            _context.Update(person);
            _context.SaveChanges();
            return person;
        }

        public void Delete(int id)
        {
            var person = Read(id);
            _context.Person.Remove(person);
            _context.SaveChanges();
            return;
        }
    }
}
