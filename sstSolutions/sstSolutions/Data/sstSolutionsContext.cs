using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sstSolutions.Models;

namespace sstSolutions.Models
{
    public class sstSolutionsContext : DbContext
    {
        public sstSolutionsContext (DbContextOptions<sstSolutionsContext> options)
            : base(options)
        {
        }

        public DbSet<sstSolutions.Models.ciudad> ciudad { get; set; }

        public DbSet<sstSolutions.Models.viaje> viaje { get; set; }
    }
}
