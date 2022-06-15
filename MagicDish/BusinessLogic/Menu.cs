using System;
using Newtonsoft.Json;
using System.Reflection;

namespace BusinessLogic
{
    public class Menu
    {


        public static void WelcomeMenu()
        {
            Console.WriteLine("Welcome to your food-repository!");
            Console.WriteLine("Are you an existing user or would you like to register?");
            Console.WriteLine("1 - I'm a registered user");
            Console.WriteLine("2 - I'd like to register for the first time");
            int option = CollectInputAsValidOption(2);
            switch (option)
            {
                case 1:
                    SignInMenu();
                    break;
                case 2:
                    SignUpMenu();
                    break;
            }
        }

        private static void SignInMenu()
        {
            UserAccount user = new UserAccount();
            var usersList = new List<UserAccount>();
            string dataDirectoryPath = Directory.GetCurrentDirectory();
            string usersDataDirectoryPath = Path.Combine(dataDirectoryPath, "Users");
            string usersDataFilePath = Path.Combine(usersDataDirectoryPath, "Users.json");

            while (!Directory.Exists(usersDataDirectoryPath))
            {
                Directory.CreateDirectory(usersDataDirectoryPath);
                Directory.Exists(usersDataDirectoryPath);
            }
            var isUsersListCreated = File.Exists(usersDataFilePath);

            if (!isUsersListCreated)
            {
                Console.WriteLine("You are not registered user");
                var usersData = JsonConvert.SerializeObject(usersList, Formatting.Indented);
                File.WriteAllText(Path.Combine(usersDataDirectoryPath, "Users.json"), usersData);
                SignUpMenu();
            }
            else
            {
                var usersFileContent = File.ReadAllText(usersDataFilePath);
                usersList = JsonConvert.DeserializeObject<List<UserAccount>>(usersFileContent);
                Console.WriteLine("Hello, please tell me your username");
                user.Username = CollectStringInput("username");
                var usernames = usersList.Select(u => u.Username);
                while
                    (!usernames.Contains(user.Username))
                {
                    Console.WriteLine("Invalid username. Please enter username again:");
                    user.Username = CollectStringInput("username");
                }

                Console.WriteLine("Hello, please tell me your password");
                user.Password = CollectStringInput("password");
                var getUserNames = usersList.Where(u => u.Username == user.Username).ToList();
                var selectedUser = getUserNames.Where(u => u.Password == user.Password).ToList();
                while (selectedUser.Count == 0)
                {
                    Console.WriteLine("Your password does not match. Please retype the password:");
                    user.Password = CollectStringInput("password");
                    selectedUser = usersList.Where(u => u.Password == user.Password).ToList();
                }

                var getRepoName = selectedUser.Select(o => o.FoodRepository.Name.ToString());
                var repoName = getRepoName.First();
                string repoFileName = repoName + ".json";
                string reposDataDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Repos");
                string reposDataFilePath = Path.Combine(reposDataDirectoryPath, repoFileName);
                var reposFileContent = File.ReadAllText(reposDataFilePath);
                var repoList = JsonConvert.DeserializeObject<FoodRepository>(reposFileContent);
                Console.Clear();
                Console.WriteLine($"You are succesfully logged in.");
                FoodRepositoryMenu(repoList);
            }
        }

        private static void SignUpMenu()
        {
            UserAccount user = new UserAccount();
            var usersList = new List<UserAccount>();
            string usersDataDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Users");
            string usersDataFilePath = Path.Combine(usersDataDirectoryPath, "Users.json");
            while (!Directory.Exists(usersDataDirectoryPath))
            {
                Directory.CreateDirectory(usersDataDirectoryPath);
                Directory.Exists(usersDataDirectoryPath);
            }
            var isUsersListCreated = File.Exists(usersDataFilePath);
            if (!isUsersListCreated)
            {
                var usersData = JsonConvert.SerializeObject(usersList, Formatting.Indented);
                File.WriteAllText(Path.Combine(usersDataDirectoryPath, "Users.json"), usersData);
                SignUpMenu();
            }
            else
            {
                var fileContent = File.ReadAllText(usersDataFilePath);
                usersList = JsonConvert.DeserializeObject<List<UserAccount>>(fileContent);

                if
                    (usersList.Count() == 0)
                {
                    user.Id = 0;
                }
                else
                {
                    user.Id = usersList.Count();
                }
                Console.WriteLine("First things first. What is your name?");
                user.Name = CollectStringInput("name");
                Console.WriteLine("Now enter your username");
                user.Username = CollectStringInput("username");
                var usernames = usersList.Select(u => u.Username);
                while (usernames.Contains(user.Username))
                {
                    Console.WriteLine("username already taken, please chose different username:");
                    user.Username = CollectStringInput("username");
                }
                Console.WriteLine("Create a password");
                user.Password = CollectStringInput("password");
                Console.WriteLine("What is your email?");
                user.Email = CollectEmailInput();
                Console.WriteLine($"Nice to meet you {user.Name}");
                Console.WriteLine("Let's create your first food-repository");
                Console.WriteLine("How would you like to name your food-repository?");
                user.FoodRepository = new FoodRepository(CollectStringInput("food-repository"));
                Console.WriteLine($"Now, add first product to your {user.FoodRepository.Name}");
                usersList.Add(user);
                
                AvailableProductsMenu(user.FoodRepository);
                SaveUsersListData(usersList);
                SaveFoodRepoData(user.FoodRepository);
                //Environment.Exit(0);  ???
            }
        }

