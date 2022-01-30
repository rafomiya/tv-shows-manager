using System;
using System.Collections.Generic;

namespace shows.Models
{
    public interface IEntity<T>
    {
        void Create(T entity);
        List<T> Read();
        T Read(Guid id);
        void Update(T entity);
        void Delete(Guid id);
    }
}