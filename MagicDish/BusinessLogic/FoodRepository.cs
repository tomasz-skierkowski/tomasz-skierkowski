using System;
using System.Collections.Generic;
namespace BusinessLogic
{
    public class FoodRepository
    { 

        public string Name { get; set; }
        public List<ProductQuantity> Products { get; set; }

        public FoodRepository(string name)
        {
            Products = new List<ProductQuantity>();
            Name = name;
        }

        public void AddProductToFoodRepository(Product product, int unit)
        {
            var newProduct = new ProductQuantity(product, unit);
            Products.Add(newProduct);
        }

        public List<ProductQuantity> GetProducts()
        {
            return Products;
        }
    }
}
