using BusinessLogic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicDishWebApplication.Models
{
    public class FoodRepositoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<ProductQuantity> Products { get; set; }
        
        
        public MagicDishWebApplicationUser MagicDishWebApplicationUser { get; set; }
    }
}
