using ShoppingCart.DataAccess.Repository.Interface;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DataAccess.Repository.Implimentation
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ShoppingCartContext _shoppingCartContext;
        public CategoryRepository(ShoppingCartContext context) : base(context)
        {
            _shoppingCartContext = context;
        }

        public void Update(Category category)
        {
            _shoppingCartContext.Update(category);
        }
    }
}
