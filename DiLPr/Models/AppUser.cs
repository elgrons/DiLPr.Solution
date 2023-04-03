using Microsoft.AspNetCore.Identity;

namespace DiLPr.Models
{
  public class AppUser : IdentityUser
  {
    public int AppUserId { get; set; }
    public string Name { get; set; }
    public string Breed { get; set; }
    public string Detail { get; set; }
    public int Age { get; set; }
  }
}