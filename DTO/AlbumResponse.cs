using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT_Operator_App.DTO {
  public class AlbumResponse {
    public int Id { get; set; }
    public string AlbumName { get; set; }
    public int Year { get; set; }
    public string ArtistName { get; set; }
    public IList<string> Songs { get; set; }
  }
}
