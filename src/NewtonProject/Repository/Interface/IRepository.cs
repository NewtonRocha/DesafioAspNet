using System.Collections.Generic;

namespace NewtonProject.Repository
{
    public interface IRepository<T>
    {
        T Add(T item);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllById(int id); 
        T Find(int id);
        T Remove(int id);
        void Update(T item);
    }
}
