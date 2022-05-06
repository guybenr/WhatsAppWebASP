namespace webAPI.Models
{
    public interface IContactService
    {
        public List<Contact> GetAll();
        Contact Get(string id);

        public void Edit(string id, Contact newContact);
        public void Delete(string id);

        public void Add(Contact contact);
        
    }
}
