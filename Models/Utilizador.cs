using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IParkT_Authentication.Models
{
    public class Utilizador
    {
        public Utilizador()
        {
            Cars = new HashSet<Car>();
        }

        [Key]
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Must have a username")]
        public string username { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Must have a email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        //[ForeignKey("Passwords")]
        //[Display(Name = "Password")]
        //[DataType(DataType.Password)]
        //[Required(ErrorMessage = "Must have a password")]
        //public int passwordId { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
