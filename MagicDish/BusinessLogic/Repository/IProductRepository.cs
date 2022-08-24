namespace BusinessLogic.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAsync();
    }
}