using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI_Brasil_io.Models
{
    [Table("User")]
    public class User
    {
        [Display(Name = "Id")]
        [Column("ID")]
        public int Id { get; set; }

        [Display(Name = "E-mail")]
        [Column("Email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Column("Password")]
        public string Password { get; set; }
    }
}
