namespace DiLPr.Models;

public class Profile
{
  public int ProfileId { get; set; }
  //add user id? may not populate the user if not present
  public AppUser User { get; set; }
  public string Name { get; set; }
  public string Breed { get; set; }
  public int Age { get; set; }
  public string Details { get; set; }
}