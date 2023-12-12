using Data;
using Laboratorium_3___App_ns.Mappers;
using SQLitePCL;

namespace Laboratorium_3___App_ns.Models.PCCreator
{
    public class EFPCCReatorService : IPCCreatorService
    {
        private readonly AppDbContext _context;
        private IDateTimeProvider _timeProvider;

        public EFPCCReatorService()
        {
            _context = new AppDbContext();
            _timeProvider = new CurrentDateTimeProvider();
        }

        public int Add(PC pc)
        {
            var e = _context.PCs.Add(PCMapper.ToEntity(pc));
            e.Entity.Created = _timeProvider.GetCurrentDateTime();
            _context.SaveChanges();
            return e.Entity.Id;
        }

        public bool Delete(int id)
        {
            var Find = _context.PCs.Find(id);
            if (Find != null)
            {
                _context.PCs.Remove(Find);
                _context.SaveChanges();
                return true;
            }

            return false;

        }

        public PC? FindById(int id)
        {
            return PCMapper.ToModel(_context.PCs.Find(id));
        }

        public List<PC> GetAll()
        {
            return _context.PCs.Select(e => PCMapper.ToModel(e)).ToList();
        }

        public void Update(PC pc)
        {
            _context.Update(PCMapper.ToEntity(pc));
            _context.PCs.Find(pc.Id).Created = pc.Created;
            _context.SaveChanges();
        }
    }
}
