using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ICT_Operator_App.Model
{
	public class Album
	{
		private readonly MusicCatalogDbContext _context;

		public Album()
		{

		}

		public Album(MusicCatalogDbContext context)
		{
			_context = context;
		}

		public int Id { get; set; }
		[Required]
		public string AlbumName { get; set; }
		[Required]
		public int Year { get; set; }
		[Required]
		public Artist Artist { get; set; }
		[NotMapped]
		public IList<string> Songs
		{
			get => _context != null ? _context.Songs.Where(s => s.Album.Id == Id).Select(s => s.SongName).ToList() : null;
			set => Songs = value;
		}
	}
}
