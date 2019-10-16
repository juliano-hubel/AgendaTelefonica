using AgendaTelefonica.Domain.Entities;
using AgendaTelefonica.Infra.Mapping;
using AgendaTelefonica.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaTelefonica.Infra.Context.DataContext
{
    public class AgendaTelefonicaDataContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactMap());
        }
    }
}
