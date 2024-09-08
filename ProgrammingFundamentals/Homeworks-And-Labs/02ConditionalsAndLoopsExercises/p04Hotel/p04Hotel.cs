using System;

namespace p04Hotel
{
    class p04Hotel
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine().ToLower();
            int nights = int.Parse(Console.ReadLine());

            double studioPrice = 0;
            double doublePrice = 0;
            double masterSuitePrice = 0;

            double totalStudioPrice = 0;
            double totalDoublePrice = 0;
            double totalMasterSuitePrice = 0;

            if (month == "may" || month == "october")
            {
                if (nights > 7)
                {
                    studioPrice = 50.00 * 0.95;
                }
                else
                studioPrice = 50.00;
                doublePrice = 65.00;
                masterSuitePrice = 75.00;
            }
            else if (month == "june" || month == "september")
            {
                if (nights>14)
                {
                    doublePrice = 72.00 * 0.9;
                }
                else
                doublePrice = 72.00;
                studioPrice = 60.00;
                masterSuitePrice = 82.00;
            }
            else if (month == "july" || month == "august" || month == "december")
            {
                if (nights > 14)
                {
                    masterSuitePrice = 89.00 * 0.85;
                }
                else
                masterSuitePrice = 89.00;
                studioPrice = 68.00;
                doublePrice = 77.00;
            }
            if (month == "september" || month == "october" && nights > 7)
            {
                totalStudioPrice = studioPrice * nights - studioPrice;
            }
            else
            {
                totalStudioPrice = studioPrice * nights;
            }
            
            
                
                 totalDoublePrice = doublePrice * nights;
                 totalMasterSuitePrice = masterSuitePrice * nights;
            
            Console.WriteLine($"Studio: {totalStudioPrice:f2} lv.");
            Console.WriteLine($"Double: {totalDoublePrice:f2} lv.");
            Console.WriteLine($"Suite: {totalMasterSuitePrice:f2} lv.");
        }
    }
}
