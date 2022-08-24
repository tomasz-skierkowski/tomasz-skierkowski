namespace BusinessLogic.Repository
{
    public interface IRecipeRepository
    {
        Task<List<Recipe>> GetAsync();
    }
}