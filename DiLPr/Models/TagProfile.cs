namespace DiLPr.Models
{
  public class TagProfile
  {
    public int TagProfileId { get; set; }
    public int TagId { get; set; }
    public int ProfileId { get; set; }
    public Tag Tag { get; set; }
    public Profile Profile { get; set; }
  }
}