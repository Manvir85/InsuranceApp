using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace InsuranceApp
{
    class Program
    {
        // Importing Random for generating unique device codes
        static Random random = new Random();

        // Global Variables 
        static int laptopCounter = 0, desktopCounter = 0, otherCounter = 0;
        static string mostExpensiveDevice = ""; 
        static float totalInsuranceCost = 0, priciestDevice = 0; 

        // Constant Variables
        static List<string> CATEGORY = new List<string>() { "Laptop", "Desktop", "Other" };

        // Methods and Functions
        // Method to generate a unique device code
        static string GenerateDeviceCode()
        {
            // Generates a device code
            return $"DEV{random.Next(100, 999)}@{random.Next(10, 99)}";
        }

        // Method to check and get the number of devices from user input
        static int CheckNumberOfDevices()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the number of devices:");
                    int numDevice = Convert.ToInt32(Console.ReadLine());

                    // Validating the number of devices
                    if (numDevice >= 1 && numDevice <= 450)
                    {
                        return numDevice; // Return valid number of devices
                    }

                    Console.WriteLine("Error: Number of devices must be between 1 and 450.");
                }
                catch
                {
                    Console.WriteLine("Error: You must enter a valid number.");
                }
            }
        }

        // Method to check the name from the user input
        static string CheckName()
        {
            string deviceName;
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo; // For formatting the device name
            Regex validNamePattern = new Regex(@"^[a-zA-Z0-9 ]+$"); 

            while (true)
            {
                Console.WriteLine("Enter the device name:");
                deviceName = Console.ReadLine();

                // Validating the device name
                if (!string.IsNullOrWhiteSpace(deviceName))
                {
                    if (validNamePattern.IsMatch(deviceName))
                    {
                        // Format the device name to title case
                        deviceName = textInfo.ToTitleCase(deviceName.ToLower());
                        return deviceName; // Return valid device name
                    }
                    else
                    {
                        Console.WriteLine("Error: Device name can only contain letters, numbers, and spaces.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Device name cannot be empty.");
                }
            }
        }

        // Method to check device category
        static int CheckDeviceCategory()
        {
            int category = 0;
            while (true)
            {
                Console.WriteLine("Select the device category:");
                // Displaying the available categories
                for (int i = 0; i < CATEGORY.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {CATEGORY[i]}");
                }
                // Validating the selected category
                if (int.TryParse(Console.ReadLine(), out category) && category >= 1 && category <= CATEGORY.Count)
                {
                    return category; // Return valid category
                }
                else
                {
                    Console.WriteLine("Error: Please select a valid category number.");
                }
            }
        }

        // Method to check the cost of device
        static float CheckDeviceCost()
        {
            float deviceCost = 0;
            while (true)
            {
                Console.WriteLine("Enter the cost per device:");
                // Validating the device cost
                if (float.TryParse(Console.ReadLine(), out deviceCost) && deviceCost > 0)
                {
                    return deviceCost; // Return valid device cost
                }
                else
                {
                    Console.WriteLine("Error: Please enter a valid positive number for cost.");
                }
            }
        }

        // Method to handle the input and processing for one device
        static void OneDevice()
        {
            // Local variables 
            string deviceName = CheckName(); // Get device name
            string deviceCode = GenerateDeviceCode(); // Generate unique device code

            int numDevice = CheckNumberOfDevices(); // Get number of devices
            int category = CheckDeviceCategory(); // Get device category
            float deviceCost = CheckDeviceCost(); // Get device cost

            // Update counters based on the selected category
            if (category == 1) laptopCounter += numDevice;
            else if (category == 2) desktopCounter += numDevice;
            else otherCounter += numDevice;

            float deviceInsurance = deviceCost * numDevice * 0.10f;
            totalInsuranceCost += deviceInsurance;

            if (deviceCost > priciestDevice)
            {
                priciestDevice = deviceCost;
                mostExpensiveDevice = deviceName;
            }

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"{deviceName} ({deviceCode})");
            Console.WriteLine($"Total cost for {numDevice} x {deviceName} is = ${deviceInsurance:F2} (with insurance)");

            Console.WriteLine("\nDepreciation over 6 months:");
            float depreciatedCost = deviceCost;
            for (int month = 1; month <= 6; month++)
            {
                depreciatedCost *= 0.95f;
                Console.WriteLine($"Month: {month}\tValue: ${depreciatedCost:F2}");
            }

            Console.WriteLine($"CATEGORY: {CATEGORY[category - 1]}\n");
        }

        // Display Summary
        static void Main(string[] args)
        {
            string proceed = "";
            do
            {
                OneDevice();
                Console.WriteLine("Press Enter to add another device or type 'x' to finish.");
                proceed = Console.ReadLine() ?? "";
            } while (proceed.ToLower() != "x");

            Console.WriteLine($"\nThe number of laptops: {laptopCounter}");
            Console.WriteLine($"The number of desktops: {desktopCounter}");
            Console.WriteLine($"The number of other devices: {otherCounter}");
            Console.WriteLine($"\nThe total value for insurance: ${totalInsuranceCost:F2}");
            Console.WriteLine($"The most expensive device - {mostExpensiveDevice}");

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
