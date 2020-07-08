using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IParkT_Authentication.Models;

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

        // adicionar as 'tabelas' à BD
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Park> Park { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            // insert DB seed
            //modelBuilder.Entity<User>().HasData(
            //   new User { username = "user", email = "some@some.com" }
            //    );

            //modelBuilder.Entity<Car>().HasData(
            //  new Car { LicensePlate = "xx-xx-xx", Color = "x", Manufacturer = "x", Model = "x", Year = 0000 }
            //   );

            //modelBuilder.Entity<Park>().HasData(
            //    new Park { ParkId = 1, ParkSpot = 0x01, ParkSpotType = "x", GpsCoords = "x:x\"x\'x" }
            //   );


            //modelBuilder.Entity<Reservation>().HasData(
            //  new Reservation { ReservationId = 1, Date = DateTime.MinValue, CheckIn = DateTime.MinValue, CheckOut = DateTime.MinValue }
            //   );
        }
        }
   }
