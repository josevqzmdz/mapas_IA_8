using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http;

namespace mapas_IA_8
{
    public class JSONParser
    {
        public string jsonString { get; set; }

        public string url = "http://127.0.0.1:5173";
        // public string url = "http://localhost:3000";

        // IEnumerable como dynamic
        // https://stackoverflow.com/questions/6624811/how-to-pass-anonymous-types-as-parameters
        public IEnumerable<dynamic> json { get; set; }
        public static readonly HttpClient client = new HttpClient();
        public JSONParser(IEnumerable<dynamic> json)
        {
            this.json = json;
            //client.BaseAddress = new Uri("http://127.0.0.1:5173/");
            
        }

        public JSONParser()
        {

        }

        // https://www.tutorialsteacher.com/webapi/consume-web-api-post-method-in-aspnet-mvc
        [HttpPost]
        public async Task postHtml()
        {
            /*
            try
            {
                
                foreach (var n in )
                {
                    Console.WriteLine($"De {n.Item1.nombre} hasta {n.Item2.nombre} : {n.Item3}");
                }

                var jsonString = JsonSerializer.Serialize(json);

                // https://stackoverflow.com/questions/9145667/how-to-post-json-to-a-server-using-c
                //var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                using HttpResponseMessage response = await client.GetAsync(url);

                //http  WebRequest.Method = "POST";

                //httpWebRequest.ContentType = "application/json";

                //string responseBody = await response.Content.ReadAsStringAsync(json);
                /*

                using (var stream = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    await stream.WriteAsync(jsonString);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }

            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }*/

        }
    }
}
