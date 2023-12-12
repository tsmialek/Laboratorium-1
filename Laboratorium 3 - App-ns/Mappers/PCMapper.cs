using Data.Entities;
using Laboratorium_3___App_ns.Models.PCCreator;

namespace Laboratorium_3___App_ns.Mappers
{
    public class PCMapper
    {
        public static PC FromEntityToPC(PCEntity pcEntity) => new PC()
        {
            Id = pcEntity.Id,
            Created = pcEntity.Created,
            Name = pcEntity.Name,
            Processor = pcEntity.Processor,
            RAM = pcEntity.RAM,
            Disk = pcEntity.Disk,
            DiskType = pcEntity.DiskTypeNav,

        };
    }
}
