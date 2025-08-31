using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiotminesttocs.src.domain.recados.models;
using Microsoft.EntityFrameworkCore;

namespace apiotminesttocs.src.infra.data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }

        public DbSet<Recado> Recados { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }
    }
}