﻿using Data.Entities;
using Laboratorium_3___App_ns.Models.PCCreator;

namespace Laboratorium_3___App_ns.Mappers
{
    public class PCMapper
    {
        public static PC ToModel(PCEntity pcEntity) => new PC()
        {
            Id = pcEntity.Id,
            Created = pcEntity.Created,
            Name = pcEntity.Name,
            Processor = pcEntity.Processor,
            RAM = pcEntity.RAM,
            Disk = pcEntity.Disk,
            DiskType = (DiskType)Enum.Parse(typeof(DiskType), pcEntity.DiskType),
            GPU = pcEntity.GPU,
            Manufacturer = pcEntity.Manufacturer,
            ProductionDate = pcEntity.ProductionDate
        };

        public static PCEntity ToEntity(PC model)
        {
            return new PCEntity()
            {
                Id = model.Id,
                Created = model.Created,
                Name = model.Name,
                Processor = model.Processor,
                RAM = model.RAM,
                Disk = model.Disk,
                DiskType = model.DiskType.ToString(),
                GPU = model.GPU,
                Manufacturer = model.Manufacturer,
                ProductionDate = model.ProductionDate
            };
        }
    }
}
