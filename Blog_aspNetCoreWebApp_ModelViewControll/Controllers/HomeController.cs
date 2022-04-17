using Blog_aspNetCoreWebApp_ModelViewControll.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blog_aspNetCoreWebApp_ModelViewControll.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string url = "http://jsonplaceholder.typicode.com/posts";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(int page=1)
        {
            ViewBag.Page = page;
            int pageSize = 5;
            try
            {
                List<Post> posts = new List<Post>();
                using(HttpClient client =new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.GetAsync(url+ $"?_page={page}&_limit={pageSize}");
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        posts = JsonSerializer.Deserialize<List<Post>>(json);
                        ViewBag.TotalPages = (int)Math.Ceiling(
                            Convert.ToInt32(response.Headers.GetValues("X-Total-Count").ToArray()[0]) / (double)pageSize);
                    }
                }
                return View(posts);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
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
    }
}
