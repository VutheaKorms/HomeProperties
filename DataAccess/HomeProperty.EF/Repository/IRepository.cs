using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace HomeProperty.Repository {
    public interface IRepository<T> where T : class {
        IEnumerable<T> SelectAll();
        T SelectById(Guid id);
        void Insert(T obj);
        void Delete(Guid id);
        void Save();
        DbSet<T> GetEntity();
    }
}
