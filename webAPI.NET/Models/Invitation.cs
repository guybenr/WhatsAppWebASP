using System.ComponentModel.DataAnnotations;

namespace webAPI.NET.Models
{
	public class Invitation
	{
		public Invitation(string from, string to, string server)
		{
			From = from;
			To = to;
			Server = server;
		}

		[Key]
		[Required]
		public int Id { get; set; }
		[Required]
		public string From { get; set; }
		[Required]
		public string To { get; set; }
		[Required]
		public string Server { get; set; }
	}
}
