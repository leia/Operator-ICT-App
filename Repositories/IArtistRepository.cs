using ICT_Operator_App.DTO;
using ICT_Operator_App.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT_Operator_App.Repositories {
  interface IArtistRepository {
    Task<ActionResult<IEnumerable<ArtistResponse>>> GetArtistsAsync();
    Task<ArtistResponse> GetArtistByIdAsync(int id);
    Task UpdateArtistAsync(int id, ArtistRequest Artist);
    Task<Artist> CreateArtistAsync(ArtistRequest request);
    Task<Artist> DeleteArtistAsync(int id);
  }
}
