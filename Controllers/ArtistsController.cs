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
using ICT_Operator_App.Helpers;

namespace ICT_Operator_App.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ArtistsController : ControllerBase
	{
		private readonly MusicCatalogDbContext _context;
		private IArtistRepository artistRepository;

		public ArtistsController(MusicCatalogDbContext context)
		{
			_context = context;
			artistRepository = new ArtistRepository(context);
		}

		// GET: api/Artists
		[HttpGet]
		public async Task<ActionResult<IEnumerable<ArtistResponse>>> GetArtists()
		{
			return await artistRepository.GetArtistsAsync();
		}

		// GET: api/Artists/5
		[HttpGet("{id}")]
		public async Task<ActionResult<ArtistResponse>> GetArtist(int id)
		{
			var artist = await artistRepository.GetArtistByIdAsync(id);
			if (artist == null)
			{
				return NotFound();
			}
			return artist;
		}

		// PUT: api/Artists/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutArtist(int id, ArtistRequest request)
		{
			if (id != request.Id)
			{
				return BadRequest();
			}

			try
			{
				await artistRepository.UpdateArtistAsync(id, request);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ArtistExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}



		// POST: api/Artists
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
		[HttpPost]
		public async Task<ActionResult<ArtistResponse>> PostArtist(ArtistRequest request)
		{
			var artist = await artistRepository.CreateArtistAsync(request);

			request.Id = artist.Id;
			return CreatedAtAction("GetArtist", new { id = artist.Id }, request);
		}



		// DELETE: api/Artists/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Artist>> DeleteArtist(int id)
		{
			var artist = await artistRepository.DeleteArtistAsync(id);
			if (artist == null)
			{
				return NotFound();
			}
			return artist;
		}

		private bool ArtistExists(int id)
		{
			return _context.Artists.Any(e => e.Id == id);
		}
	}
}
