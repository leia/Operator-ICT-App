using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT_Operator_App.Model {
  public class SongTag {
    public int SongId { get; set; }
    public Song Song { get; set; }

    public int TagId { get; set; }
    public Tag Tag { get; set; }
  }
}
