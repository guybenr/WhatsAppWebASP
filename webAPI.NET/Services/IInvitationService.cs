using webAPI.NET.Models;

namespace webAPI.NET.Services
{
	public interface IInvitationService
	{
		public Task<bool> Post(Invitation invitation);
	}
}
