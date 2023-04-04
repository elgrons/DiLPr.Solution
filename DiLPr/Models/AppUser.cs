using Microsoft.AspNetCore.Identity;

namespace DiLPr.Models
{
  public class AppUser : IdentityUser
  {
    public int ProfileId {get;set;}
    public Profile Profile {get;set;}
  }
}