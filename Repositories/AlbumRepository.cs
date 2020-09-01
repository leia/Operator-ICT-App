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
	public class AlbumRepository : IAlbumRepository
	{
		private MusicCatalogDbContext _context;
		public AlbumRepository(MusicCatalogDbContext context)
		{
			this._context = context;
		}

		public async Task<Album> CreateAlbumAsync(AlbumRequest request)
		{
			Album album = ObjectHelper.GetAlbumDb(request, _context);
			_context.Albums.Add(album);
			//CheckArtist(album);
			await _context.SaveChangesAsync();

			return album;
		}

		public async Task<Album> DeleteAlbumAsync(int id)
		{
			var album = await _context.Albums.FindAsync(id);
			if (album == null)
			{
				return null;
			}

			_context.Albums.Remove(album);
			await _context.SaveChangesAsync();

			return album;
		}

		public async Task<AlbumResponse> GetAlbumByIdAsync(int id)
		{
			var album = await _context.Albums
								  .Include(a => a.Artist)
								  .FirstOrDefaultAsync(a => a.Id == id);

			if (album == null)
			{
				return null;
			}

			return ObjectHelper.GetAlbumResponse(album);
		}

		public async Task<ActionResult<IEnumerable<AlbumResponse>>> GetAlbumsAsync()
		{
			return await _context.Albums
							.Include(a => a.Artist)
							.Select(s => ObjectHelper.GetAlbumResponse(s))
							.ToListAsync();
		}


		public async Task UpdateAlbumAsync(int id, AlbumRequest request)
		{
			var album = ObjectHelper.GetAlbumDb(request, _context);

			_context.Entry(album).State = EntityState.Modified;
			//CheckArtist(album);
			await _context.SaveChangesAsync();
		}
	}
}
