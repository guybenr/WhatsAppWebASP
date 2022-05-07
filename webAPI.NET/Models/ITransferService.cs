namespace webAPI.Models
{
    public interface ITransferService
    {
        bool Add(Transfer transfer)
        {
            String from = transfer.From;
            String to = transfer.To;
            String contect = transfer.Content;
            IContactService contactService = new ContactService();
            if (from == null || to == null || contactService.Get(from) == null || contactService.Get(to) == null)
            {
                return false;
            }
            IMessageService messageService = new MessageService();
            messageService.Add(from, )
            return true;
        }
    }
}
