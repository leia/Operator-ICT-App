using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICT_Operator_App.Model {
  public class Tag {

    public Tag() {
      this.SongsTags = new List<SongTag>();
    }
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public IList<SongTag> SongsTags { get; set; }
  }
}
