namespace BusinessLogic.Repository
{
    public interface IProductQuantityRepository
    {
        Task<List<ProductQuantity>> GetAsync();
    }
}