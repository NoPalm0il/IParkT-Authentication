using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IParkT_Authentication.Models;
using Microsoft.AspNetCore.Identity;

namespace IParkT_Authentication.Data
{

    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
    }

    public class IParkTDB : DbContext
    {
        /// <summary>
        /// Class Constructor
        /// Db connection and data creation
        /// </summary>
        /// <param name="options"></param>
        public IParkTDB(DbContextOptions<IParkTDB> options) : base(options) { }

        // adicionar as 'tabelas' à BD
        public virtual DbSet<Utilizador> User { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Park> Park { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
    }
}
