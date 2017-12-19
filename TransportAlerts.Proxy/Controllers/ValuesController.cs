using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace TransportAlerts.Proxy.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<byte[]> GetAsync()
        {
            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.RequestUri = new Uri("https://api.transport.nsw.gov.au/v1/gtfs/alerts/sydneytrains");
            httpRequestMessage.Headers.Add("Authorization", "apikey");

            var client = new HttpClient();

            var response = await client.SendAsync(httpRequestMessage);

            return await response.Content.ReadAsByteArrayAsync();
            
        }
    }
}
