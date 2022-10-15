using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace ManagmentSystemAPI.Models
{
    [Table("Customer")]
    public partial class Customer
    {
        [Key]
        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(25)]
        public string Last_name { get; set; }

        [Required]
        public int Dni{ get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(60)]
        public string Email { get; set; }
    }
}
