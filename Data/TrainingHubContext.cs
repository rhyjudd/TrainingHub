using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TrainingHub.Models
{
    public class TrainingHubContext : DbContext
    {
        public TrainingHubContext (DbContextOptions<TrainingHubContext> options)
            : base(options)
        {
        }

        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Training> Trainings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Technician>().ToTable("Technician");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Training>().ToTable("Training");
        }

        public DbSet<TrainingHub.Models.Technician> Technician { get; set; }
    }
}
