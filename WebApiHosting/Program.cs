using DataModel;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiHosting
{
    public class Program
    {
        private static IDisposable _hosting;
        private static string baseAddress = "http://localhost:9000/";

        static void Main()
        {
            _hosting = WebApp.Start<Startup>(url: baseAddress);

            Console.WriteLine("API Hosting successfully started! Waiting for the requests...");
            //HttpClient client = new HttpClient();

            //Taxi taxi = new Taxi() { Id = 1, CarBrand = "Toyota", CarModel = "Camry", PassengerSeats = 4, UsedFrom = new DateTime(2004, 4, 13) };
            ////client.PostAsync<Taxi>(baseAddress + "api/taxis", taxi, GlobalConfiguration.Configuration.Formatters.JsonFormatter);

            //var response = client.GetAsync(baseAddress + "api/taxis").Result;

            //Console.WriteLine(response);
            //Console.WriteLine(response.Content.ReadAsStringAsync().Result);

            Console.ReadLine();
        }

        ~Program()
        {
            _hosting.Dispose();
        }
    }
}
