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



    }



    static void Main(string[] args)
    {
        OneDevice();
    }
}