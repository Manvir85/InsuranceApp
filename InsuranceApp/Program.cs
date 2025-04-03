using System;
using System.Collections.Generic;

namespace InsuranceApp;

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

    // Methods and Functions
    static void OneDevice()
    {
        Console.WriteLine("░█░█░█▀▀░█░░░█▀▀░█▀█░█▄█░█▀▀░░░▀█▀░█▀█░░░▀█▀░█▀█░█▀▀░█░█░█▀▄░█▀█░█▀█░█▀▀░█▀▀\r\n░█▄█░█▀▀░█░░░█░░░█░█░█░█░█▀▀░░░░█░░█░█░░░░█░░█░█░▀▀█░█░█░█▀▄░█▀█░█░█░█░░░█▀▀\r\n░▀░▀░▀▀▀░▀▀▀░▀▀▀░▀▀▀░▀░▀░▀▀▀░░░░▀░░▀▀▀░░░▀▀▀░▀░▀░▀▀▀░▀▀▀░▀░▀░▀░▀░▀░▀░▀▀▀░▀▀▀\r\n░█▀█░█▀█░█▀█                                                                \r\n░█▀█░█▀▀░█▀▀                                                                \r\n░▀░▀░▀░░░▀░░                                                                ");
        
        // Input the Device name
        Console.WriteLine("Enter the device name:");
        string deviceName = Console.ReadLine();
        string deviceCode = GenerateDeviceCode();

        Console.WriteLine("Enter the number of devices:");
        int numDevice = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the cost per device:");
        float deviceCost = float.Parse(Console.ReadLine());

        Console.WriteLine("Select the device category:");
        for (int i = 0; i < CATEGORY.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {CATEGORY[i]}");
        }
        int category = Convert.ToInt32(Console.ReadLine());

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

        for (int month = 1; month <= 6; month++)
        {
            deviceCost *= 0.95f; // 5% depreciation per month
            Console.WriteLine($"Month: {month}\tValue: ${deviceCost:F2}");
        }

        Console.WriteLine($"CATEGORY: {CATEGORY[category - 1]}");
    }

    static void Main(string[] args)
    {
        string proceed = "";
        while (proceed.ToLower() != "stop")
        {
            OneDevice();
            Console.WriteLine("Press Enter to add another device or type 'Stop' to finish.");
            proceed = Console.ReadLine();
        }

        Console.WriteLine($"\nThe number of laptops: {laptopCounter}");
        Console.WriteLine($"The number of desktops: {desktopCounter}");
        Console.WriteLine($"The number of other devices: {otherCounter}");
        Console.WriteLine($"\nThe total value for insurance: ${totalInsuranceCost:F2}");
        Console.WriteLine($"The most expensive device - {mostExpensiveDevice}");
    }
}
