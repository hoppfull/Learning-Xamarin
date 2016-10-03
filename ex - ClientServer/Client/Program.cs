using System;
using System.Net.Http;

namespace Client {
    class Program {
        static void Main(string[] args) {
            HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:8000/") };
            
            HttpResponseMessage res = client.GetAsync("/myget").Result;
            
            // This is case for when response is a string: (See more general example with byte[])
            string responseMsg = res.Content.ReadAsStringAsync().Result;

            Console.WriteLine(responseMsg);
        }
    }
}
