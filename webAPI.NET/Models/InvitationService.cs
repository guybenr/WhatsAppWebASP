namespace webAPI.Models
{
    public class InvitationService : IInvitationService
    {
        public bool Add(Invitation invitation)
        {
            String from = invitation.From;
            String to = invitation.To;
            IContactService contactService = new ContactService();
            if (from == null || to == null || contactService.Get(from) == null || contactService.Get(to) == null)
            {
                return false;
            }
            contactService.Get(from).Contacts.Add(to);
            contactService.Get(to).Contacts.Add(from);
            return true;
        }
    }
}
