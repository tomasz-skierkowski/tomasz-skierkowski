namespace BusinessLogic
{
    using System.Collections.Generic;

    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductQuantity> Ingredients { get; set; }

        public int CookingTimeInMinutes { get; set; }

        public bool IsVegeterian { get; set; }

        public string Description { get; set; }
    }
}
