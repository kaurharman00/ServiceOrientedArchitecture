using ProductService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ProductService
{
    public class Program
    {
        static void Main()
        {
            //Initialise and open service host 
            ServiceHost host = new ServiceHost(typeof(NorthwindService));
            host.Open();
            Console.WriteLine("Server Open");
            Console.ReadLine();
        }
    }
}
