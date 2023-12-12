using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("pcs")]
    public class PCEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime Created { get; set; }

        [MaxLength(50), MinLength(3)]
        public string Name { get; set; }

        public string Processor { get; set; }

        public string RAM { get; set; }

        public string Disk { get; set; }

        [Required]
        public string DiskTypeId { get; set; }

        [Required]
        [ForeignKey("DiskTypeId")]
        public DiskTypeEntity DiskTypeNav { get; set; }

        public string GPU { get; set; }

        public string? Manufacturer { get; set; }

        public DateTime? ProductionDate { get; set; }
    }
}
