using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace App.Endpoints
{
    public class Endpoint :IEndpoint
    {
        public async Task<string> SubmitToApi()
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri("https://localhost:7001/api/Tests");
                //HTTP GET
                var responseTask = client.GetAsync(uri);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var rawString = result.Content.ReadAsStringAsync().Result;
                    var hereItIs = JsonConvert.DeserializeObject<List<string>>(rawString);
                    return hereItIs[0] + hereItIs[1];
                }

                return "fail";
            }
        }

        public async Task<string> CalculateBenefits()
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri("https://localhost:7001/api/Benefits");
                //HTTP GET
                var responseTask = client.PostAsync(uri);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var rawString = result.Content.ReadAsStringAsync().Result;
                    var hereItIs = JsonConvert.DeserializeObject<List<string>>(rawString);
                    return hereItIs[0] + hereItIs[1];
                }

                return "fail";
            }
        }


    }
}
