using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DiLPr.Models;
using System.Linq;

namespace DiLPr.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DiLPrContext _db;


    public HomeController(ILogger<HomeController> logger, DiLPrContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        Random rand = new Random();   
        int toSkip = rand.Next(1, _db.Profiles.Count());
        var profiles =  _db.Profiles.OrderBy(x=>Guid.NewGuid()).Skip(toSkip).Take(5).ToList();
      
        ViewBag.Profiles = new Dictionary < string, Profile > ();
        foreach (Profile item in profiles)
        {
            if(item.ProfilePic != 0)
            {
                Image profilePic = _db.Images.First(entry=>entry.ImageId == item.ProfilePic);
                string fish = Convert.ToBase64String(profilePic.ImageData);

                ViewBag.Profiles.Add(fish, item);
            }
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}