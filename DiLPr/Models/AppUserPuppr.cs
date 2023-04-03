namespace DiLPr.Models
{
  public class AppUserPuppr
  {       
    public int AppUserPupprId { get; set; }
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public int PupprId { get; set; }
    public Puppr Puppr { get; set; }
    public bool Swipe { get; set; }
  }
}