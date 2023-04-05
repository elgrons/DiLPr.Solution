using System.Security.Claims;

namespace DiLPr.Models;
public class Profile
{
  public int ProfileId { get; set; }
  public AppUser User { get; set; }
  public string Name { get; set; }
  public string Breed { get; set; }
  public int Age { get; set; }
  public string Details { get; set; }
  //public Dictionary {profile id, bool}
  // 3, t..........4, f........5, t....
  // public  List<int> LikedProfiles { get; set; }
  // public List<int> DislikedProfiles { get; set; }
  public List<TagProfile> JoinEntities { get; set; }
  public List<Image> Pictures { get; set; } 
}


// Image table
// imageId:
// imageBytes lalalala
// userId:

// {
//       string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
//       ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
//       Profile newProfile = new Profile();
//       newProfile.User = currentUser;
//       _db.Profiles.Add(item);
//       _db.SaveChanges();
//   return RedirectToAction("Index");
// }