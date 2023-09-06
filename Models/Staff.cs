using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InnovexBackend.Models
{
    [Table("Staff")]
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string IdNumber { get; set; } = string.Empty;

        public float Income { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
        public string RoleTitle { get; set; } = "User";
    }
}
