namespace MagicDishWebApplication.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }

        public ProductCategory ProductCategory { get; set; }
    }
}
