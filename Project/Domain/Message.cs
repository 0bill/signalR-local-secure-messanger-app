using System;
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
        private string _text;
        [DataType(DataType.DateTime)]
        public DateTime Timestamp { get; set; }
        public int AuthorId { get; set; }
        public virtual User Author { get; set; }
        public int ConversationId { get; set; }
        public virtual Conversation Conversation { get; set; }
        [NotMapped] 
        private string _password = "SecredPassword";

        public string Text
        {
            get => _text;
            set => _text = value;
        }

        public void EncryptText(string value)
        {
            _text = new AESHelper().EncryptText(value, _password);
        }

        public string DecryptText()
        {
            return new AESHelper().DecryptText(_text, _password);
        }
    }
}