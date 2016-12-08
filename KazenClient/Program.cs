using KazenClasses;
using KazenService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KazenClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var kaas = new Kaas();
            Console.Write("Naam: ");
            kaas.Naam = Console.ReadLine();
            Console.Write("Type: ");
            kaas.Type = Console.ReadLine();
            Console.Write("Smaak: ");
            kaas.Smaak = Console.ReadLine();
            var client = new HttpClient();
            var url = "http://localhost:11295/api/kazen";
            var response = client.PostAsJsonAsync<Kaas>(url, kaas).Result;
            if (response.IsSuccessStatusCode)
            {
                response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var kazen = response.Content.ReadAsAsync<Kazen>().Result;
                    kazen.ForEach(beknopt => Console.WriteLine(beknopt.ID + ": " + beknopt.Naam));
                }
            }
            else
            {
                Console.WriteLine("Probleem bij toevoegen van de kaas: " + response.StatusCode);
            }

            Console.WriteLine("Druk op enter om het programma te stoppen");
            Console.ReadLine();
        }
    }
}
