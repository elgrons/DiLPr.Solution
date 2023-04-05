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

    public IActionResult Index()
    {
        ViewBag.Profiles = _db.Profiles.ToList();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
