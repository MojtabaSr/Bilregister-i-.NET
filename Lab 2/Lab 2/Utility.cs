using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    static class Utility
    {

        public static Random rnd = new Random();
        public static string carType = "Car";
        public static string boatType = "Boat";
        public static string motorcycleType = "Motorcycle";
        public static bool userExit = false;

        // method that parses main menu input
        public static int MainMenuParse()
        {
            bool correctInput = Int32.TryParse(Console.ReadLine(), out int userChoice);


            while (!correctInput || userChoice <= 0 || userChoice > 4) //while loop hanterar input
            {
                Console.WriteLine("Invalid input, try again: ");
                correctInput = Int32.TryParse(Console.ReadLine(), out userChoice);

            }
            return userChoice;
        }

        // method that parses initial input
        public static int InitialParse()
        {
            bool correctInput = Int32.TryParse(Console.ReadLine(), out int userChoice);


            while (!correctInput || userChoice < 0 || userChoice > 9)
            {
                Console.WriteLine("Invalid input, try again: ");
                correctInput = Int32.TryParse(Console.ReadLine(), out userChoice);

            }
            return userChoice;
        }

        // method that parses input in the vehicle menu
        public static string VehicleMenuParse<T>(List<T> vehicleList)
        {
            string userChoice = Console.ReadLine();

            while (true)
            {
                bool IntParse = Int32.TryParse(userChoice, out int intChoice);
                if (userChoice == "+")
                {
                    break;
                }
                else if (userChoice == "exit")
                {
                    break;
                } //checks if input is integer and checks if the int corresponds to vehicle index
                else if (IntParse && vehicleList.Count > 0 && vehicleList.Count > intChoice && intChoice >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, try again: ");
                    userChoice = Console.ReadLine();
                }
            }
            Console.Clear();
            return userChoice;
        }

        // method that parses submenu for vehicle
        public static string VehicleSubMenuParse()
        {
            string userChoice = Console.ReadLine();
            while (true)
            {
                bool intParse = Int32.TryParse(userChoice, out int intChoice);
                if (userChoice == "-")
                {
                    break;
                }
                else if (intParse && intChoice >= 0 && intChoice <= 100)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, try again: ");
                    userChoice = Console.ReadLine();
                }
            }
            return userChoice;
        } 
        
        //method for initial creation of objects
        public static List<T> CreateVehicle<T>(int amount) where T : IVehicle, new()
        {
            List<T> output = new List<T>();
            
            for (int i = 0; i < amount; i++)
            {
                output.Add(new T());
            }
            return output; //return list of vehicle objects
        } 
        
        //main interface for creating, editing, and deleting objects
        public static List<T> VehicleInterface<T>(List<T> vehicleList, string userChoice, string type) where T: IVehicle, new()
        {

            if (userChoice == "+")
            {
                vehicleList.Add(new T());
                Console.WriteLine($"{type} added, press any key to go back to main menu");
                Console.ReadKey();
            }
            else if (userChoice == "exit") { }
  
            else 
            {
                Int32.TryParse(userChoice, out int IntChoice); //parsa till heltal
                Console.WriteLine($"-- {type} {IntChoice} --");
                Console.WriteLine($"Speed : {vehicleList[IntChoice].GetSpeed()}");
                Console.WriteLine($"Please enter new speed (0-100) or - to remove {type}");
                string subString = VehicleSubMenuParse();
                if (subString == "-")
                {
                    vehicleList.RemoveAt(IntChoice); //tabort på vald index
                    Console.Clear();
                    Console.WriteLine($"{type} removed. Press any key to go back to main menu");
                    Console.ReadKey();
                }
                else
                {
                    vehicleList[IntChoice].SetSpeed(Int32.Parse(subString)); //sätt hastighet på vald idx
                    Console.Clear();
                    Console.WriteLine($"{type} speed changed. Press any key to go back to main menu");
                    Console.ReadKey();
                }
            }
            return vehicleList;
        } 
        
        //submenu for each existing vehicle type
        public static void VehicleMenu<T>(List<T> vehicleList, string type) where T : IVehicle
        {
            int index = 0;
            Console.WriteLine($"-- {vehicleList.Count} {type}s in stock --");

            foreach (IVehicle obj in vehicleList)
            {
                //för varje fordonsobjekt skriv ut typ, idx, hastighet och enhet
                Console.WriteLine($"{type} {index} -- {obj.GetSpeed()} {obj.GetUnit()}"); 
                index++;
            }
            if (vehicleList.Count == 0)
            {
                Console.WriteLine($"No {type}s in stock, please enter + to add new {type} or type exit to go back to main menu");
            }
            else
            {
                Console.WriteLine($"Please select {type} to change (0-{vehicleList.Count - 1}) or enter + to add a new {type}");
            }
        } 
        
        //method for converting vehicle speeds to m/s
        public static void PrintSpeedInMetersPerSecond<T>(List<T> vehicleList, string type) where T : IVehicle
        {
            int index = 0;
            Console.WriteLine($"-- {vehicleList.Count} {type}s in stock --");

            foreach (IVehicle obj in vehicleList)
            {
                Console.WriteLine($"{type} {index} -- {obj.GetSpeed() * obj.GetMpsVal()} m/s");
                index++;
            }
        }

        //print method for main menu
        public static void PrintMainMenu()
        {
            Console.WriteLine("-- Please select --");
            Console.WriteLine("1. Print/create cars\n2. Print/create boats\n3. Print/create motorcycles\n4. Print all vehicles in m/s");
        }

    }
}
