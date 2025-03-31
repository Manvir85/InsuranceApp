namespace InsuranceApp;

class Program
{
    // Global Variables
    static int laptopCounter = 0, desktopCounter = 0, otherCounter = 0;
    static string mostExpensiveDevice = "";
    static float totalInsuranceCost = 0, priciestDevice = 0;


    // Constant Variables

    static List<string> CATEGORY = new List<string>() { "Laptop\n", "Desktop\n", "Other\n" };

    // Methods and Functions
    static void InputDeviceInfo()
    {

    }
    static void OneDevice()
    {
        Console.WriteLine("░█░█░█▀▀░█░░░█▀▀░█▀█░█▄█░█▀▀░░░▀█▀░█▀█░░░▀█▀░█▀█░█▀▀░█░█░█▀▄░█▀█░█▀█░█▀▀░█▀▀\r\n░█▄█░█▀▀░█░░░█░░░█░█░█░█░█▀▀░░░░█░░█░█░░░░█░░█░█░▀▀█░█░█░█▀▄░█▀█░█░█░█░░░█▀▀\r\n░▀░▀░▀▀▀░▀▀▀░▀▀▀░▀▀▀░▀░▀░▀▀▀░░░░▀░░▀▀▀░░░▀▀▀░▀░▀░▀▀▀░▀▀▀░▀░▀░▀░▀░▀░▀░▀▀▀░▀▀▀\r\n░█▀█░█▀█░█▀█                                                                \r\n░█▀█░█▀▀░█▀▀                                                                \r\n░▀░▀░▀░░░▀░░                                                                ");
        // Local Variables

        string deviceName;
        int category, numDevice;
        float devicePrice, deviceInsurance = 0; ;

        // Input  the device name
        Console.WriteLine("Enter the device name:");
        deviceName = Console.ReadLine();

        Console.WriteLine("Enter the number of devices:");
        numDevice = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the cost per device:");
        float deviceCost = float.Parse(Console.ReadLine());

        string categoryMenu = "Select the device category:\n";
        int categoryNumber = 0;

        foreach (var cat in CATEGORY)
        {

            categoryNumber++;
            categoryMenu += $"{categoryNumber}.{cat}";
        }

        Console.WriteLine(categoryMenu);
        Console.ReadLine();

        // Adds the user input to a counter for the appropriate category

        if (categoryNumber == 1)
        {
            laptopCounter += numDevice;

        }
        else if (categoryNumber == 2)
        {
            desktopCounter += numDevice;

        }
        else
        {
            otherCounter += numDevice;

        }

        if (numDevice > 5)
        {
            deviceInsurance += 5 * deviceCost;

            deviceInsurance += (numDevice - 5) * deviceCost * 0.9f;
        }

        else
        {
            deviceInsurance += numDevice * deviceCost;
        }


        Console.WriteLine("-----------------------------------------------\n");
        // Display the Insurance Cost
        Console.WriteLine($"{deviceName}");
        Console.WriteLine($"Total cost for {numDevice} x {deviceName} is = {deviceInsurance:F2} (with insurance)");


    }



    



    static void Main(string[] args)
    {
        OneDevice();
    }
}