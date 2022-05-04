namespace webAPI.Models
{
    public class ContactService : IContactService
    {
        private static List<Contact> _contacts = new List<Contact>()
        {
            new Contact("adi", "adi aviv", "localhost:5000", "hello" , DateTime.Now),
            new Contact("guy", "guy aviv", "localhost:5000", "by by" , DateTime.Now)
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
            contact.Server = newContact.Server;
            contact.LastDate = newContact.LastDate;
            contact.Last = newContact.Last;
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
