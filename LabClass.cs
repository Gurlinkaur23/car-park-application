using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LabAssignment_04
{
    internal class LabClass
    {
        Dictionary<int, string> carPark = new Dictionary<int, string>();
        public int maxCapacity = 5;

        /// <summary>
        /// This method adds the values to a dictionary. The keys are integers and values are set to null.
        /// It returns the dictionary.
        /// </summary>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public Dictionary<int, string> InitializeCarPark(int capacity)
        {
            for (int i = 1; i <= capacity; i++)
            {
                carPark[i] = null;
            }

            return carPark;
        }

        /// <summary>
        /// This methods uses a regex to validate the license entered by the user.
        /// </summary>
        /// <param name="license"></param>
        /// <returns></returns>
        public bool ValidateLicense(string license)
        {
            try
            {
                string regex = "^[A-Z0-9]{3}-[A-Z0-9]{3}$";

                if (!Regex.IsMatch(license, regex))
                {
                    throw new ArgumentException("The license should be an upppercase, alphanumeric combination of six values, separated by a hyphen in the middle. (A1A-00V)");
                }
                return true;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        /// <summary>
        /// This method checks if the car park is empty and also checks for the validation of the input license.
        /// Then, adds the cars to the car park.
        /// </summary>
        /// <param name="carPark"></param>
        /// <param name="license"></param>
        /// <returns></returns>
        public int AddVehicle(Dictionary<int, string> carPark, string license)
        {
            try
            {
                if (carPark.All(keyValuePair => keyValuePair.Value != null))
                {
                    throw new ArgumentOutOfRangeException("Car park is full. Cannot add more cars.");
                }
                if (carPark.ContainsValue(license))
                {
                    throw new ArgumentException("The given license number already exists in the car park.");
                }

                for (int i = 1; i <= carPark.Count; i++)
                {
                    if (ValidateLicense(license) && carPark[i] == null)
                    {
                        carPark[i] = license;
                        return i;
                    }
                }
                return -1;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// This method removes the car from the parking stall based on the stall number.
        /// </summary>
        /// <param name="carPark"></param>
        /// <param name="stallNumber"></param>
        /// <returns></returns>
        public bool VacateStall(Dictionary<int, string> carPark, int stallNumber)
        {
            if (carPark.ContainsKey(stallNumber) && carPark[stallNumber] != null)
            {
                carPark[stallNumber] = null;
                return true;
            }
            return false;
        }

        /// <summary>
        /// This method removes the car from the parking stall based on the license number.
        /// </summary>
        /// <param name="carPark"></param>
        /// <param name="licenseNumber"></param>
        /// <returns></returns>
        public bool LeaveParkade(Dictionary<int, string> carPark, string licenseNumber)
        {
            try
            {
                if (ValidateLicense(licenseNumber) && carPark.ContainsValue(licenseNumber))
                {
                    // Finding the key based on the value of license
                    int key = carPark.FirstOrDefault(num => num.Value == licenseNumber).Key;

                    // Removing the license using the key
                    carPark[key] = null;
                    return true;
                }
                else
                {
                    Console.WriteLine("The given license is invalid. Please enter a valid license.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// This method returns a printed list of parking stalls and license numbers of cars.
        /// </summary>
        /// <param name="carPark"></param>
        /// <returns></returns>
        public string Manifest(Dictionary<int, string> carPark)
        {
            string printedList = "";
            foreach (KeyValuePair<int, string> keyValuePair in carPark)
            {
                printedList += $"Stall Number : {keyValuePair.Key}, License number : {keyValuePair.Value ?? "unoccupied"}" + "\n";
            }
            return printedList;
        }

    }
}
