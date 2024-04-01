using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace AngularSampleProject2.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller       
    {
        private const string urlStr = "https://backendapi20240329130408.azurewebsites.net";
        private readonly HttpClient _httpClient = new HttpClient();

        [HttpGet(template: "GetProducts", Name = "GetProducts")]
        public async Task<IActionResult> Get()           
        {
            try
            {
                var apiFirstTask = await _httpClient.GetAsync($"{urlStr}/Home/GetProductsFirst");
                var apiSecondTask =  await _httpClient.GetAsync($"{urlStr}/Home/GetProductsSecond");


                var first = apiFirstTask.Content.ReadAsStringAsync().Result;
                var second = apiSecondTask.Content.ReadAsStringAsync().Result;


                JArray productsArrayFirst = JArray.Parse(first);
                JArray productsArraySecond = JArray.Parse(second);

                productsArrayFirst.Merge(productsArraySecond, new JsonMergeSettings
                {
                    // union array values together to avoid duplicates
                    MergeArrayHandling = MergeArrayHandling.Union
                });

                return Ok(JsonConvert.DeserializeObject<List<Product>>(productsArrayFirst.ToString()));
            } 
            catch
            {
                return Json(new { status = "error", message = "error returning products" });
            }
        }
    }
}
