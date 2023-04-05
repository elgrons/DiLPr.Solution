using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DiLPr.Models;

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

// foreach(Image img in imgList)
//       {
//         string fish = Convert.ToBase64String(img.ImageData);
//         // string imageDataURL = string.Format("data:image/jpg;base64", imageBase64Data);
//         //specific to jpg?? need to figure out how to make applicable to others
//         ViewBag.Images.Add(i,fish);
//         i++;
//       }
    public IActionResult Index()
    {
        var profiles =  _db.Profiles.ToList();
        ViewBag.Profiles = new Dictionary < string, Profile > ();
        foreach (Profile item in profiles)
        {
            #nullable enable
            Image? profilePic = _db.Images.First(entry=>entry.ImageId == item.ProfilePic);
            #nullable disable
            string fish = Convert.ToBase64String(profilePic.ImageData);
            ViewBag.Profiles.Add(fish, item);
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
