namespace DiLPr.Models
{
  public class ProfilePuppr
  {       
    public int ProfilePupprId { get; set; }
    public Profile Profile { get; set; }
    public Puppr Puppr { get; set; }
    public bool Swipe { get; set; }
  }
}