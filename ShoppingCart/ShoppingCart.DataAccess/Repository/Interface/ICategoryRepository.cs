using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Models;

namespace ShoppingCart.DataAccess.Repository.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}
