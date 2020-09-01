using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICT_Operator_App.DTO
{
	public class SongRequest
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string SongName { get; set; }
		public short BPM { get; set; }
		[Required]
		public int AlbumId { get; set; }
	}
}
