using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations.Schema;

namespace WearHouse.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        [Column("Name", TypeName = "varchar(250)")]
        public string Name { get; set; }
        [Column("Email", TypeName = "varchar(250)")]
        public string Email { get; set; }
        [Column("Password", TypeName = "varchar(250)")]
        public string Password { get; set; }
    }
}
