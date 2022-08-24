namespace BusinessLogic
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public Product()
        {
        }
        public Product(int id, string name, ProductCategory productCategory, UnitOfMeasure unitOfMeasure)
        {
            Id = id;
            Name = name;
            UnitOfMeasure = unitOfMeasure;
            ProductCategory = productCategory;
        }
    }
}
