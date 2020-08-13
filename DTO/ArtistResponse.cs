using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT_Operator_App.DTO {
  public class ArtistResponse {
    public int Id { get; set; }
    public string ArtistName { get; set; }
    public IList<object> Albums { get; set; }
  }
}
