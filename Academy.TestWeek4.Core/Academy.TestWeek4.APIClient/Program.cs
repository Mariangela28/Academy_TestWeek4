using Academy.TestWeek4.APIClient.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Academy.TestWeek4.APIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Test Week 4 - Test API ===");

            HttpClient client = new HttpClient();

            Console.WriteLine("Premi un tasto quando le API sono partite ...");
            Console.ReadKey();


            #region GET
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://localhost:44324/api/ordini")
            };

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<OrdiniContract>>(data);

                foreach (var item in result)
                {
                    Console.WriteLine($"[{item.ID}] " +
                        $"{item.CodiceOrdine} {item.CodiceProdotto.ToUpper()}");
                }
            }

            #endregion
        }

    }
}
