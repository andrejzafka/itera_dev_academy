using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GarbageCollectorExample
{
    public class PostsContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // configure database connection to SQL server
            optionsBuilder
                .UseSqlServer(@"Server=.\SQLEXPRESS; Database=AsyncExample; Trusted_Connection=True;");
        }
    }
}
