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
	public class SongRepository : ISongRepository
	{

		private MusicCatalogDbContext dbContext;
		public SongRepository(MusicCatalogDbContext context)
		{
			this.dbContext = context;
		}

		public async Task<Song> CreateSongAsync(SongRequest request)
		{
			var song = ObjectHelper.GetSongDb(request, dbContext);
			dbContext.Songs.Add(song);
			//CheckAlbum(song);
			await dbContext.SaveChangesAsync();
			return song;
		}

		public async Task<Song> DeleteSongAsync(int id)
		{
			var song = await dbContext.Songs.FindAsync(id);
			if (song == null)
			{
				return null;
			}

			dbContext.Songs.Remove(song);
			await dbContext.SaveChangesAsync();

			return song;
		}

		public async Task<SongResponse> GetSongByIdAsync(int id)
		{
			var song = await dbContext.Songs.Include(s => s.Album).ThenInclude(a => a.Artist).FirstOrDefaultAsync(s => s.Id == id);

			if (song == null)
			{
				return null;
			}

			return ObjectHelper.GetSongResponse(song);
		}

		public async Task<ActionResult<IEnumerable<SongResponse>>> GetSongsAsync()
		{
			return await dbContext.Songs.Include(s => s.Album).ThenInclude(a => a.Artist).Select(s => ObjectHelper.GetSongResponse(s)).ToListAsync();
		}

		public async Task UpdateSongAsync(int id, SongRequest request)
		{
			var song = ObjectHelper.GetSongDb(request, dbContext);
			dbContext.Entry(song).State = EntityState.Modified;
			//CheckAlbum(song);

			await dbContext.SaveChangesAsync();
		}
	}
}
