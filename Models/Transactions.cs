using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovexBackend.Models
{
    [Table("Transactions")]
    public class Transactions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Transaction_type { get; set; }
        public float Amount { get; set; }
        public string Date_and_time { get; set; }
        public float Transaction_fee { get; set; }
        public int Account_Id { get; set; }
    }
}
