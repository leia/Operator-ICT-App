using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT_Operator_App.DTO {
  public class SongResponse {
    public int Id { get; set; }
    public string SongName { get; set; }
    public short BPM { get; set; }
    public string ArtistName { get; set; }
    public AlbumShort Album { get; set; }
  }

  public class ArtistShort {
    public int Id { get; set; }
    public string ArtistName { get; set; }
  }

  public class AlbumShort {
    //public int Id { get; set; }
    public string AlbumName { get; set; }
    public int Year { get; set; }
  }
}
