using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Web.Helpers;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    { 

   
        return View();
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

}
