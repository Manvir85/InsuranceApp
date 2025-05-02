using System;
using System.Collections.Generic;
using System.Globalization;

namespace InsuranceApp
{
    class Program
    {
        static Random random = new Random();

        // Global Variables
        static int laptopCounter = 0, desktopCounter = 0, otherCounter = 0;
        static string mostExpensiveDevice = "";
        static float totalInsuranceCost = 0, priciestDevice = 0;

        // Constant Variables
        static List<string> CATEGORY = new List<string>() { "Laptop", "Desktop", "Other" };

        // Method to generate a unique device code
        static string GenerateDeviceCode()
        {
            return $"DEV{random.Next(100, 999)}@{random.Next(10, 99)}";
        }

        // Method to check and get the number of devices from user input
        static int CheckNumberofDevices()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the number of devices:");
                    int numDevice = Convert.ToInt32(Console.ReadLine());

                    if (numDevice >= 1 && numDevice <= 450)
                    {
                        return numDevice;
                    }

                    Console.WriteLine("Error: Number of devices must be between 1 and 450.");
                }
                catch
                {
                    Console.WriteLine("Error: You must enter a valid number.");
                }
            }
        }

        static string CheckName()
        {
            string deviceName;
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            while (true)
            {
                Console.WriteLine("Enter the device name:");
                deviceName = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(deviceName))
                {
                    // Capitalize each word, including those with numbers
                    deviceName = textInfo.ToTitleCase(deviceName.ToLower());
                    return deviceName;
                }

                Console.WriteLine("Error: Device name cannot be empty.");
            }
        }

        static void OneDevice()
        {
            // Input the Device name
            string deviceName = CheckName();
            string deviceCode = GenerateDeviceCode();

            int numDevice = CheckNumberofDevices();

            float deviceCost = 0;
            while (true)
            {
                Console.WriteLine("Enter the cost per device:");
                if (float.TryParse(Console.ReadLine(), out deviceCost) && deviceCost > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error: Please enter a valid positive number for cost.");
                }
            }

            int category = 0;
            while (true)
            {
                Console.WriteLine("Select the device category:");
                for (int i = 0; i < CATEGORY.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {CATEGORY[i]}");
                }
                if (int.TryParse(Console.ReadLine(), out category) && category >= 1 && category <= CATEGORY.Count)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error: Please select a valid category number.");
                }
            }

            // Adds the user input to a counter for the appropriate category
            if (category == 1) laptopCounter += numDevice;
            else if (category == 2) desktopCounter += numDevice;
            else otherCounter += numDevice;

            // Calculate insurance cost with discount
            float deviceInsurance = 0;
            if (numDevice > 5)
            {
                deviceInsurance += 5 * deviceCost;
                deviceInsurance += (numDevice - 5) * deviceCost * 0.9f;
            }
            else
            {
                deviceInsurance += numDevice * deviceCost;
            }

            totalInsuranceCost += deviceInsurance;

            if (deviceInsurance > priciestDevice)
            {
                priciestDevice = deviceInsurance;
                mostExpensiveDevice = $"{deviceName} @ ${priciestDevice:F2}";
            }

            Console.WriteLine("-----------------------------------------------");
            // Display the Insurance Cost
            Console.WriteLine($"{deviceName} ({deviceCode})");
            Console.WriteLine($"Total cost for {numDevice} x {deviceName} is = ${deviceInsurance:F2} (with insurance)");

            // Display depreciation
            Console.WriteLine("\nDepreciation over 6 months:");

            float depreciatedCost = deviceCost;
            for (int month = 1; month <= 6; month++)
            {
                depreciatedCost *= 0.95f; // 5% depreciation per month
                Console.WriteLine($"Month: {month}\tValue: ${depreciatedCost:F2}");
            }

            Console.WriteLine($"CATEGORY: {CATEGORY[category - 1]}");
        }

        static void Main(string[] args)
        {
            string proceed = "";
            while (proceed.ToLower() != "x")
            {
                OneDevice();
                Console.WriteLine("Press Enter to add another device or type 'x' to finish.");
                proceed = Console.ReadLine();
            }

            Console.WriteLine($"\nThe number of laptops: {laptopCounter}");
            Console.WriteLine($"The number of desktops: {desktopCounter}");
            Console.WriteLine($"The number of other devices: {otherCounter}");
            Console.WriteLine($"\nThe total value for insurance: ${totalInsuranceCost:F2}");
            Console.WriteLine($"The most expensive device - {mostExpensiveDevice}");
        }
    }
}
