using Data;
using Data.Entities;
using Laboratorium_3___App_ns.Mappers;

namespace Laboratorium_3___App_ns.Models.ContactModel
{
    public class EFContactService : IContactService
    {
        private AppDbContext _context;

        public EFContactService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Contact contact)
        {
            var e = _context.Contacts.Add(ContactMapper.ToEntity(contact));
            _context.SaveChanges();
            return e.Entity.Id;
        }

        public List<Contact> FindAll()
        {
            return _context.Contacts.Select(e => ContactMapper.FromEntity(e)).ToList();
        }

        public Contact? FindById(int id)
        {
            return ContactMapper.FromEntity(_context.Contacts.Find(id));
        }

        public void RemoveById(int id)
        {
            if (FindById(id) != null)
            {
                _context.Contacts.Remove(_context.Contacts.Find(id));
                _context.SaveChanges();
            }
        }

        public void Update(Contact contact)
        {
            _context.Contacts.Update(ContactMapper.ToEntity(contact));
            _context.SaveChanges();
        }
    }
}
