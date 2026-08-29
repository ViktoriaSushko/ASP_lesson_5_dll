using System;
using System.Collections.Generic;
using System.Text;

namespace CarLibrary.Services.Abstract
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T? Get(int id);
        void Add(T item);

        void Update(T item);

        void Delete(T item);
    }
}
