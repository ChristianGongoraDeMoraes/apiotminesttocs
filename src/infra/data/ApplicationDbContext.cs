using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiotminesttocs.src.domain.pessoa.models;
using apiotminesttocs.src.domain.recados.models;
using Microsoft.EntityFrameworkCore;

namespace apiotminesttocs.src.infra.data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {}

        public DbSet<Recado> Recados { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pessoa>()
                .HasIndex(p => p.Email)
                .IsUnique();

            builder.Entity<Recado>()
                .HasOne<Pessoa>(r => r.Sender)
                .WithMany() 
                .HasForeignKey(r => r.SenderId)
                .OnDelete(DeleteBehavior.NoAction); 

            builder.Entity<Recado>()
                .HasOne<Pessoa>(r => r.Receiver)
                .WithMany() 
                .HasForeignKey(r => r.ReceiverId)
                .OnDelete(DeleteBehavior.NoAction);


            base.OnModelCreating(builder);
        }
    }
}