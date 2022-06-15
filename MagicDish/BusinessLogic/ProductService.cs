using Newtonsoft.Json;

namespace BusinessLogic
{
    public class ProductService
    {
        
        public static List<Product> Products { get; set; }
        

        
        public static List<Product> GetProducts()
        {
            return Products;
        }
    }
}
