namespace BusinessLogic
{
    public class CookingRecipe
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductQuantity> Ingredients { get; set; }

        public int CookingTimeInMinutes { get; set; }

        public bool IsVegeterian { get; set; }

        public string Description { get; set; }

        public CookingRecipe (int id, string name, int cookingTimeInMinutes, bool isVegetarian, List<ProductQuantity> ingredients, string description)
        {
            Id = id;
            Name = name;
            Ingredients = ingredients;
            CookingTimeInMinutes = cookingTimeInMinutes;
            IsVegeterian = isVegetarian;
            Description = description;
        }
    }
}
