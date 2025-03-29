using ShoppingCart.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        void Commit();
    }
}
