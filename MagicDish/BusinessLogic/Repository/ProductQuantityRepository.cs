using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    public class ProductQuantityRepository : IProductQuantityRepository
    {
        static List<ProductQuantity> _productsQuantity = new List<ProductQuantity>
        {
            new ProductQuantity(new Product(1, "pasta", ProductCategory.starch, UnitOfMeasure.grams), 200),
            new ProductQuantity(new Product(2,"tomato", ProductCategory.vegetable, UnitOfMeasure.pieces), 8),
            new ProductQuantity(new Product(3,"minced meat", ProductCategory.meat ,UnitOfMeasure.grams), 500),
        };
        public Task<List<ProductQuantity>> GetAsync()
        {
            return Task.FromResult<List<ProductQuantity>>(_productsQuantity);
        }
        
        //TODO: get by id method
        
    }
}