namespace webAPI.Models
{
    public interface IContactService
    {
        public List<Contact> GetAll();
        Contact Get(string id);

        public bool Edit(string id, string newContact);
        public bool Delete(string id);

        public bool Add(string contact);

        public void setContact(Contact id);

        public Contact getCurContact();

        public bool addNewContact(string id);

    }
}
