using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovexBackend.Models
{
    [Table("AccountTypes")]
    public class AccountTypes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Type_name { get; set; } = string.Empty;
        [Required]
        public float Transaction_fee { get; set; } = float.MaxValue;
        [Required]
        public float Annual_interest_rate { get; set; } = float.MaxValue;
        [Required]
        public int Free_limit { get; set; } = 0;
    }
}
