using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium_3___App_ns.Models
{
    public class PC
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Musisz podać nazwę")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Należy wybrać model procesora")]
        public string Processor { get; set; }

        [Required(ErrorMessage = "Należy wybrać ilość pamięci RAM")]
        public string RAM { get; set; }

        [Required(ErrorMessage = "Należy wybrać ilosć dostępnej pamięci")]
        public string Disk { get; set; } 

        [Required(ErrorMessage = "Należy wybrać model karty graficznej")]
        public string GPU { get; set; }

        public string? Manufacturer { get; set; }

        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }
    }
}
