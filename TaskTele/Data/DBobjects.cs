using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TaskTele.Data.Models;

namespace TaskTele.Data
{
    public class DBobjects
    {
        public static void Initial(AppDBContent content) {
           

            if (!content.Person.Any()) {
                content.AddRange(
                    new Person { name = "Stan Smith", age = 25, sex = true },   //male = true, female false
                    new Person { name = "Jack Anderson", age = 26, sex = true },
                    new Person { name = "Olga Popova", age = 60, sex = false },
                    new Person { name = "Erzhena Koroleva", age = 27, sex = false },
                    new Person { name = "German Titov", age = 10, sex = true }, // first
                    new Person { name = "Dmitry Vegas", age = 90, sex = true }, // last 
                    new Person { name = "Solomon Shlemovich", age = 45, sex = true },
                    new Person { name = "Alex Whitedrinker", age = 22, sex = false },
                    new Person { name = "Anna Titova", age = 37, sex = false },
                    new Person { name = "Elmo Kennedy", age = 29, sex = true },
                    new Person { name = "Sascha Braemer", age = 31, sex = true },
                    new Person { name = "Pishkun Vladislav", age = 41, sex = true },
                    new Person { name = "Jessica Braemer", age = 20, sex = false }
                    );
            }

            content.SaveChanges();
        }
    }
}
 