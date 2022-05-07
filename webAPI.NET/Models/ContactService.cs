namespace webAPI.Models
{
    public class ContactService : IContactService
    {
        public static List<Contact> _contacts = new List<Contact>();
        private static Contact _curContact;
        public ContactService()
        {
            if (_contacts.Count == 0)
            {
                Contact adi = new Contact("adi", "adi aviv", "localhost:5000", "hello", DateTime.Now, "adi123456789");
                Contact guy = new Contact("guy", "guy ben razon", "localhost:5000", "by by", DateTime.Now, "guy123456789");
                Contact or = new Contact("or", "or aviv", "localhost:5000", "hey sister", DateTime.Now, "or123456789");
                Contact eran = new Contact("eran", "eran haim", "localhost:5000", "my name is eran", DateTime.Now, "eran123456789");
                _contacts.Add(adi);
                _contacts.Add(guy);
                _contacts.Add(or);
                _contacts.Add(eran);
                _contacts[0].Contacts.Add(guy.Id);
                _contacts[0].Contacts.Add(or.Id);
                _curContact = adi;
            }
        }
        
        public bool Delete(string id)
        {
            String contact = _curContact.Contacts.Find(x => x == id);
            if (contact != null)
            {
                _curContact.Contacts.Remove(contact);
                return true;
            }
            return false;
            
        }

        public bool Edit(string id, string newContact)
        {
            Contact contact = _contacts.Find(x => x.Id == id);
            if (contact != null)
            {
                contact.Name = newContact;
                return true;
            }
            return false;
        }

        public bool Add(string newContact)
        {
            Contact contant = _contacts.Find(x=>x.Id == newContact);
            if (contant != null && !_curContact.Contacts.Contains(contant.Id))
            {
                _curContact.Contacts.Add(contant.Id);
                return true;
            }
            return false;
        }

        public Contact Get(string id)
        {
            Contact contact = _contacts.Find(x => x.Id == id);
            return contact;
        }

        public List<Contact> GetAll()
        {
            List<Contact> list = new List<Contact>();
            foreach (string contact in _curContact.Contacts)
            {
                list.Add(Get(contact));
            }
            return list;
        }

        public void setContact(Contact contact)
        {
            _curContact = contact;
        }

        public Contact getCurContact()
        {
            return _curContact;
        }

        public bool addNewContact(string id)
        {
            Contact contact = _contacts.Find(x => x.Id == id);
            if (contact != null)
            {
                _curContact.Contacts.Add(contact.Id);
                return true;
            }
            return false;

        }
    }
}
