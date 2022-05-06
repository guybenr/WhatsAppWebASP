namespace webAPI.Models
{
    public class ContactService : IContactService
    {
        private static List<Contact> _contacts = new List<Contact>();
        private Contact _curContact;
        public ContactService()
        {
            Contact adi = new Contact("adi", "adi aviv", "localhost:5000", "hello", DateTime.Now, "adi123456789");
            Contact guy = new Contact("guy", "guy ben razon", "localhost:5000", "by by", DateTime.Now, "guy123456789");
            Contact or = new Contact("or", "or aviv", "localhost:5000", "hey sister", DateTime.Now, "or123456789");
            Contact eran = new Contact("eran", "eran haim", "localhost:5000", "my name is eran", DateTime.Now, "eran123456789");
            _contacts.Add(adi);
            _contacts.Add(guy);
            _contacts.Add(or);
            _contacts.Add(eran);
            _contacts[0].Contacts.Add(guy);
            _contacts[0].Contacts.Add(or);
            _curContact = adi;
        }
        
        public void Delete(string id)
        {
            _curContact.Contacts.Remove(_contacts.Find(x => x.Id == id));
        }

        public void Edit(string id, string newContact)
        {
            Contact contact = _contacts.Find(x => x.Id == id);
            _contacts.Find(x => x.Id == id).Name = newContact;
        }

        public void Add(string newContact)
        {
            Contact contant = _contacts.Find(x=>x.Id == newContact);
            if (contant != null)
            {
                _curContact.Contacts.Add(contant);
            }
        }

        public Contact Get(string id)
        {
            Contact contact = _contacts.Find(x => x.Id == id);
            return contact;
        }

        public List<Contact> GetAll()
        {
            return _curContact.Contacts;
        }

        public void setContact(Contact contact)
        {
            _curContact = contact;
        }

        public Contact getCurContact()
        {
            return _curContact;
        }

        public void addNewContact(string id)
        {
            _curContact.Contacts.Add(_contacts.Find(x => x.Id == id));
        }
    }
}
