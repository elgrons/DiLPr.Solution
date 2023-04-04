namespace DiLPr.Models;

public class Image
{
    public int Id { get; set; }
    public int ProfileId {get;set;}
    public string ImageTitle { get; set; }
    public byte[] ImageData { get; set; }
}