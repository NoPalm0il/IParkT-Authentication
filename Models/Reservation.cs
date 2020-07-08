﻿using System;
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
        public DateTime Date { get; set; }//remover isto
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }
        [ForeignKey("Park")]
        public int ParkId { get; set; }
    }
}
