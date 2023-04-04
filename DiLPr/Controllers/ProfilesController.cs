using Microsoft.AspNetCore.Mvc;
using DiLPr.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System;
using Microsoft.EntityFrameworkCore;

namespace DiLPr.Controllers
{
  public class ProfilesController : Controller
  {
    private readonly DiLPrContext _db;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    // private object db;

    public ProfilesController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, DiLPrContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }


    // public IActionResult UploadImage(int id)
    // {
    //   Profile targetProfile = 
    //   return View(targetProfile);
    // }

    [HttpPost]
    public IActionResult UploadImage()
    {
      foreach (var file in Request.Form.Files)
      {
        Image img = new Image();
        img.ImageTitle = file.FileName;

        MemoryStream ms = new MemoryStream();
        file.CopyTo(ms);
        img.ImageData = ms.ToArray();

        ms.Close();
        ms.Dispose();

        _db.Images.Add(img);
        _db.SaveChanges();
      }
      ViewBag.Message = "Image(s) stored in   database!";
    return View("Index");
    }
  }
}