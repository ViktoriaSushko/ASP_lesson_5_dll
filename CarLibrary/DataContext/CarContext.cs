using CarLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarLibrary.DataContext
{
    public class CarContext:DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
