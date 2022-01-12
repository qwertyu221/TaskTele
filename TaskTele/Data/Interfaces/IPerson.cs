using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TaskTele.Data.Models;

namespace TaskTele.Data.Interfaces
{
    public interface IPerson
    {
        IEnumerable<Person> Persons { get; }

        IEnumerable<Person> getObjPerson (int idPer);



    }
}
