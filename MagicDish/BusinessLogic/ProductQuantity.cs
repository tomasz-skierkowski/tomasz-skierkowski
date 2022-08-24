namespace BusinessLogic
{
    public class ProductQuantity
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public ProductQuantity()
        {
        }
        public ProductQuantity(int id, string name, ProductCategory category, UnitOfMeasure unit, int quantity)
        {
            Product.Id = id;
            Product.Name = name;
            Product.ProductCategory = category;
            Product.UnitOfMeasure = unit;
            Quantity = quantity;
        }
        public ProductQuantity(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
