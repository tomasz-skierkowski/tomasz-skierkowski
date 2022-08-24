using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        static List<Recipe> _recipes = new List<Recipe>
        {
            new Recipe
            {
                Id = 1,
                Name = "cheese tostie",
                IsVegeterian = true,
                Ingredients = new List<ProductQuantity>
                {
                    new ProductQuantity(new Product(4, "bread", ProductCategory.starch, UnitOfMeasure.pieces), 2),
                    new ProductQuantity(new Product(5, "cheese", ProductCategory.dairy, UnitOfMeasure.grams), 100)
                },
                Description = "put cheese inside bread, warm up",
                CookingTimeInMinutes = 10
            }
        };

        public Task<List<Recipe>> GetAsync()
        {
            return Task.FromResult<List<Recipe>>(_recipes);
        }
    }
}