using Microsoft.EntityFrameworkCore;
using ShoppingCart.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DataAccess.Repository.Implimentation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ShoppingCartContext _context;
        private DbSet<T> _dbSet;
        public Repository(ShoppingCartContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(Expression<Func<T, bool>> query)
        {
            var itemsToRemove=_dbSet.Where(query).ToList();
            _dbSet.RemoveRange(itemsToRemove);
        }

        public T Get(Expression<Func<T, bool>> query)
        {
           return _dbSet.Where(query).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
           return _dbSet.ToList();
        }
    }
}
