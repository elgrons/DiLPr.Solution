using Microsoft.AspNetCore.Mvc;
using DiLPr.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace DiLPr.Controllers
{
  public class TagsController : Controller
  {
    private readonly DiLPrContext _db;

    public TagsController(DiLPrContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Tags.ToList());
    }

    public ActionResult Details(int id)
    {
      Tag thisTag = _db.Tags
          .Include(tag => tag.JoinEntities)
          .ThenInclude(join => join.Profile)
          .FirstOrDefault(tag => tag.TagId == id);
      return View(thisTag);
    }

    [Authorize]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Tag tag)
    {
      if (!ModelState.IsValid)
      {
        return View(tag);
      }
      else
      {
        _db.Tags.Add(tag);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    [Authorize]
    public ActionResult AddProfile(int id)
    {
      Tag thisTag = _db.Tags.FirstOrDefault(tags => tags.TagId == id);
      ViewBag.ProfileId = new SelectList(_db.Profiles, "ProfileId", "Name");
      return View(thisTag);
    }

    [HttpPost]
    public ActionResult AddProfile(Tag tag, int profileId)
    {
#nullable enable
      TagProfile? joinEntity = _db.TagProfiles.FirstOrDefault(join => (join.ProfileId == profileId && join.TagId == tag.TagId));
#nullable disable
      if (joinEntity == null && profileId != 0)
      {
        _db.TagProfiles.Add(new TagProfile() { ProfileId = profileId, TagId = tag.TagId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = tag.TagId });
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      TagProfile join = _db.TagProfiles.FirstOrDefault(join => join.TagProfileId == joinId);
      // int profileId = join.ProfileId;
      _db.TagProfiles.Remove(join);
      _db.SaveChanges();
      return RedirectToAction("Index", "Profiles");
    }
  }
}