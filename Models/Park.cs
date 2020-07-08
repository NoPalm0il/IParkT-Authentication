using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IParkT_Authentication.Models
{
    public class Park
    {
        public Park()
        {
            Reservations = new HashSet<Reservation>();
        }

        [Key]
        public int ParkId { get; set; }
        public int ParkSpot { get; set; }
        public string ParkSpotType { get; set; }
        public string GpsCoords { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
