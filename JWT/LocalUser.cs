using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ICT_Operator_App.Model.JWTAuth {
  public class LocalUser {
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Username { get; set; }

    [Required]
    public string Salt { get; set; }
    [Required]
    [JsonIgnore]
    public string HashedPassword { get; set; }
  }
}
