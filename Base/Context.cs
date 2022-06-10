using Base.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base
{
    public class Context:DbContext
    {
        public Context(DbContextOptions options)
               : base(options)
        {

        }
        public DbSet<User> User { get; set; }
    }
}
