namespace Laboratorium_3___App_ns.Models
{
    public interface IContactService
    {
        void Add(Contact contact);

        void RemoveById(int id);

        void Update(Contact contact);

        List<Contact> FindAll();

        Contact? FindById(int id);  
    }
}
