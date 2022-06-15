namespace BusinessLogic
{
    public class FindCookingRecipe
    {

        public static List<CookingRecipe> FindCookingRecipie(List<CookingRecipe> recipes, List<ProductQuantity> foodRepoProducts)
        {
            List<CookingRecipe> filteredRecipies;
            filteredRecipies = recipes.Where(recipe => recipe.Ingredients.All(ingredient => foodRepoProducts.Any(x => x.Product.Id == ingredient.Product.Id))).ToList();
            

            return filteredRecipies;
        }
    }
}
