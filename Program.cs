using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabAssignment_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LabClass lc = new LabClass();

                Dictionary<int, string> carPark = lc.InitializeCarPark(lc.maxCapacity);

                do
                {
                    Console.WriteLine("- * - * - * - * - * - * -");
                    Console.WriteLine();
                    Console.WriteLine("Choose a number from the given options:");
                    Console.WriteLine("1. Reserve a stall");
                    Console.WriteLine("2. Vacate the stall by stall number");
                    Console.WriteLine("3. Vacate the stall by license number");
                    Console.WriteLine("4. See the list of parking stalls and parked vehicles");
                    Console.WriteLine("5. Exit");
                    Console.WriteLine();

                    Console.Write("Select option: ");
                    string userChoice = Console.ReadLine();
                    Console.WriteLine();

                    if (int.TryParse(userChoice, out int choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.Write("Enter your car license to reserve a stall: ");
                                string inputLicense = Console.ReadLine().Trim();
                                lc.AddVehicle(carPark, inputLicense);
                                break;
                            case 2:
                                Console.Write("Enter your stall number to remove your car from the stall: ");
                                string inputStallNumber = Console.ReadLine().Trim();
                                if (int.TryParse(inputStallNumber, out int stallNumber))
                                {
                                    lc.VacateStall(carPark, stallNumber);
                                } else
                                {
                                    Console.WriteLine("Invalid stall number. Please enter a valid number.");
                                }
                                break;
                            case 3:
                                Console.Write("Enter your license number to remove your car from the stall: ");
                                string inputLicenseNumber = Console.ReadLine().Trim();
                                lc.LeaveParkade(carPark, inputLicenseNumber);
                                break;
                            case 4:
                                Console.WriteLine("The list of the parking stalls and the parking vehicles:");
                                Console.WriteLine(lc.Manifest(carPark));
                                break;
                            case 5:
                                Console.WriteLine("Exiting the application.");
                                return;
                            default:
                                Console.WriteLine("Invalid option. Please choose a valid number for the options.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Please choose a valid number for the options.");
                    }
                } while (true);
                //Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
