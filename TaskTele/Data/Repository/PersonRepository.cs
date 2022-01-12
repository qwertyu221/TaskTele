using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TaskTele.Data.Interfaces;
using TaskTele.Data.Models;

namespace TaskTele.Data.Repository
{
    public class PersonRepository : IPerson
    {
        private readonly AppDBContent appDBContent;

        public PersonRepository(AppDBContent appDBContent) {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Person> Persons => appDBContent.Person;

       

        public IEnumerable<Person> getObjPerson (int idPer) => appDBContent.Person.Where(p => p.id == idPer);
    }
}
