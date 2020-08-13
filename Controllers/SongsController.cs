using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ICT_Operator_App.Model;
using Microsoft.AspNetCore.Authorization;
using ICT_Operator_App.DTO;
using ICT_Operator_App.Repositories;

namespace ICT_Operator_App.Controllers {
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class SongsController : ControllerBase {
    private readonly MusicCatalogDbContext _context;
    private ISongRepository songRepository;
    public SongsController(MusicCatalogDbContext context) {
      _context = context;
      this.songRepository = new SongRepository(context);
    }

    // GET: api/Songs
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SongResponse>>> GetSongs() {
      return await songRepository.GetSongsAsync();
    }

    

    // GET: api/Songs/5
    [HttpGet("{id}")]
    public async Task<ActionResult<SongResponse>> GetSong(int id) {
      var song = await songRepository.GetSongByIdAsync(id);
      if (song == null) {
        return NotFound();
      }
      return song;
    }

    // PUT: api/Songs/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSong(int id, SongRequest request) {
      if (id != request.Id) {
        return BadRequest();
      }

      try {
        await songRepository.UpdateSongAsync(id, request);
      }
      catch (DbUpdateConcurrencyException) {
        if (!SongExists(id)) {
          return NotFound();
        }
        else {
          throw;
        }
      }
      return NoContent();
    }

    

    // POST: api/Songs
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<SongRequest>> PostSong(SongRequest request) {
      var song = await songRepository.CreateSongAsync(request);
      request.Id = song.Id;
      return CreatedAtAction("GetSong", new { id = song.Id }, request) ;
    }

    // DELETE: api/Songs/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Song>> DeleteSong(int id) {
      var song = await songRepository.DeleteSongAsync(id);

      if (song == null)
        return NotFound();
      return song;
    }

    private bool SongExists(int id) {
      return _context.Songs.Any(e => e.Id == id);
    }

    private void CheckAlbum(Song s) {
      if (s.Album != null) {
        if (s.Album.Id == 0) {
          _context.Albums.Add(s.Album);
        }
        else {
          var album = _context.Albums.Find(s.Album.Id);
          _context.Entry(album).State = EntityState.Modified;
          //PUT
        }
        CheckArtist(s.Album);
      }
    }

    private void CheckArtist(Album a) {
      if (a.Artist != null) {
        if (a.Artist.Id == 0) {
          _context.Artists.Add(a.Artist);
        }
        else {
          var artist = _context.Artists.Find(a.Artist.Id);
          _context.Entry(artist).State = EntityState.Modified;
        }
      }
    }
  }
}

