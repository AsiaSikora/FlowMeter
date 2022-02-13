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
        public DbSet<Company> Companies { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Localization> Localizations { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Shape> Shapes { get; set; } // Nie wiem czy to potrzebne, Asia zerknij.
        public DbSet<Circle> Circles { get; set; }
        public DbSet<Trapeze> Trapezes { get; set; }
        public DbSet<Rectangle> Rectangles { get; set; }


        public FlowMeterDbContext(DbContextOptions options) : base(options)
        {
        }
        
        
    }
}