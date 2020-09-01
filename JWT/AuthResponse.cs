using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT_Operator_App.Model.JWTAuth
{
	public class AuthResponse
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Username { get; set; }
		public string Token { get; set; }


		public AuthResponse(LocalUser user, string token)
		{
			Id = user.Id;
			FirstName = user.FirstName;
			LastName = user.LastName;
			Username = user.Username;
			Token = token;
		}
	}
}
