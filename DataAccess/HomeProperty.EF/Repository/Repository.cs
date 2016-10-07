using HomeProperty.DbContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HomeProperty.Repository {

    public class Repository<T> : IRepository<T> where T : class {
        private MainDbContext _context = null;
        private DbSet<T> _entity;
        public Repository() {
            _context = new MainDbContext();
            _entity = _context.Set<T>();
        }
        public Repository(MainDbContext context) {
            _context = context;
            _entity = _context.Set<T>();
        }
        public IEnumerable<T> SelectAll() {
            return _entity.ToList();
        }
        public T SelectById(Guid id) {
            return _entity.Find(id);
        }
        public void Insert(T obj) {
            _entity.Add(obj);
        }
        public void Update(T obj) {
            _entity.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(Guid id) {
            T existing = _entity.Find(id);
            _entity.Remove(existing);
        }
        public void Save() {
            _context.SaveChanges();
        }
        public DbSet<T> GetEntity() {
            return _entity;
        }
    }
}
