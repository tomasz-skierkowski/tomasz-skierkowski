using Newtonsoft.Json;

namespace BusinessLogic
{
    public class CookingRecipeService
    {
        public static List<CookingRecipe> Recipes { get; set; }
        


        public static List<CookingRecipe> GetCookingRecipes()
        {
            return Recipes;
        }

        public static void AddRecipe(CookingRecipe recipe)
        {
            Recipes.Add(recipe);
        }
    }
}
