using GymUniverse.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymUniverse.Data
{
    public class GymUniverseDbContext : IdentityDbContext 
    {
        public GymUniverseDbContext(DbContextOptions<GymUniverseDbContext> options)
             : base(options)
        {
        }
        
        public DbSet<Location> Locations { get; set; } = null!;

        public DbSet<Trainer> Trainers { get; set; } = null!;

        public DbSet<Room> Rooms { get; set; } = null!;

        public DbSet<Course> Courses { get; set; } = null!;

        public DbSet<Equipment> Equipment { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
