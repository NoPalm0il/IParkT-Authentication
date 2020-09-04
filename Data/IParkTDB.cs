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

        //public override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Park>().HasData(
        //        new Park { ParkId = 0, ParkSpot = 0x00, ParkSpotType = "Guard", GpsCoords = "39°36\'01.8\"N 8°23\'29.3\"W" }
        //        );
        //}

        // adicionar as 'tabelas' à BD
        public virtual DbSet<Utilizador> User { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Park> Park { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
    }

}
