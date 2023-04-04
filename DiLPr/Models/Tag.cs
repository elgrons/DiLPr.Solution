using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiLPr.Models
{
  public class Tag
    {
        public int TagId { get; set; }
        [Required(ErrorMessage = "Please add a tag name!")]
        public string Name { get; set; }
        public List<TagProfile> JoinEntities { get;}
        public AppUser User { get; set; }
    }
}