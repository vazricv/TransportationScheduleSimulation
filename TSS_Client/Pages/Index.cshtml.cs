using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TSS_Data.Models;

namespace TSS_Client.Pages
{
    public class IndexModel : PageModel
    {
        static HttpClient client = null;

       // private readonly ILogger<IndexModel> _logger;

        public IEnumerable<StopStation> stops;
        public string ErrorMessage = null;
        public IndexModel()
        {
            // _logger = logger;
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44370/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        public async Task OnGet()
        {
            HttpResponseMessage response = await client.GetAsync("api/TSSSchedule");
            if(response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsAsync<IEnumerable<StopStation>>();
                if (results != null && results.Status == TaskStatus.RanToCompletion)
                    stops = results.Result;
                else
                    ErrorMessage = results.Exception.Message;
            }
            else
            {
                ErrorMessage = "Unexpected Exception\r\n" + response.RequestMessage;
            }
        }
    }
}
