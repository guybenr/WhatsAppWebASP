﻿namespace webAPI.Models
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
        }

        public void Edit(string id, Contact newContact)
        {
        }

        public Contact Get(int id)
        {
            return _contacts[0];
        }

        public List<Contact> GetAll()
        {
            return _contacts;
        }
    }
}
