using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Physician_aspNetCoreWebApp_ModelViewControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Physician_aspNetCoreWebApp_ModelViewControl.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly string baseUrl;
        private readonly string appJson;
        private readonly string baseUrlValue = "BaseUrl";
        private readonly string appJsonValue = "AppJson";
        private readonly string separateUrl = "/";
        private readonly string physicians = "physicians";
        private readonly string cantFind = "doctor";
        private readonly string viewError = "Error";
        private readonly string unable2Find = "Unable to find ";
        private readonly string unableId = " with id = ";
        public DoctorsController(IConfiguration configuration)
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
        private Task<HttpResponseMessage> responseMessage(HttpClient client, string urlLink, StringContent content)
        {
            responseMessage(client);
            return client.PostAsync(urlLink, content);
        }
        private Task<HttpResponseMessage> responseMessage(HttpClient client, string urlLink, StringContent content, int id)
        {
            responseMessage(client);
            return client.PutAsync(urlLink + separateUrl + id, content);
        }
        private Task<HttpResponseMessage> responseMessage(HttpClient client, string urlLink, int id)
        {
            client.BaseAddress = new Uri(baseUrl);
            return client.DeleteAsync(urlLink + separateUrl + id);
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
        private async Task<Doctor> GetAsync(int id)
        {
            Doctor doctor = new Doctor();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await responseMessage(client, physicians + separateUrl + id);
                    if (response.IsSuccessStatusCode)
                        doctor = JsonSerializer.Deserialize<Doctor>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
            }
            return doctor;
        }
        private async Task<ActionResult> Views(Doctor doctor, bool method, string urlLink, int id)
        {
            try
            {
                List<Doctor> doctors = new List<Doctor>();
                if (ModelState.IsValid)
                {
                    var content = method ? new StringContent(JsonSerializer.Serialize(doctor), Encoding.UTF8, appJson) : null;
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = method ? (id == -1 ? await responseMessage(client, urlLink, content)
                            : await responseMessage(client, urlLink, content, id))  //method ? (create, edit) : (index, delete)
                            : (id == -1 ? await responseMessage(client, urlLink) : await responseMessage(client, urlLink, id));
                        if (!method && id < 0)
                        {
                            if (response.IsSuccessStatusCode)
                                doctors = JsonSerializer.Deserialize<List<Doctor>>(await response.Content.ReadAsStringAsync());
                            else return Error(response, null);
                        }
                        if (!response.IsSuccessStatusCode) return Error(response, null);
                    }
                    if (!method && id < 0) return View(doctors);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Error(null, ex);
            }
        }
        // GET: DoctorsController
        public async Task<ActionResult> Index() => await Views(null, false, physicians, -1);
        // GET: DoctorsController/Details/5
        public async Task<ActionResult> Details(int id)
            => (await GetAsync(id)).physicianId == 0 ? Error(id + "", cantFind) : View(await GetAsync(id));
        // GET: DoctorsController/Create
        public ActionResult Create() => View();
        // POST: DoctorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Doctor doctor) => await Views(doctor, true, physicians, -1);
        // GET: DoctorsController/Edit/5
        public async Task<ActionResult> Edit(int id)
            => (await GetAsync(id)).physicianId == 0 ? Error(id + "", cantFind) : View(await GetAsync(id));
        // POST: DoctorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Doctor doctor) => await Views(doctor, true, physicians, id);
        // GET: DoctorsController/Delete/5
        public async Task<ActionResult> Delete(int id)
            => (await GetAsync(id)).physicianId == 0 ? Error(id + "", cantFind) : View(await GetAsync(id));
        // POST: DoctorsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection) => await Views(null, false, physicians, id);
    }
}
