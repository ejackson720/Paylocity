using App.Endpoints.Interfaces;
using App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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

        public async Task<string> SubmitToApiWithID()
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri("https://localhost:7001/api/Tests/{1}");
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

        public async Task<string> CalculateBenefits(EmployeeDependents employeeBenefits)
        {
            try
            {
                var uri = new Uri("https://localhost:7001/api/Benefits/Calculate");

                //var content = new StringContent(JsonConvert.SerializeObject(employeeBenefits), Encoding.UTF8, "application/json");
                //var result = client.PostAsync(uri, content).Result;

                using (var client = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(employeeBenefits), Encoding.UTF8, "application/json");
                    var result = client.PostAsync(uri, content).Result;
                                     


                    if (result.IsSuccessStatusCode)
                    {
                        var rawString = result.Content.ReadAsStringAsync().Result;
                        var hereItIs = JsonConvert.DeserializeObject<string>(rawString);
                        return hereItIs;
                    }

                    return "fail";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
