using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;

namespace ShoppingCart.DataAccess
{
    public class ShoppingCartContext : DbContext
    {
        #region Constructor
        public ShoppingCartContext(DbContextOptions options) : base(options)
        {

        }

        #endregion

        #region Dbsets
        public DbSet<Category> Categories { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var data=new List<Category>();
            data.Add(new Category() { Id = 1, Name = "Horrow", DisplayOrder = 1 });
            data.Add(new Category() { Id = 2, Name = "Comedy", DisplayOrder = 2 });
            data.Add(new Category() { Id = 3, Name = "Science Fiction", DisplayOrder = 3 });
            data.Add(new Category() { Id = 4, Name = "Adult", DisplayOrder = 4 });
            data.Add(new Category() { Id = 5, Name = "Romance", DisplayOrder = 5 });

            modelBuilder.Entity<Category>().HasData(data);
        }

    }
}
