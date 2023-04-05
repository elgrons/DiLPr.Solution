using System.Security.Claims;

namespace DiLPr.Models;


  // {
  //       string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
  //       ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
  //       Profile newProfile = new Profile();
  //       newProfile.User = currentUser;
  //       _db.Profiles.Add(item);
  //       _db.SaveChanges();
  //   return RedirectToAction("Index");
  // }






public class Profile
{
  public int ProfileId { get; set; }
  public AppUser User { get; set; }
  public string Name { get; set; }
  public string Breed { get; set; }
  public int Age { get; set; }
  public string Details { get; set; }
  public List<TagProfile> JoinEntities { get; set; }
  public List<Image> Pictures { get; set; } 
}


// Image table
// imageId:
// imageBytes lalalala
// userId: