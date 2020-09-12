using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IParkT_Authentication.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public DateTime CheckOut { get; set; }

        [ForeignKey(nameof(Car))]
        public string LicensePlate { get; set; }
        public virtual Car car { get; set; }
        [ForeignKey(nameof(Park))]
        public int ParkId { get; set; }
        public virtual Park park { get; set; }
    }
}
