using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ICT_Operator_App.Model
{

	public class Artist
	{
		private readonly MusicCatalogDbContext _context;

		public Artist(MusicCatalogDbContext context)
		{
			_context = context;
		}

		public Artist()
		{

		}

		public int Id { get; set; }
		[Required]
		public string ArtistName { get; set; }
		[NotMapped]
		public ICollection<object> Albums
		{
			get
			{
				if (_context != null)
				{
					return _context.Albums.Where(a => a.Artist.Id == Id).Select(a => new { a.AlbumName, a.Year }).ToList<object>();
				}
				return null;
			}
			set => Albums = value;
		}
	}
}
