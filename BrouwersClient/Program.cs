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
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:53810/brewers").Result;
            if (response.IsSuccessStatusCode)
            {
                var brouwers = response.Content.ReadAsAsync<Brouwers>().Result;
                brouwers.ForEach(beknopt => Console.WriteLine(beknopt.ID + ":" + beknopt.Naam));
                Console.WriteLine("Kies een id:");
                int id = int.Parse(Console.ReadLine());
                foreach (var brouwerBeknopt in brouwers)
                {
                    if (brouwerBeknopt.ID == id)
                    {
                        response = client.GetAsync(brouwerBeknopt.Detail).Result;
                        //verder aanvullen
                    }
                }
            }
        }
    }
}
