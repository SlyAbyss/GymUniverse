using GymUniverse.Data.Migrations;
using GymUniverse.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GymUniverse.Data
{
    public class GymUniverseDbContext : IdentityDbContext
    {

        public GymUniverseDbContext(DbContextOptions<GymUniverseDbContext> options)
             : base(options) { }

        public DbSet<Location> Locations { get; set; } = null!;

        public DbSet<Trainer> Trainers { get; set; } = null!;

        public DbSet<Room> Rooms { get; set; } = null!;

        public DbSet<Course> Courses { get; set; } = null!;

        public DbSet<Equipment> Equipment { get; set; } = null!;

        public DbSet<RoomEquipment> RoomsEquipments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var roles = new CreateRolesConfiguration();
            builder.ApplyConfiguration<IdentityRole>(roles);

            var user = new SeedUser();
            builder.ApplyConfiguration<IdentityUser>(user);

            var admin = new SeedAdmin();
            builder.ApplyConfiguration<IdentityUserRole<string>>(admin);

            base.OnModelCreating(builder);

            builder.Entity<RoomEquipment>()
           .HasKey(re => new { re.RoomId, re.EquipmentId });

            builder.Entity<RoomEquipment>()
                .HasOne(re => re.Room)
                .WithMany(r => r.RoomsEquipments)
                .HasForeignKey(re => re.RoomId);

            builder.Entity<RoomEquipment>()
                .HasOne(re => re.Equipment)
                .WithMany(e => e.RoomEquipments)
                .HasForeignKey(re => re.EquipmentId);
        }
    }

    public class CreateRolesConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        // Seed Roles
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder
                .HasData(new IdentityRole { Id = "Administrator", Name = "Administrator", NormalizedName = "ADMINISTRATOR" });

            builder
                .HasData(new IdentityRole { Id = "User", Name = "User", NormalizedName = "USER" });
        }
    }

    public class SeedUser : IEntityTypeConfiguration<IdentityUser>
    {
        private readonly IPasswordHasher<IdentityUser?> _passwordHasher = new PasswordHasher<IdentityUser?>();

        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder
                .HasData(new IdentityUser
                {
                    Id = "b04c7301-c0c6-4a05-a8ba-8bec078cb212",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "gymadmin@gymuniverse.com",
                    NormalizedEmail = "GYMADMIN@GYMUNIVERSE.COM",
                    PasswordHash = _passwordHasher.HashPassword(null, "gym12345"),
                    SecurityStamp = "SecurityStampTest01"
                });
        }
    }

    public class SeedAdmin : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder
                .HasData(new IdentityUserRole<string>
                {
                    RoleId = "Administrator",
                    UserId = "b04c7301-c0c6-4a05-a8ba-8bec078cb212"
                });
        }
    }
}

