namespace webAPI.Models
{
    public interface IContactService
    {
        public List<Contact> GetAll();
        Contact Get(string id);

        public void Edit(string id, string newContact);
        public void Delete(string id);

        public void Add(string contact);

        public void setContact(Contact id);

        public Contact getCurContact();

        public void addNewContact(string id);

    }
}
