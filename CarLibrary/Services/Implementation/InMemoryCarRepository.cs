using CarLibrary.Models;
using CarLibrary.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarLibrary.Services.Implementation
{
    public class InMemoryCarRepository : IRepository<Car>
    {
        IList<Car> cars = default!;
        public InMemoryCarRepository()
        {
            cars = new List<Car>()
            {
                new Car { Id = 1, Manufacturer = "Ford", Model = "Focus 3", Price = 9000, Year = 2009},
                new Car { Id = 2, Manufacturer = "Volkswagen", Model = "Jetta", Price = 10000, Year = 2015},
                new Car{ Id = 3, Manufacturer = "Audi", Model = "R8", Price = 200000, Year = 2023}
            };
        }

        public void Add(Car item)
        {
            int id = cars.Max(t => t.Id);
            item.Id = ++id;
            cars.Add(item);
        }

        public void Delete(Car item)
        {
            Car? deleteCar = cars.FirstOrDefault(t => t.Id == item.Id);
            if (deleteCar != null)
                cars.Remove(deleteCar);
        }

        public Car? Get(int id)
        {
            return cars.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Car> GetAll()
        {
            return cars;
        }

        public void Update(Car item)
        {
            Car? editCar = cars.FirstOrDefault(t => t.Id == item.Id);
            if (editCar != null)
            {
                editCar.Manufacturer = item.Manufacturer;
                editCar.Model = item.Model;
                editCar.Price = item.Price;
                editCar.Year = item.Year;

            }
        }
    }
}
