using Microsoft.AspNetCore.Mvc;
using DiLPr.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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


    public async Task<IActionResult> UploadImage(int id)
    {
      string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      AppUser user = await _userManager.FindByIdAsync(userId);
      Profile targetProfile = await _db.Profiles.FirstAsync(entry => entry.User == user);
      return View(targetProfile);
    }

    public async Task<ActionResult> Index()
    {
      string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      AppUser user = await _userManager.FindByIdAsync(userId);
      // Profile targetProfile = await _db.Profiles.FirstAsync(entry => entry.User == user);
      // return View(targetProfile);

      Profile thisProfile = await _db.Profiles
            .Include(profile => profile.JoinEntities)
            .ThenInclude(join => join.Tag)
            .FirstAsync(profile => profile.User == user);

      List<Image> imgList = _db.Images.Where(entry=> entry.Profile == thisProfile).ToList();
      ViewBag.Images = new Dictionary < int, string > ();
      int i = 0;
      foreach(Image img in imgList)
      {
        string imageBase64Data = Convert.ToBase64String(img.ImageData);
        // string imageDataURL = string.Format("data:image/jpg;base64", imageBase64Data);
        //specific to jpg?? need to figure out how to make applicable to others
        ViewBag.Images.Add(i,imageBase64Data);
        i++;
      }

      return View(thisProfile);
    }

    [HttpPost]
    public async Task<IActionResult> UploadImage()
    {
      string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      AppUser user = await _userManager.FindByIdAsync(userId);
      Profile currentProfile = await _db.Profiles.FirstAsync(entry => entry.User == user);      
      
      foreach (var file in Request.Form.Files)
      {
        
        //set the profileId attribute based on the previously defined profile object
        Image img = new Image();
        img.ImageTitle = file.FileName;
        img.Profile = currentProfile;

        MemoryStream ms = new MemoryStream();
        file.CopyTo(ms);
        img.ImageData = ms.ToArray();

        ms.Close();
        ms.Dispose();

        _db.Images.Add(img);
        _db.SaveChanges();
      }
      ViewBag.Message = "Image(s) stored in database!";
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Profile thisProfile = _db.Profiles.FirstOrDefault(profile => profile.ProfileId == id);
      return View(thisProfile);
    }

    [HttpPost]
    public ActionResult Edit(Profile profile)
    {
      _db.Profiles.Update(profile);
      _db.SaveChanges();
      return RedirectToAction("UploadImage", "Profiles");
    }

    public ActionResult Details(int id)
    {
      Profile thisProfile = _db.Profiles
            .Include(profile => profile.JoinEntities)
            .ThenInclude(join => join.Tag)
            .FirstOrDefault(profile => profile.ProfileId == id);

      List<Image> imgList = _db.Images.Where(entry=> entry.Profile == thisProfile).ToList();
      // List<Image> imgList = _db.Images.ToList();
      ViewBag.Images = new Dictionary < int, string > ();
      int i = 0;
      foreach(Image img in imgList)
      {
        string fish = Convert.ToBase64String(img.ImageData);
        // string imageDataURL = string.Format("data:image/jpg;base64", imageBase64Data);
        //specific to jpg?? need to figure out how to make applicable to others
        ViewBag.Images.Add(i,fish);
        i++;
      }
      
      return View(thisProfile);
    }

    public ActionResult AddTag(int id)
    {
      Profile thisProfile = _db.Profiles.FirstOrDefault(entry => entry.ProfileId == id);
      ViewBag.Tags = _db.Tags.ToList();
      return View(thisProfile);
    }
    
    [HttpPost]
    public ActionResult AddTag(List<int> tags, int profileId)
    {
      foreach (int tag in tags)
      {
        #nullable enable
        TagProfile? join = _db.TagProfiles.FirstOrDefault(entry => (entry.TagId == tag && entry.ProfileId == profileId));
        #nullable disable

        if (join == null && profileId != 0)
        {
          _db.TagProfiles.Add(new TagProfile() { TagId = tag, ProfileId = profileId});
          _db.SaveChanges();
        }
      }
      return RedirectToAction("Index");
    }

    /* */
  }
}