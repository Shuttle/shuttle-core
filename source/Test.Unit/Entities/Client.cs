using System.Collections.Generic;

namespace Test.All
{
    public class Client
    {
        private readonly List<ClientContact> contacts = new List<ClientContact>();
        public string Name { get; set; }

        public IEnumerable<ClientContact> Contacts
        {
            get
            {
                return contacts;
            }
        }

        public void AddContact(ClientContact contact)
        {
            contacts.Add(contact);
        }
    }
}