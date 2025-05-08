using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

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
        static int CheckNumberOfDevices()
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
            Regex validNamePattern = new Regex(@"^[a-zA-Z0-9 ]+$");

            while (true)
            {
                Console.WriteLine("Enter the device name:");
                deviceName = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(deviceName))
                {
                    if (validNamePattern.IsMatch(deviceName))
                    {
                        deviceName = textInfo.ToTitleCase(deviceName.ToLower());
                        return deviceName;
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

        static int CheckDeviceCategory()
        {
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
                    return category;
                }
                else
                {
                    Console.WriteLine("Error: Please select a valid category number.");
                }
            }
        }

        static float CheckDeviceCost()
        {
            float deviceCost = 0;
            while (true)
            {
                Console.WriteLine("Enter the cost per device:");
                if (float.TryParse(Console.ReadLine(), out deviceCost) && deviceCost > 0)
                {
                    return deviceCost;
                }
                else
                {
                    Console.WriteLine("Error: Please enter a valid positive number for cost.");
                }
            }
        }

        static void OneDevice()
        {
            string deviceName = CheckName();
            string deviceCode = GenerateDeviceCode();

            int numDevice = CheckNumberOfDevices();
            int category = CheckDeviceCategory();
            float deviceCost = CheckDeviceCost();

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
