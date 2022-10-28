using B.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;

namespace B.Controllers
{
    public class HomeController : Controller
    {
        //static HttpClient _httpClient = new HttpClient();
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IEnumerable<DivisionModel>> GetData()
        {
            var httpClient = _httpClientFactory.CreateClient();

            string url = $"{Settings.ApiRoot}/v1/division";

            var response = await httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<IEnumerable<DivisionModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<DivisionModel>();

            return data;
        }
    }
}