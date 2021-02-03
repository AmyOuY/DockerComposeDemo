using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
    }
}
