using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2NETProjetBDClient.BO
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Firstname { get; set; }

        public string Fullname => string.Format("{0} {1}", this.Firstname, this.Name);
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }

        public ICollection<Wish> Wishlist{ get; set; }
    }
}
