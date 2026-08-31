using CarLibrary.DataContext;
using CarLibrary.Models;
using CarLibrary.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarLibrary.Services.Implementation
{
    public class EFCarRepository : IRepository<Car>
    {
        protected readonly CarContext context;
        public EFCarRepository(CarContext context)
        {
            this.context = context;
        }
        public async Task Add(Car item)
        {
            await context.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Car item)
        {
            Car? delCar = await context.Cars.FindAsync(item.Id);
            if (delCar != null)
            {
                context.Cars.Remove(delCar);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Car?> Get(int id)
        {
            return await context.Cars.FindAsync(id);
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await context.Cars.ToListAsync();
        }

        public async Task Update(Car item)
        {
            Car? editCar = await context.Cars.FindAsync(item.Id);
            if (editCar != null)
            {
                editCar.Manufacturer = item.Manufacturer;
                editCar.Model = item.Model;
                editCar.Year = item.Year;
                editCar.Price = item.Price;
                editCar.Image = item.Image;
                await context.SaveChangesAsync();
            }
        }
    }
}
