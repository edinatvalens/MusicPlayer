using SRBackend.Modul0_Autentifikacija.Models;
using SRBackend.Models;
using SRBackend.ModelsAutentififkacija;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace SRBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<AutentifikacijaToken> AutentificationToken { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<SongCategory> SongCategory { get; set; }
        public DbSet<Song> Song { get; set; }
        public ApplicationDbContext(
            DbContextOptions options) : base(options)
        {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
