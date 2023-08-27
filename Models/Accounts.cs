using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovexBackend.Models
{
    [Table("Accounts")]
    public class Accounts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Account_number { get; set; } = string.Empty;
        [Required]
        public int Type_id { get; set; } = int.MaxValue;
        [Required]
        public float Transaction_fee { get; set; } = float.MaxValue;
        [Required]
        public float Balance { get; set; } = float.MaxValue;
        [Required]
        public int Client_id { get; set; } = 0;
    }
}
