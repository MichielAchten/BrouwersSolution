using BrouwersClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BrouwersClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //PUT
            //Console.Write("Tik een id: ");
            //var id = int.Parse(Console.ReadLine());
            //var client = new HttpClient();
            //var url = "http://localhost:10216/brewers/" + id;
            //var response = client.GetAsync(url).Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    var brouwer = response.Content.ReadAsAsync<Brouwer>().Result;
            //    brouwer.Gemeente = brouwer.Gemeente.ToUpper();
            //    response = client.PutAsJsonAsync<Brouwer>("http://localhost:10216/api/brouwers/" + id, brouwer).Result;
            //    if (!response.IsSuccessStatusCode)
            //    {
            //        Console.WriteLine("Er is een fout opgetreden: " + response.StatusCode);
            //    }
            //}

            //POST
            var brouwer = new Brouwer();
            Console.Write("Naam: ");
            brouwer.Naam = Console.ReadLine();
            Console.Write("Postcode: ");
            brouwer.Postcode = int.Parse(Console.ReadLine());
            Console.Write("Gemeente: ");
            brouwer.Gemeente = Console.ReadLine();
            var client = new HttpClient();
            var response = client.PostAsJsonAsync<Brouwer>("http://localhost:10216/brewers/", brouwer).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("URL nieuwe brouwer: " + response.Headers.Location);
            }
            else
            {
                Console.WriteLine("Probleem bij toevoegen brouwer:" + response.StatusCode);
            }

            ////DELETE
            //const string serviceURI = "http://localhost:10216/api/brouwers";
            ////door een fout met de aangepaste URI kan er bij DELETE en PUT niet gewerkt worden met "brewers", wel met "api/brouwers"
            //Console.Write("Tik een id:");
            //var id = int.Parse(Console.ReadLine());
            //var client = new HttpClient();
            //var response = client.DeleteAsync(serviceURI + "/" + id).Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    response = client.GetAsync("http://localhost:10216/brewers").Result;
            //    var brouwers = response.Content.ReadAsAsync<Brouwers>().Result;
            //    brouwers.ForEach(beknopt => Console.WriteLine(beknopt.ID + ":" + beknopt.Naam));
            //}
            //else
            //{
            //    Console.WriteLine("Kan brouwer niet verwijderen");
            //}

            ////GET
            //var client = new HttpClient();
            //var response = client.GetAsync("http://localhost:10216/brewers").Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    var brouwers = response.Content.ReadAsAsync<Brouwers>().Result;
            //    brouwers.ForEach(beknopt => Console.WriteLine(beknopt.ID + ":" + beknopt.Naam));
            //    Console.WriteLine("Kies een id:");
            //    int id = int.Parse(Console.ReadLine());
            //    foreach (var brouwerBeknopt in brouwers)
            //    {
            //        if (brouwerBeknopt.ID == id)
            //        {
            //            response = client.GetAsync(brouwerBeknopt.Detail).Result;
            //            if (response.IsSuccessStatusCode)
            //            {
            //                var brouwer = response.Content.ReadAsAsync<Brouwer>().Result;
            //                Console.WriteLine(brouwer.Postcode + " " + brouwer.Gemeente);
            //                break;
            //            }
            //            else
            //            {
            //                Console.WriteLine("Brouwer niet meer gevonden");
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Brouwers niet gevonden");
            //}

            Console.WriteLine("Druk op enter om het programma te stoppen");
            Console.ReadLine();
        }
    }
}
