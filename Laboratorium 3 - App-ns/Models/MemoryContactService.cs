namespace Laboratorium_3___App_ns.Models
{
    public class MemoryContactService : IContactService
    {
        private readonly Dictionary<int, Contact> _items = new Dictionary<int, Contact>()
        {
            {1, new Contact() { Id = 1, Name = "Adam", Email = "adam@gmail.com", Birth = new DateTime(200, 10, 10), Phone = "123123123" } },
            {2, new Contact() { Id = 2, Name = "Ewa", Email = "ewa@gmail.com", Birth = new DateTime(200, 10, 10), Phone = "234234234" } },
        };

        private int id = 3;

        public void Add(Contact contact)
        {
            contact.Id = id++;
            _items[contact.Id] = contact;
        }

        public List<Contact> FindAll()
        {
            return _items.Values.ToList();
        }

        public Contact? FindById(int id)
        {
            return _items[id];
        }

        public void RemoveById(int id)
        {
            _items.Remove(id);
        }

        public void Update(Contact contact)
        {
            _items[contact.Id] = contact;
        }
    }
}
