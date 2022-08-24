using BusinessLogic;

namespace MagicDishWebApplication.Models
{
    public class ProductQuantityModel
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
