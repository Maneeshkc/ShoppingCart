using ShoppingCart.DataAccess.Repository.Implimentation;
using ShoppingCart.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoppingCartContext _shoppingCartContext;
        public UnitOfWork(ShoppingCartContext context)
        {
            _shoppingCartContext = context;
            Category=new CategoryRepository(context);
        }
        public ICategoryRepository Category { get ; private set ; }

        public void Commit()
        {
            _shoppingCartContext.SaveChanges();
        }
    }
}
