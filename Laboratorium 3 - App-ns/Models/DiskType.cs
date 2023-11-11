using System.ComponentModel.DataAnnotations;

namespace Laboratorium_3___App_ns.Models
{
    public enum DiskType
    {
        [Display(Name = "SSD")]SSD = 1,
        [Display(Name = "HDD")]HDD = 2,
        [Display(Name = "Hybrydowy")]Hybrid = 3,
        [Display(Name = "NVMe")]NVMe = 4,
    }
}
