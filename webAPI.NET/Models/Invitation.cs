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
		public int Id { get; set; }
		public string From { get; set; }
		public string To { get; set; }
		
		public string Server { get; set; }
	}
}
