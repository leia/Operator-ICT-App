using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ICT_Operator_App;
using ICT_Operator_App.Model;
using Microsoft.AspNetCore.Authorization;
using ICT_Operator_App.DTO;
using ICT_Operator_App.Repositories;

namespace ICT_Operator_App.Controllers {
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class AlbumsController : ControllerBase {
    private readonly MusicCatalogDbContext _context;
    private IAlbumRepository albumRepository;
    public AlbumsController(MusicCatalogDbContext context) {
      _context = context;
      albumRepository = new AlbumRepository(context);
    }

    // GET: api/Albums
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AlbumResponse>>> GetAlbums() {
      return await albumRepository.GetAlbumsAsync();
    }

    // GET: api/Albums/5
    [HttpGet("{id}")]
    public async Task<ActionResult<AlbumResponse>> GetAlbumAsync(int id) {
      var album = await albumRepository.GetAlbumByIdAsync(id);
      if (album == null) {
        return NotFound();
      }
      return album;
    }

    // PUT: api/Albums/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAlbum(int id, AlbumRequest request) {
      if (id != request.Id) {
        return BadRequest();
      }
      try {
        await albumRepository.UpdateAlbumAsync(id, request);
      }
      catch (DbUpdateConcurrencyException) {
        if (!AlbumExists(id)) {
          return NotFound();
        }
        else {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Albums
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<AlbumResponse>> PostAlbum(AlbumRequest request) {
      var album = await albumRepository.CreateAlbumAsync(request);
      request.Id = album.Id;
      return CreatedAtAction("GetAlbum", new { id = album.Id }, album);
    }

    // DELETE: api/Albums/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Album>> DeleteAlbum(int id) {
      var album = await albumRepository.DeleteAlbumAsync(id);
      if (album == null) {
        return NotFound();
      }
      return album;
    }

    private bool AlbumExists(int id) {
      return _context.Albums.Any(e => e.Id == id);
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
