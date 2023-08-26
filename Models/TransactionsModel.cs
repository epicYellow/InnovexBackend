using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovexBackend.Models
{
    [Table("Transactions")]
    public class TransactionsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Transaction_type { get; set; } = string.Empty;

        [Required]
        public float Amount { get; set; } 

        [Required]
        public string Date_and_time { get; set; } = string.Empty;

        [Required]
        public float Transaction_fee { get; set; } 

        [Required]
        public int Account_Id { get; set; }

    }
}


