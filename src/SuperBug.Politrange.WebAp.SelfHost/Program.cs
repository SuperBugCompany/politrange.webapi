using System;
using Microsoft.Owin.Hosting;
using SuperBug.Politrange.Api;

namespace SuperBug.Politrange.WebAp.SelfHost
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string url = "http://localhost:10101";

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Web Server is running. Use brower URL: " + url);
                Console.WriteLine("Press any key to quit.");
                Console.ReadLine();
            }
        }
    }
}