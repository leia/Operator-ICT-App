using ICT_Operator_App.DTO;
using ICT_Operator_App.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT_Operator_App.Repositories {
  interface ISongRepository {
    Task<ActionResult<IEnumerable<SongResponse>>> GetSongsAsync();
    Task<SongResponse> GetSongByIdAsync(int id);
    Task UpdateSongAsync(int id, SongRequest request);
    Task<Song> CreateSongAsync(SongRequest request);
    Task<Song> DeleteSongAsync(int id);
  }
}
