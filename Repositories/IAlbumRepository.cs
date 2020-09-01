using ICT_Operator_App.DTO;
using ICT_Operator_App.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT_Operator_App.Repositories
{
	interface IAlbumRepository
	{
		Task<ActionResult<IEnumerable<AlbumResponse>>> GetAlbumsAsync();
		Task<AlbumResponse> GetAlbumByIdAsync(int id);
		Task UpdateAlbumAsync(int id, AlbumRequest request);
		Task<Album> CreateAlbumAsync(AlbumRequest request);
		Task<Album> DeleteAlbumAsync(int id);
	}
}
