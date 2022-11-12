using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace ManagmentSystemAPI.Models
{
    [Table("RoleType")]
    public partial class RoleType
    {
        [Key]
        [Required]
        public int RoleID { get; set; }

        [Required]
        [StringLength(50)]
        public string Role_name { get; set; }
    }
}
