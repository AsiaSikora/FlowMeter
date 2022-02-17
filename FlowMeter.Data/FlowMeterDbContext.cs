using Microsoft.EntityFrameworkCore;
using FlowMeter.Domain;
using FlowMeter.Domain.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowMeter.Data
{
    public class FlowMeterDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Localization> Localizations { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Shape> Shapes { get; set; }
        public DbSet<Rectangle> Rectangles { get; set; }
        public DbSet<Circle> Circles { get; set; }
        public DbSet<Trapezium> Trapeziums { get; set; }
        
        public FlowMeterDbContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shape>().ToTable("Shapes");
            modelBuilder.Entity<Circle>().ToTable("Circles");
            modelBuilder.Entity<Rectangle>().ToTable("Rectangles");
            modelBuilder.Entity<Trapezium>().ToTable("Trapeziums");
        }
        
        
    }
}