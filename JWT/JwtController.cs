using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ICT_Operator_App.Model.JWTAuth;
using ICT_Operator_App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;

namespace ICT_Operator_App.JWT
{
	[Route("api/[controller]")]
	[ApiController]
	public class JwtController : ControllerBase
	{
		private IConfiguration _config;
		private MusicCatalogDbContext _context;

		public JwtController(IConfiguration config, MusicCatalogDbContext context)
		{
			_config = config;
			_context = context;
		}

		[HttpGet]
		public string UserLogin(string email, string password)
		{
			var jwt = new JwtService(_config);
			var token = jwt.GenerateSecurityToken(email);

			return CanBeLoggedIn(email, password) ? token : "";
		}

		private bool CanBeLoggedIn(string email, string password)
		{
			LocalUser lc = _context.LocalUsers.ToArrayAsync().Result.First(u => u.Username.Equals(email, StringComparison.OrdinalIgnoreCase));
			var stringToSecure = new StringBuilder(password).Append(lc.Salt).ToString();
			byte [] bytesToSecure = Convert.FromBase64String(stringToSecure);
			var securedPassword = Convert.ToBase64String(SHA512.Create().ComputeHash(bytesToSecure));

			return securedPassword.Equals(lc.HashedPassword);
		}
	}
}