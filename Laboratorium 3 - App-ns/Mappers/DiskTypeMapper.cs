using Data.Entities;
using Laboratorium_3___App_ns.Models.PCCreator;

namespace Laboratorium_3___App_ns.Mappers
{
    public class DiskTypeMapper
    {
        public static DiskType ToEnum(DiskTypeEntity diskTypeEntity)
        {
            try
            {
                if (Enum.TryParse<DiskType>(diskTypeEntity.Type, out var diskType))
                    return diskType;
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return DiskType.HDD;
        }

        public static DiskTypeEntity ToEntity(DiskType diskType)
        {
            return new DiskTypeEntity() { Type =  diskType.ToString() };
        }
    }
}
