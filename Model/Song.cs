using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ICT_Operator_App.Model {
  public class Song {

    public Song() {
      this.SongsTags = new List<SongTag>();
    }
    public int Id { get; set; }
    [Required]
    public string SongName { get; set; }
    public short BPM { get; set; }
    [NotMapped]
    [JsonIgnore]
    public Artist Artist { get; set; }    
    [Required]
    public Album Album { get; set; }
    public IList<SongTag> SongsTags { get; set; }
  }
}
