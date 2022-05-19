using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex3;
using System.Drawing;


namespace Ex3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int carNumber = 1;
            int busNumber = 1;
            int truckNumber = 1;
            int motorcycleNumber = 1;

            List<string> colors = new List<string>();

            //get the color names from the Known color enum
            string[] colorNames = Enum.GetNames(typeof(KnownColor));

            foreach (string colorName in colorNames)
            {
                KnownColor knownColor = (KnownColor)Enum.Parse(typeof(KnownColor), colorName);
                //check if the knownColor variable is a System color
                if (knownColor > KnownColor.Transparent)
                {
                    colors.Add(colorName);
                }

            }
            colors = colors.ConvertAll(d => d.ToLower());

            Console.WriteLine("Hello user, please tell me the name of your garage:");
            Garage garage = new Garage(Console.ReadLine());
            Console.WriteLine("Thank you for the garage name, please tell me the capacity for the vehicles in your garage.");
            while (!int.TryParse(Console.ReadLine(), out garage.maxNumberOfVehicles))
            {
                Console.WriteLine("Incorrect input, please try again");
            }

            while (garage.CountVehicles() < garage.maxNumberOfVehicles)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine($"Please tell me what type of the vehicle do you want to add to your garage:");
                Console.WriteLine("Choose 1 - if you want to add a car");
                Console.WriteLine("Choose 2  - if you want to add a bus");
                Console.WriteLine("Choose 3  - if you want to add a truck");
                Console.WriteLine("Choose 4  - if you want to add a motorcycle");
                char inputData = UserInput();
                Console.Clear();

                switch (inputData)
                {
                    case '1':
                        Console.WriteLine($"Tell me the color of the car number {carNumber}: ");
                        string colorOfChoice = Console.ReadLine();
                        //checks whether the colors list contains the color picked by the user, returns true or false
                        bool match = colors.Contains(colorOfChoice);
                        // while not true (color not on the list), do......
                        while (!colors.Contains(colorOfChoice))           
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Red;
                            WrongInput();
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine();
                            colorOfChoice = Console.ReadLine();
                        }
                        garage.AddNewVehicle(new Car(colorOfChoice));
                        carNumber++;
                        Console.Clear();
                        break;

                    case '2':
                        Console.WriteLine($"Tell me the color of the bus number {busNumber}: ");
                        colorOfChoice = Console.ReadLine();
                        match = colors.Contains(colorOfChoice);
                        while (!colors.Contains(colorOfChoice))
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Red;
                            WrongInput();
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine();
                            colorOfChoice = Console.ReadLine();
                        }
                        garage.AddNewVehicle(new Bus(colorOfChoice));
                        busNumber++;
                        Console.Clear();
                        break;

                    case '3':
                        Console.WriteLine($"Tell me the color of the truck number {truckNumber}: ");
                        colorOfChoice = Console.ReadLine();
                        match = colors.Contains(colorOfChoice);
                        while (!colors.Contains(colorOfChoice))
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Red;
                            WrongInput();
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine();
                            colorOfChoice = Console.ReadLine();
                        }
                        garage.AddNewVehicle(new Truck(colorOfChoice));
                        truckNumber++;
                        Console.Clear();
                        break;

                    case '4':
                        Console.WriteLine($"Tell me the color of the motorcycle number {motorcycleNumber}: ");
                        colorOfChoice = Console.ReadLine();
                        match = colors.Contains(colorOfChoice);
                        while (!colors.Contains(colorOfChoice))
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Red;
                            WrongInput();
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine();
                            colorOfChoice = Console.ReadLine();
                        }
                        garage.AddNewVehicle(new Motorcycle(colorOfChoice));
                        motorcycleNumber++;
                        Console.Clear();
                        break;

                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorrect input, please try again");
                        Console.WriteLine();
                        break;
                }
            }

            Console.WriteLine($"Thank you for the details. Your garage {garage.name} contains: {garage.maxNumberOfVehicles} vehicles");
            Console.WriteLine();
            garage.PrintAllVehicles();
        }
        public static void WrongInput()
        {
            Console.WriteLine("You have entered invalid name of the color or such a color can not be implemented in the app." +
                                "\nTry to enter the color name again." +
                                "\nDo not use uppercase letters.");
        }
        public static char UserInput()
        {
            char userInput = Console.ReadKey().KeyChar;
            return userInput;
        }

    }
}
