using System;
using System.Net;
using System.Text;

namespace Server {
    class Program {
        static void Main(string[] args) {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8000/");
            listener.Start();

            while (true) {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest req = context.Request;
                HttpListenerResponse res = context.Response;
                if (req.HttpMethod == "GET" && req.RawUrl == "/myget") {
                    Console.WriteLine("Received request!");

                    //res.ContentType = "application/text";
                    //res.StatusCode = 200;

                    string responseMsg = "Message from server!";

                    res.OutputStream.Write(Encoding.UTF8.GetBytes(responseMsg), 0, Encoding.UTF8.GetByteCount(responseMsg));
                    res.Close();
                }
            }
        }
    }
}
