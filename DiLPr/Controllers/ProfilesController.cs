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

    public async Task<ActionResult> Index()
    { 
      string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      AppUser currentUser = await _userManager.FindByIdAsync(userId);
      if (currentUser != null)
      {
        return View(currentUser);
      }
      return View();

      // AppUser user = ;
      // Profile thisProfile = _db.Profiles
      //   .Where(e => e.User.UserName == user.UserName)
      // return View();
    }

    // public ActionResult Details(int id)
    // {
    //   ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "MachineName");
    //   Engineer thisEngineer = _db.Engineers
    //       .Include(engineer => engineer.JoinEntities)
    //       .ThenInclude(join => join.Machine)
    //       .FirstOrDefault(engineer => engineer.EngineerId == id);
    //   return View(thisEngineer);
    // }

    // public ActionResult Edit(int id)
    // {
    //   Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
    //   return View(thisEngineer);
    // }

    // [HttpPost]
    // public ActionResult Edit(Engineer engineer)
    // {
    //   if (!ModelState.IsValid)
    //   {
    //     return View(engineer);
    //   }
    //   else
    //   {
    //     _db.Engineers.Update(engineer);
    //     _db.SaveChanges();
    //     return RedirectToAction("Index");
    //   }
    // }

    // public ActionResult Delete(int id)
    // {
    //   Profile thisProfile = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
    //   return View(thisEngineer);
    // }

    // [HttpPost, ActionName("Delete")]
    // public ActionResult DeleteConfirmed(int id)
    // {
    //   Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
    //   _db.Engineers.Remove(thisEngineer);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // [HttpPost]
    // public ActionResult DeleteJoin(int joinId)
    // {
    //   EngineerMachine joinEntry = _db.EngineerMachines.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
    //   _db.EngineerMachines.Remove(joinEntry);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
  }
}