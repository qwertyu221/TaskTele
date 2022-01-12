using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TaskTele.Data.Models;

namespace TaskTele.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent (DbContextOptions<AppDBContent> options) : base(options) {

        }

        public DbSet<Person> Person { get; set; }

    }
}