        private static void FoodRepositoryMenu(FoodRepository foodRepository)
        {
            Console.Clear();
            string repoFileName = foodRepository.Name + ".json";
            string reposDataDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Repos");
            string reposDataFilePath = Path.Combine(reposDataDirectoryPath, repoFileName);
            var reposFileContent = File.ReadAllText(reposDataFilePath);
            var repoList = JsonConvert.DeserializeObject<FoodRepository>(reposFileContent);
            Console.WriteLine($"You're in {foodRepository.Name}.");
            Console.WriteLine();
            Console.WriteLine("Products available:");
            int i = 1;
            foreach (var product in foodRepository.Products)
            {
                Console.WriteLine($"Product number {i}:    {product.Quantity} [{product.Product.UnitOfMeasure}] of {product.Product.Name}");
                i++;
            }
            Console.WriteLine();
            Console.WriteLine("What would you like to do from here?");
            Console.WriteLine($"1 - Add more products to {foodRepository.Name}");
            Console.WriteLine("2 - Edit available products");
            Console.WriteLine("3 - Remove product from the repo");
            Console.WriteLine("4 - Search for a recipe based on food you have in your repo");
            Console.WriteLine("5 - See all the recipes");
            Console.WriteLine("6 - Exit application");
            int option = CollectInputAsValidOption(6);
            Console.WriteLine();
            switch (option)
            {
                case 1:
                    Console.WriteLine($"Which product would you like to add to your {foodRepository.Name}?");
                    AvailableProductsMenu(foodRepository);
                    Console.WriteLine("Do you want to add another product?");
                    string answer = CollectYesOrNoInput();
                    while (answer == "yes")
                    {
                        AvailableProductsMenu(foodRepository);
                        Console.WriteLine("Would you like to add another product?");
                        answer = CollectYesOrNoInput();
                    }
                    SaveFoodRepoData(foodRepository);
                    FoodRepositoryMenu(foodRepository);
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("This is a list of available products:");
                    i = 1;
                    foreach (var product in foodRepository.Products)
                    {
                        Console.WriteLine($"Product number {i}:  ID of the product: {product.Product.Id}   {product.Quantity} [{product.Product.UnitOfMeasure}] of {product.Product.Name}");
                        i++;
                    }
                    Console.WriteLine();
                    Console.WriteLine($"Do you want to add or subtract quantity of the product from your {foodRepository.Name}?");
                    Console.WriteLine();
                    Console.WriteLine("1. Press one if you want to add quantity of the product.");
                    Console.WriteLine("2. Press two if you want to subtract quantity of the product.");
                    int options = CollectInputAsValidOption(2);
                    switch (options)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine($"Which product from your {foodRepository.Name} do you want to edit? Select the correct ID of the product.");
                            Console.WriteLine();
                            i = 1;
                            foreach (var product in foodRepository.Products)
                            {
                                Console.WriteLine($"Product number {i}:  ID of the product: {product.Product.Id}  Quantity: {product.Quantity} [{product.Product.UnitOfMeasure}] of {product.Product.Name}");
                                i++;
                            }
                            var selectedProductId = EditProductsbyID(foodRepository);
                            var selectProduct = foodRepository.Products.Where(x => x.Product.Id == selectedProductId).ToList();
                            var selectedProductName = selectProduct.Select(x => x.Product.Name.ToString());
                            var productName = selectedProductName.First();
                            Console.WriteLine($"How much/many of {productName} would you like to add to the repo?");
                            int quantity = CollectUnitInput();
                            var changeQuantity = selectProduct.Select(x => x.Quantity);
                            var previousQuantityValue = changeQuantity.First();
                            foodRepository.Products.Where(x => x.Product.Id == selectedProductId).First().Quantity = CalculateAddedQuantity(quantity, previousQuantityValue);
                            int newQuantity = CalculateAddedQuantity(quantity, previousQuantityValue);

                            if (newQuantity == 0)
                            {
                                foodRepository.Products.RemoveAll(x => x.Product.Id == selectedProductId);
                            }
                            SaveFoodRepoData(foodRepository);   //dodane
                            FoodRepositoryMenu(foodRepository);
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine($"Which product from your {foodRepository.Name} do you want to edit? Select the correct ID of the product.");
                            Console.WriteLine();
                            i = 1;
                            foreach (var product in foodRepository.Products)
                            {
                                Console.WriteLine($"Product number {i}:  ID of the product: {product.Product.Id}  Quantity: {product.Quantity} [{product.Product.UnitOfMeasure}] of {product.Product.Name}");
                                i++;
                            }
                            selectedProductId = EditProductsbyID(foodRepository);
                            selectProduct = foodRepository.Products.Where(x => x.Product.Id == selectedProductId).ToList();
                            selectedProductName = selectProduct.Select(x => x.Product.Name.ToString());
                            productName = selectedProductName.First();
                            Console.WriteLine($"How much/many of {productName} would you like to substract from the repo?");
                            quantity = ChangeProductsQuantity();
                            changeQuantity = selectProduct.Select(x => x.Quantity);
                            previousQuantityValue = changeQuantity.First();
                            foodRepository.Products.Where(x => x.Product.Id == selectedProductId).First().Quantity = CalculateSubtractedQuantity(quantity, previousQuantityValue);
                            newQuantity = CalculateSubtractedQuantity(quantity, previousQuantityValue);
                            if (newQuantity == 0)
                            {
                                foodRepository.Products.RemoveAll(x => x.Product.Id == selectedProductId);
                            }
                            SaveFoodRepoData(foodRepository);   //dodane
                            FoodRepositoryMenu(foodRepository);
                            break;
                    }
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Which product do you want to remove?");
                    Console.WriteLine();
                    i = 1;
                    foreach (var product in foodRepository.Products)
                    {
                        Console.WriteLine($"Product number {i}:  ID of the product: {product.Product.Id}  Quantity: {product.Quantity} [{product.Product.UnitOfMeasure}] of {product.Product.Name}");
                        i++;
                    }
                    var selectedIdOfTheProduct = EditProductsbyID(foodRepository);
                    foodRepository.Products.RemoveAll(x => x.Product.Id == selectedIdOfTheProduct);
                    SaveFoodRepoData(foodRepository);
                    FoodRepositoryMenu(foodRepository);
                    break;
                case 4:
                    var recipesContent = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Recipes.json"));
                    CookingRecipeService.Recipes = JsonConvert.DeserializeObject<List<CookingRecipe>>(recipesContent);
                    var recipes = CookingRecipeService.GetCookingRecipes();
                    var filteredRecipesList = FindCookingRecipe.FindCookingRecipie(CookingRecipeService.GetCookingRecipes(), foodRepository.GetProducts());
                    foreach(var filteredRecipe in filteredRecipesList)
                    {
                        Console.WriteLine(filteredRecipe);
                    }                  
                    break;
                case 5:
                    Console.Clear();
                    recipesContent = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Recipes.json"));
                    CookingRecipeService.Recipes = JsonConvert.DeserializeObject<List<CookingRecipe>>(recipesContent);
                    recipes = CookingRecipeService.GetCookingRecipes();
                    foreach (var recipie in recipes)
                    {
                        Console.WriteLine($"Recipe nr:{recipie.Id} - {recipie.Name}");
                        Console.WriteLine();
                        Console.WriteLine($"Is it for vegetarian? {recipie.IsVegeterian}");
                        Console.WriteLine();
                        Console.WriteLine($"Cooking time in minutes - {recipie.CookingTimeInMinutes}");
                        Console.WriteLine();
                        Console.WriteLine($"List of required ingredients:");
                        Console.WriteLine();
                        foreach (var ingredient in recipie.Ingredients)
                        {
                            Console.WriteLine(ingredient.Product.Name);
                        }
                        Console.WriteLine();
                        Console.WriteLine($"Description: {recipie.Description}");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to see the next recipe");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    FoodRepositoryMenu(foodRepository);
                    break; 
                case 6:
                    break;
            }
        }
        private static void AvailableProductsMenu(FoodRepository foodRepository)
        {
            var productsContent = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Products.json"));
            ProductService.Products = JsonConvert.DeserializeObject<List<Product>>(productsContent);

            Console.WriteLine();
            Console.WriteLine($"Select the ID of the product to add it to your {foodRepository.Name}:");
            var products = ProductService.GetProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"ID of the product: {product.Id} - {product.Name}");
            }
            var selectedProductId = SelectProductById(foodRepository);
            Product selectedProductOption = CollectProductById(products, selectedProductId);
            var selectProduct = products.Where(x => x.Id == selectedProductId).ToList();
            var selectedProductName = selectProduct.Select(x => x.Name.ToString());
            var productName = selectedProductName.First();
            Console.WriteLine(productName);
            Console.WriteLine($"How much/many of {productName} would you like to add to the repo?");
            int quantity = CollectUnitInput();
            var isThereAProduct = foodRepository.Products.Where(x => x.Product.Name == productName).FirstOrDefault();

