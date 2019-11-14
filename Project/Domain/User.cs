using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace Domain
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required] public string Username { get; set; }

        private string _password;

        public virtual List<ConversationUser> ConversationUsers { get; set; }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        [NotMapped]
        public string NotHashedPassword
        {
            set => _password = GenerateHash(value, Salt);
        }

        [NotMapped] public string ConnectionId { get; set; }
        [NotMapped] public Token Token { get; set; }
        [NotMapped] private const string Salt = "Very hard salt";


        private string GenerateHash(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            SHA256Managed sHA256ManagedString = new SHA256Managed();
            byte[] hash = sHA256ManagedString.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        /* public bool IsPasswordCorrect(string plainTextInput)
         {
             string newHashedPin = GenerateHash(plainTextInput, Salt);
             return newHashedPin.Equals(Password);
         }*/
    }
}