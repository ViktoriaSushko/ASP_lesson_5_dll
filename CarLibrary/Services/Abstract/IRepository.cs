using CarLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarLibrary.Services.Abstract
{
    public interface IRepository<T> where T : class
    {
        Task <IEnumerable<Car>> GetAll();
        Task <Car?> Get(int id);
        Task Add(T item);

        Task Update(T item);

        Task Delete(T item);
    }
}
