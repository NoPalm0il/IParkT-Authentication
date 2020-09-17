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

        public virtual ICollection<Car> Cars { get; set; }
    }
}
