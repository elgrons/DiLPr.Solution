using Microsoft.AspNetCore.Identity;

namespace DiLPr.Models
{
  public class AppUser : IdentityUser
  {
    public string Breed { get; set; }
    public int Age { get; set; }
  }
}