namespace Laboratorium_3___App_ns.Models
{
    public interface IPCCreatorService
    {
        int Add(PC pc);
        bool Delete(int id);
        void Update(PC pc);
        List<PC> GetAll();
        PC? FindById(int id);   
    }
}
