namespace DiLPr.Models;

public class Profile
{
  public int ProfileId { get; set; }
  public AppUser User { get; set; }
  public string Details { get; set; }
}