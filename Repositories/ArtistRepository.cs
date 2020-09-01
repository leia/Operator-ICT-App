using ICT_Operator_App.DTO;
using ICT_Operator_App.Helpers;
using ICT_Operator_App.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT_Operator_App.Repositories
{
	public class ArtistRepository : IArtistRepository
	{

		private MusicCatalogDbContext _context;
		public ArtistRepository(MusicCatalogDbContext context)
		{
			this._context = context;
		}
		public async Task<Artist> CreateArtistAsync(ArtistRequest request)
		{
			var artist = ObjectHelper.GetArtistDb(request, _context);
			_context.Artists.Add(artist);

			await _context.SaveChangesAsync();

			request.Id = artist.Id;
			return artist;
		}

		public async Task<Artist> DeleteArtistAsync(int id)
		{
			var artist = await _context.Artists.FindAsync(id);
			if (artist == null)
			{
				return null;
			}

			_context.Artists.Remove(artist);
			await _context.SaveChangesAsync();

			return artist;
		}

		public async Task<ArtistResponse> GetArtistByIdAsync(int id)
		{
			var artist = await _context.Artists.FindAsync(id);

			if (artist == null)
			{
				return null;
			}

			return ObjectHelper.GetArtistResponse(artist);
		}

		public async Task<ActionResult<IEnumerable<ArtistResponse>>> GetArtistsAsync()
		{
			return await _context.Artists.Select(a => ObjectHelper.GetArtistResponse(a)).ToListAsync();
		}

		public async Task UpdateArtistAsync(int id, ArtistRequest request)
		{
			var artist = ObjectHelper.GetArtistDb(request, _context);
			_context.Entry(artist).State = EntityState.Modified;

			await _context.SaveChangesAsync();
		}
	}
}
