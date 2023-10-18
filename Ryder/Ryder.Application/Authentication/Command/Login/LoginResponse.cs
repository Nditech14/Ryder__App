using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryder.Application.Authentication.Command.Login
{
	public class LoginResponse
	{
		public Guid UserId { get; set; }
		public string UserName { get; set; }
		public string FullName { get; set; }
		public string Token { get; set; } 
		public string UserRole { get; set; }
											 
	}



	//   public class LoginResponse
	//   {
	//       public Guid UserId { get; set; } // Unique identifier for the user
	//       public string UserName { get; set; } // User's username or email
	//       public string FullName { get; set; } // User's full name
	//       public string Token { get; set; } // Authentication token (JWT) for subsequent requests
	//	// Additional properties as needed (e.g., UserRole, UserEmail, etc.)
	//}
}
