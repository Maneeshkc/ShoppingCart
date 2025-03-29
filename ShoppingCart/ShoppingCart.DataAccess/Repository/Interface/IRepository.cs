using System.Linq.Expressions;

namespace ShoppingCart.DataAccess.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> query);
        void Add(T entity);
        void Delete(T entity);
        void DeleteRange(Expression<Func<T, bool>> query);

    }
}
