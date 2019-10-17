using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public string Password { get; set; }
        [NotMapped]
        public string ConnectionId { get; set; }
        [NotMapped]
        public string Token { get; set; }

        public override string ToString()
        {
            return Id + " " + Username + " " + Password + " ";
        }
    }
}
