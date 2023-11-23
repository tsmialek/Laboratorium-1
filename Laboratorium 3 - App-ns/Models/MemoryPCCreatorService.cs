namespace Laboratorium_3___App_ns.Models
{
    public class MemoryPCCreatorService : IPCCreatorService
    {
        private Dictionary<int, PC> _pcs;

        private IDateTimeProvider _timeProvider;

        public MemoryPCCreatorService()
        {
            _pcs = new Dictionary<int, PC>();
            _timeProvider = new CurrentDateTimeProvider();
        }

        public int Add(PC pc)
        {
            pc.Id = _pcs.Count + 1;
            pc.Created = _timeProvider.GetCurrentDateTime();

            _pcs.Add(pc.Id, pc);

            return pc.Id;
        }

        public bool Delete(int id)
        {
            if(_pcs.ContainsKey(id))
            {
                _pcs.Remove(id);
                return true;
            }
            else
                return false;
        }

        public PC? FindById(int id)
        {
            return _pcs.ContainsKey(id) ? _pcs[id] : null; 
        }

        public List<PC> GetAll()
        {
            return _pcs.Values.ToList();
        }

        public void Update(PC pc)
        {
            _pcs[pc.Id] = pc;
        }
    }
}
