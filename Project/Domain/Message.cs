using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Helpers;

namespace Domain
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DataType(DataType.Text)]
        private string _Text { get; set; }
        public virtual User Author { get; set; }
        public int ConversationId { get; set; }
        public virtual Conversation Conversation { get; set; }
        [NotMapped]
        private string _password = "SecredPassword";
        
        public string Text
        {
            get => _Text;
            set => _Text = new AESHelper().EncryptText(value,_password);
        }

        public string EncryptedText =>  new AESHelper().DecryptText(_Text,_password);
    }
}