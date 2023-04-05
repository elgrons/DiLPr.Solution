namespace DiLPr.Models;

public class Image
{
    public int ImageId { get; set; }
    public Profile Profile { get; set; } 
    public string Caption {get;set;}
    public string ImageTitle { get; set; }
    public byte[] ImageData { get; set; }
}