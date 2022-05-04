namespace webAPI.Models
{
    public interface IContactService
    {
        public List<Contact> GetAll();  
        public Contact Get(int id);

        public void Edit(string id, Contact newContact);
        public void Delete(string id);

    }
}
