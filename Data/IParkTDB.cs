using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IParkT_Authentication.Models;
using Microsoft.AspNetCore.Identity;

namespace IParkT_Authentication.Data
{
    public class IParkTDB : DbContext
    {
        /// <summary>
        /// Class Constructor
        /// Db connection and data creation
        /// </summary>
        /// <param name="options"></param>
        public IParkTDB(DbContextOptions<IParkTDB> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Park>().HasData(
                new Park { ParkId = 3, ParkSpotType = "Teacher", GpsCoords = "39°36\'01.8\"N 8°23\'29.3\"W" },
                new Park { ParkId = 4, ParkSpotType = "Teacher", GpsCoords = "39°36\'01.8\"N 8°23\'29.3\"W" },
                new Park { ParkId = 5, ParkSpotType = "Aux", GpsCoords = "39°36\'01.8\"N 8°23\'29.3\"W" },
                new Park { ParkId = 6, ParkSpotType = "Aux", GpsCoords = "39°36\'01.8\"N 8°23\'29.3\"W" },
                new Park { ParkId = 7, ParkSpotType = "Student", GpsCoords = "39°36\'01.8\"N 8°23\'29.3\"W" },
                new Park { ParkId = 8, ParkSpotType = "Student", GpsCoords = "39°36\'01.8\"N 8°23\'29.3\"W" },
                new Park { ParkId = 9, ParkSpotType = "Student", GpsCoords = "39°36\'01.8\"N 8°23\'29.3\"W" },
                new Park { ParkId = 10, ParkSpotType = "Student", GpsCoords = "39°36\'01.8\"N 8°23\'29.3\"W" },
                new Park { ParkId = 11, ParkSpotType = "Student", GpsCoords = "39°36\'01.8\"N 8°23\'29.3\"W" },
                new Park { ParkId = 12, ParkSpotType = "Principal", GpsCoords = "39°36\'01.8\"N 8°23\'29.3\"W" }
                );
        }

        // add db tables
        public virtual DbSet<Utilizador> User { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Park> Park { get; set; }
    }

}
