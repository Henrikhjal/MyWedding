using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using System.ServiceModel;

namespace SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(MessageService));
            host.Open();
            Console.WriteLine("tryck för att avsluta");
            Console.ReadKey();
            host.Close();
        }
    }
}
