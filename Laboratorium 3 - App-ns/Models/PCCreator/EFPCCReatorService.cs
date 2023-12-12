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
            e.Entity.Created = _timeProvider.GetCurrentDateTime().Date;
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
            var entityToUpdate = _context.PCs.Find(pc.Id);
            if (entityToUpdate != null)
            {
                // Teraz aktualizujemy właściwości istniejącego obiektu
                entityToUpdate.Name = pc.Name;
                entityToUpdate.Processor = pc.Processor;
                entityToUpdate.RAM = pc.RAM;
                entityToUpdate.Disk = pc.Disk;
                entityToUpdate.DiskType = pc.DiskType.ToString();
                entityToUpdate.GPU = pc.GPU;
                entityToUpdate.Manufacturer = pc.Manufacturer;
                entityToUpdate.ProductionDate = pc.ProductionDate;

                _context.Update(entityToUpdate); // Może być opcjonalne w zależności od konfiguracji EF
                _context.SaveChanges();
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
