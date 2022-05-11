using Microsoft.EntityFrameworkCore;
using webAPI.Models;
using webAPI.NET.Data;
using webAPI.NET.Models;

namespace webAPI.NET.Services
{
	public class InvitationService : IInvitationService
	{
		private readonly Context _context;
		private readonly IContactService _contactService;

		public InvitationService(Context context)
		{
			_context = context;
			_contactService = new ContactService(context);
		}

		public async Task<bool> Post(Invitation invitation)
		{
			return await _contactService.Post(invitation.To, invitation.From, invitation.Server);
		}
	}
}
