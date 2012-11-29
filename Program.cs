using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InspectronAPINancy
{
    class Program
    {
        static void Main(string[] args)
        {
            var nancyHost = new Nancy.Hosting.Self.NancyHost(new Uri("http://localhost:1234"));
            nancyHost.Start();
            Console.WriteLine("NancyFX API running");
            Console.ReadLine();
            nancyHost.Stop();
        }
    }
}
