using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("DiskTypes")]
    public class DiskType
    {
        [Key]
        [Required]
        public string Type { get; set; }
    }
}
