using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICT_Operator_App.DTO {
  public class ArtistRequest {
    [Required]
    public int Id { get; set; }
    [Required]
    public string ArtistName { get; set; }
  }
}
