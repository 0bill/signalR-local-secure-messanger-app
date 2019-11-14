using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class ReceivedMessages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MessageId { get; set; }
        public int UserId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Timestamp { get; set; }
        public virtual Message Message { get; set; }
        public virtual User User { get; set; }
    }
}