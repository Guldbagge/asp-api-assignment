using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Web.Helpers;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    { 
        using var http = new HttpClient();
        var response = await http.GetAsync("https://localhost:7026/api/courses");
        var json = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<IEnumerable<CourseEntity>>(json);
   
        return View(data);
    }

    [Route("/Details")]
    public async Task<IActionResult> Details()
    {
        using var http = new HttpClient();
        var response = await http.GetAsync($"https://localhost:7026/api/courses/1");
        var json = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<CourseEntity>(json);
        return View(data);
    }


    [Route("/Subscribe")]
    public IActionResult Subscribe()
    {
        ViewData["Subscribe"]=false;
        return View();
    }

    [Route("/Subscribe")]
    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscriberEntity model)
    {
        if (ModelState.IsValid)
        {
            using var http = new HttpClient();

            var json = JsonConvert.SerializeObject(model);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await http.PostAsync($"https://localhost:7026/api/subscribers?email={model.Email}", content);

            if (response.IsSuccessStatusCode)
            {
                ViewData["Subscribe"]=true;
            }

        }

        return View();
    }

}
