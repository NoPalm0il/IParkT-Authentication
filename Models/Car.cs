using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IParkT_Authentication.Models
{
    public class Car
    {
        public Car()
        {
            Reservations = new HashSet<Reservation>();
        }

        [Key]
        public string LicensePlate { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }

        [ForeignKey("Utilizador")]
        public int username { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
