using Telephony.Core.Interfaces;
using Telephony.Models;
using Telephony.Models.Interfaces;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string[] phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] urls = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            ICallable phone;

            foreach (var phoneNumber in phoneNumbers)
            {
                if (phoneNumber.Length == 10)
                {
                    phone = new Smartphone();
                }
                else
                {
                    phone = new StationaryPhone();
                }

                try
                {
                    Console.WriteLine(phone.Call(phoneNumber));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            IBrowsable browsable = new Smartphone();

            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(browsable.Browse(url));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