            if (isThereAProduct == null)   //jesli repozytorium nie zawiera jeszcze danego produktu
            {
                foodRepository.AddProductToFoodRepository(selectedProductOption, quantity);
                Console.WriteLine($"{productName} added to the food repository.");
                Console.WriteLine();
                string anotherProduct;
                Console.WriteLine("Do you want to add another product?");
                anotherProduct = CollectYesOrNoInput();
                if (anotherProduct == "yes")
                {
                    AvailableProductsMenu(foodRepository);
                }
                else
                {
                    SaveFoodRepoData(foodRepository);
                    FoodRepositoryMenu(foodRepository);
                }
            }
            else   //jesli repozytorium zawiera juz dany produkt
            {
                var productsAlreadyAddedToRepo = foodRepository.GetProducts();
                var nameoftheAddedProduct = productsAlreadyAddedToRepo.Where(x => x.Product.Name == productName).ToList();
                var previousQuantityValue = nameoftheAddedProduct.Where(x => x.Product.Name == productName).Select(x => x.Quantity).FirstOrDefault();
                foodRepository.Products.Where(x => x.Product.Id == selectedProductId).First().Quantity = CalculateAddedQuantity(quantity, previousQuantityValue);
                int newQuantity = CalculateAddedQuantity(quantity, previousQuantityValue);
                Console.WriteLine($"{productName} added to the food repository.");
                Console.WriteLine();
                Console.WriteLine("Do you want to add another product?");
                string answer = CollectYesOrNoInput();
                if (answer == "yes")
                {
                    AvailableProductsMenu(foodRepository);
                }
                else
                {
                    //SaveFoodRepoData(foodRepository);
                    FoodRepositoryMenu(foodRepository);
                }
            }
        }
        private static int CalculateSubtractedQuantity(int quantity, int previousQuantityValue)
        {
            int newValue = previousQuantityValue - quantity;
            if (newValue < 0)
            {
                newValue = 0;
            }

            return newValue;
        }
        private static int CalculateAddedQuantity(int quantity, int previousQuantityValue)
        {
            int newValue = quantity + previousQuantityValue;
            if (newValue < 0)
            {
                newValue = 0;
            }

            return newValue;
        }
        private static string CollectYesOrNoInput()
        {
            bool valid;
            string value = "";

            do
            {
                string? input = Console.ReadLine();
                if (input == "yes" || input == "no")
                {
                    value = input;
                    valid = true;
                }
                else
                {
                    valid = false;
                    Console.WriteLine("Invalid input, try again ('yes' for yes, 'no' for no)");
                }
            }
            while (!valid);
            return value;
        }
        private static void SaveUsersListData (List<UserAccount> usersList)
        {
            string dataDirectoryPath = Directory.GetCurrentDirectory();
            string usersDataDirectoryPath = Path.Combine(dataDirectoryPath, "Users");
            string usersDataFilePath = Path.Combine(usersDataDirectoryPath, "Users.json");
            while (!Directory.Exists(usersDataDirectoryPath))
            {
                Directory.CreateDirectory(usersDataDirectoryPath);
                Directory.Exists(usersDataDirectoryPath);
            }
            var usersData = JsonConvert.SerializeObject(usersList, Formatting.Indented);
            File.WriteAllText(usersDataFilePath, usersData);
        }
        private static void SaveFoodRepoData(FoodRepository foodRepository)
        {
            var foodRepoData = JsonConvert.SerializeObject(foodRepository, Formatting.Indented);
            string foodReposPath = Path.Combine(Directory.GetCurrentDirectory(), "Repos");
            var reposDataDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Repos");
            while (!Directory.Exists(reposDataDirectoryPath))
            {
                Directory.CreateDirectory(reposDataDirectoryPath);
                Directory.Exists(reposDataDirectoryPath);
            }
            File.WriteAllText(Path.Combine(foodReposPath, $"{foodRepository.Name}.json"), foodRepoData);
        }
        private static Product CollectProductById(List<Product> products, int productId)
        {
            
            Product? product;

                
            product = products.FirstOrDefault(p => p.Id == productId);

            return product!;
        }
        private static int EditProductsbyID(FoodRepository foodRepository)
        {
            bool valid;
            int number = 1;

            do
            {
                string? input = Console.ReadLine();
                bool inputIsInt = Int32.TryParse(input, out number);
                var products = foodRepository.GetProducts();
                var productIds = products.Select(x => x.Product.Id).ToList();
                if (productIds.Contains(number) && products != null)
                {
                    valid = true;
                }
                else
                {
                    valid = false;
                    Console.WriteLine("Invalid input, try again");
                }
            }
            while (!valid);
            return number;
        }
        private static int SelectProductById(FoodRepository foodRepository)
        {
            bool valid;
            int number = 1;

            do
            {
                string? input = Console.ReadLine();
                bool inputIsInt = Int32.TryParse(input, out number);

                var products = ProductService.GetProducts();
                var productIds = products.Select(x => x.Id).ToList();
                if (productIds.Contains(number) && foodRepository != null)
                {
                    valid = true;
                }
                else
                {
                    valid = false;
                    Console.WriteLine("Invalid input, try again");
                }
            }
            while (!valid);
            return number;
        }
        //private static int CollectProductIdInputAsValidOption(List<Product> products)
        //{
        //    bool valid;
        //    int option = -1;
        //    int[] productsIds = new int[products.Count];
        //    for (int i = 0; i < products.Count; i++)
        //    {
        //        productsIds[i] = (products[i].Id);
        //    }
        //    do
        //    {
        //        string? input = Console.ReadLine();
        //        bool inputIsInt = Int32.TryParse(input, out int number);
        //        bool inputIsContainedWithinAvailableIds = productsIds.Contains(number);
        //        if (inputIsInt && inputIsContainedWithinAvailableIds)
        //        {
        //            option = number;
        //            valid = true;
        //        }
        //        else
        //        {
        //            valid = false;
        //            Console.WriteLine("Invalid input, try again");
        //        }
        //    }
        //    while (!valid);
        //    return option;
        //}
        private static int CollectUnitInput()
        {
            bool valid;
            int unit = -1;

            do
            {
                string? input = Console.ReadLine();
                bool inputIsInt = Int32.TryParse(input, out int number);
                if (inputIsInt && number > 0)
                {
                    unit = number;
                    valid = true;
                }
                else
                {
                    valid = false;
                    Console.WriteLine("Invalid input, try again");
                }
            }
            while (!valid);
            return unit;
        }
        private static int ChangeProductsQuantity()
        {
            bool valid;
            int productQuantity = 1;
            do
            {
                string input = Console.ReadLine();
                bool inputIsInt = Int32.TryParse(input, out int number);
                if (inputIsInt)
                {
                    productQuantity = number;
                    valid = true;
                }
                else
                {
                    valid = false;
                    Console.WriteLine("Invalid input, try again");
                }
            }
            while (!valid);
            return productQuantity;
        }
        private static int CollectInputAsValidOption(int numberOfPossibleOptions)
        {

            bool valid;
            int option = -1;

            do
            {
                string? input = Console.ReadLine();
                bool inputIsInt = Int32.TryParse(input, out int number);
                bool inputIsContainedWithinPossibleOptions = number > 0 && number <= numberOfPossibleOptions;

                if (inputIsInt && inputIsContainedWithinPossibleOptions)
                {
                    option = number;
                    valid = true;
                }
                else
                {
                    valid = false;
                    Console.WriteLine("Invalid input, try again");
                }
            }
            while (!valid);

            return option;
        }
        private static string CollectStringInput(string name)
        {

            bool valid;
            string value = "";

            do
            {
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    value = input;
                    valid = true;
                }
                else
                {
                    valid = false;
                    Console.WriteLine("Invalid input, try again");
                    Console.WriteLine($"Please, enter a valid {name}");
                }
            }
            while (!valid);

            return value;
        }
        private static string CollectEmailInput()
        {
            bool valid;
            string email = "";

            do
            {
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && input.Contains('@'))
                {
                    email = input;
                    valid = true;
                }
                else
                {
                    valid = false;
                    Console.WriteLine("Invalid input, try again");
                    Console.WriteLine("Please, enter you email address");
                }
            }
            while (!valid);

            return email;
        }

    }
}
