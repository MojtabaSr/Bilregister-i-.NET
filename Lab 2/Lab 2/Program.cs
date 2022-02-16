using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_2.Utility;

namespace Lab_2
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.Write("How many cars do you wish to create? (0-9): ");
            var carList = CreateVehicle<Car>(InitialParse());

            Console.Clear();
            Console.Write("How many boats do you wish to create? (0-9): ");
            var boatList = CreateVehicle<Boat>(InitialParse());

            Console.Clear();
            Console.Write("How many motorcycles do you wish to create? (0-9): ");
            var motorcycleList = CreateVehicle<Motorcycle>(InitialParse());

            Console.Clear();
            while (userExit == false)
            {
                PrintMainMenu();
                //main switch statement, first input dictates what class we base interaction on
                switch (MainMenuParse())
                {
                    case 1:
                        Console.Clear();
                        //prints submenu for chosen vehicles 
                        VehicleMenu(carList, carType);
                        carList = VehicleInterface<Car>(carList, VehicleMenuParse(carList), carType);
                        break;
                    case 2:
                        Console.Clear();
                        VehicleMenu(boatList, boatType);
                        boatList = VehicleInterface<Boat>(boatList, VehicleMenuParse(boatList), boatType);
                        break;
                    case 3:
                        Console.Clear();
                        VehicleMenu(motorcycleList, motorcycleType);
                        motorcycleList = VehicleInterface<Motorcycle>(motorcycleList, VehicleMenuParse(motorcycleList), motorcycleType);
                        break;
                    case 4: // printing each object speed value in m/s
                        Console.Clear();
                        PrintSpeedInMetersPerSecond(carList, carType);
                        Console.WriteLine();
                        PrintSpeedInMetersPerSecond(boatList, boatType);
                        Console.WriteLine();
                        PrintSpeedInMetersPerSecond(motorcycleList, motorcycleType);
                        Console.WriteLine();
                        Console.WriteLine("Press any key to go back to main menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
                Console.Clear();
            }

            Console.ReadLine();
        }



    }
}
