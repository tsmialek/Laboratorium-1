using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium_3___App_ns.Models
{
    public class Contact
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Musisz podać imię")]
        [StringLength(maximumLength: 50, ErrorMessage = "Zbyt długie imię, max 50 znaków")]
        public string Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Proszę podać poprawny Email")]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birth { get; set; }
    }
}
