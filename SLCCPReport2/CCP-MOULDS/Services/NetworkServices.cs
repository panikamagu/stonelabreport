using CCP_MOULDS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Diagnostics;

namespace CCP_MOULDS.Services
{
    public class NetworkServices
    {
        public static async Task<List<DeliveryCost>> GetDistance()
        {



            using (var client = new HttpClient())
            {
                try
                {

                    const string baseUrl = "http://ccp-info.com";
                    string function = "/APIDeliveryCost/api/DeliveryCost/getdata";

                    client.BaseAddress = new Uri(baseUrl);
                    var response = await client.GetAsync(function);  // Get http method
                    response.EnsureSuccessStatusCode();

                    var stringResponse = await response.Content.ReadAsStringAsync();
                    List<DeliveryCost> result = JsonConvert.DeserializeObject<List<DeliveryCost>>(stringResponse);

                    return result;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request exception: {e.Message}");
                }
            }
            return null;
        }
    }
}