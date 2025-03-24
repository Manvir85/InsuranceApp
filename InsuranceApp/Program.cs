using System;
using System.Collections.Generic;

namespace InsuranceApp
{
    internal class Program
    {
        // Global Variables
        static List<string> CATEGORY = new List<string>() { "Laptop", "Desktop", "Other"};

        static int laptopCounter = 0, desktopCounter = 0, otherCounter = 0;
        static string priciestDeviceName = "";
        static float insuranceCost = 0, priciestDevice = 0; 


        // Methods and Functions

        public static void Main(string[] args)
        {
            Console.WriteLine("Start of program");
        }

    }
}

