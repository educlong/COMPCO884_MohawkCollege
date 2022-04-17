using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Northwind.Controllers
{
    public class ProductsController : Controller
    {
        private readonly string baseUrl;
        private readonly string appJson;
        private readonly string baseUrlValue = "BaseUrl";
        private readonly string appJsonValue = "AppJson";
        private readonly string separateUrl = "/";
        private readonly string products = "products";
        private readonly string productsByCategory = "ByCategory";
        private readonly string categories = "Categories";
        private readonly string cantFind = "product";
        private readonly string viewError = "Error";
        private readonly string unable2Find = "Unable to find ";
        private readonly string unableId = " with id = ";
        public ProductsController(IConfiguration configuration)
        {
            baseUrl = configuration.GetValue<string>(baseUrlValue);
            appJson = configuration.GetValue<string>(appJsonValue);
        }
        private void responseMessage(HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(appJson));
            client.BaseAddress = new Uri(baseUrl);
        }
        private Task<HttpResponseMessage> responseMessage(HttpClient client, string urlLink)
        {
            responseMessage(client);
            return client.GetAsync(urlLink);
        }
        private ActionResult Error(string id, string _object) => View(viewError, new ErrorViewModel
        {
            RequestId = id.ToString(),
            Description = unable2Find + _object + unableId + id
        });
        private ActionResult Error(HttpResponseMessage response, Exception ex) => View(viewError, new ErrorViewModel
        {
            RequestId = HttpContext.TraceIdentifier,
            Description = response == null ? ex.Message : response.StatusCode.ToString()
        });

        private async Task<List<Category>> GetCategoriesAsync()
        {
            List<Category> _categories = new List<Category>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await responseMessage(client, categories);
                    if (response.IsSuccessStatusCode)
                        _categories = JsonSerializer.Deserialize<List<Category>>(await response.Content.ReadAsStringAsync());
                }
            }
            catch(Exception ex)
            {
            }
            return _categories;
        }

        private async Task<Product> GetProductAsync(int id)
        {
            Product product = new Product();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await responseMessage(client, products + separateUrl + id);
                    if (response.IsSuccessStatusCode)
                    {
                        product = JsonSerializer.Deserialize<Product>(await response.Content.ReadAsStringAsync());
                        ViewBag.Category = (from _categories in await GetCategoriesAsync()
                                             where _categories.categoryId == product.categoryId
                                             select _categories).FirstOrDefault().categoryName;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return product;
        }
        private async Task<ActionResult> Views(string id)
        {
            try
            {
                List<Product> _products = new List<Product>();
                if (ModelState.IsValid)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        List<Category> _categories_ = await GetCategoriesAsync();
                        var categories = from _categories in _categories_
                                         select new { Name = _categories.categoryName, _categories.categoryId };
                        ViewBag.CategoryId = new SelectList(categories, "categoryId", "Name");
                        string link = products + separateUrl + productsByCategory + separateUrl + (!string.IsNullOrEmpty(id) ? id : 1);
                        ViewBag.Title = "Products: " +
                            (from category in _categories_
                             where category.categoryId == (!string.IsNullOrEmpty(id) ? Int32.Parse(id) : 1)
                             select category).FirstOrDefault().categoryName;
                        HttpResponseMessage response = await responseMessage(client, link);
                        if (response.IsSuccessStatusCode)
                            _products = JsonSerializer.Deserialize<List<Product>>(await response.Content.ReadAsStringAsync());
                        else return Error(response, null);
                    }
                    return View(_products);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Error(null, ex);
            }
        }

        // GET: DoctorsController
        public async Task<ActionResult> Index(string categoryId) => await Views(categoryId);
        // GET: DoctorsController/Details/5
        public async Task<ActionResult> Details(int id)
            => (await GetProductAsync(id)).productId == 0 ? Error(id + "", cantFind) : View(await GetProductAsync(id));
    }
}
