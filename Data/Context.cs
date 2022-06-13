using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
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
