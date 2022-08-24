using Newtonsoft.Json;

namespace BusinessLogic
{
    public class RecipeService
    {
        public static List<Recipe> Recipes {
            get { return new List<Recipe>(); }
            set
            {
                var recipesContent = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Recipes.json"));
                RecipeService.Recipes = JsonConvert.DeserializeObject<List<Recipe>>(recipesContent);
            } 
        }


        public static List<Recipe> GetCookingRecipes()
        {
            return Recipes;
        }

        public static void AddUser(Recipe recipe)
        {
            Recipes.Add(recipe);
        }
    }
}
