using ICT_Operator_App.DTO;
using ICT_Operator_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT_Operator_App.Helpers
{
	public class ObjectHelper
	{
		public static Song GetSongDb(SongRequest request, MusicCatalogDbContext context)
		{
			return new Song {
				Id = request.Id,
				SongName = request.SongName,
				BPM = request.BPM,
				Album = context.Albums.Find(request.AlbumId)
			};
		}

		public static SongResponse GetSongResponse(Song dbObject)
		{
			return new SongResponse {
				Id = dbObject.Id,
				SongName = dbObject.SongName,
				BPM = dbObject.BPM,
				Album = dbObject.Album != null ? new AlbumShort { AlbumName = dbObject.Album.AlbumName, Year = dbObject.Album.Year } : null,
				ArtistName = dbObject.Album != null ? (dbObject.Album.Artist != null ? dbObject.Album.Artist.ArtistName : string.Empty) : string.Empty,
			};
		}

		public static Artist GetArtistDb(ArtistRequest request, MusicCatalogDbContext context)
		{
			return new Artist {
				Id = request.Id,
				ArtistName = request.ArtistName
			};
		}

		public static ArtistResponse GetArtistResponse(Artist dbObject)
		{
			return new ArtistResponse {
				Id = dbObject.Id,
				ArtistName = dbObject.ArtistName,
				Albums = dbObject.Albums != null ? dbObject.Albums.ToList() : null
			};
		}

		public static Album GetAlbumDb(AlbumRequest request, MusicCatalogDbContext context)
		{
			return new Album {
				Id = request.Id,
				Year = request.Year,
				AlbumName = request.AlbumName,
				Artist = context.Artists.Find(request.ArtistId)
			};
		}

		public static AlbumResponse GetAlbumResponse(Album dbObject)
		{
			return new AlbumResponse {
				Id = dbObject.Id,
				AlbumName = dbObject.AlbumName,
				Year = dbObject.Year,
				ArtistName = dbObject.Artist != null ? dbObject.Artist.ArtistName : string.Empty,
				Songs = dbObject.Songs
			};
		}
	}
}
