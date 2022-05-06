namespace webAPI.Models
{
    public class ContactService : IContactService
    {
        private static List<Contact> _contacts = new List<Contact>()
        {
            new Contact("adi", "adi aviv", "localhost:5000", "hello" , DateTime.Now, "adi123456789"),
            new Contact("guy", "guy ben razon", "localhost:5000", "by by" , DateTime.Now, "guy123456789")
        };
        public ContactService()
        {

        }
        
        public void Delete(string id)
        {
            _contacts.Remove(_contacts.Find(x => x.Id == id));
        }

        public void Edit(string id, Contact newContact)
        {
            Contact contact = _contacts.Find(x => x.Id == id);
            contact.Name = newContact.Name; 
            contact.Password = newContact.Password;
            contact.Server = newContact.Server;
            contact.LastDate = newContact.LastDate;
            contact.Last = newContact.Last;
            contact.Messages = newContact.Messages;
            contact.Contacts = newContact.Contacts;
        }

        public void Add(Contact newContact)
        {
            _contacts.Add
                (newContact);   
        }

        public Contact Get(string id)
        {
            Contact contact = _contacts.Find(x => x.Id == id);
            return contact;
        }

        public List<Contact> GetAll()
        {
            return _contacts;
        }
    }
}
