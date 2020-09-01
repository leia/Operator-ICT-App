using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICT_Operator_App.DTO
{
	public class AlbumRequest
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string AlbumName { get; set; }
		public int Year { get; set; }
		[Required]
		public int ArtistId { get; set; }
	}
}
