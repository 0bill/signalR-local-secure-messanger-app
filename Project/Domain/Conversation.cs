using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Conversation
    {
        public Guid Id { get; set; }
        public List<Message> Messages { get; set; }
        public List<User> User { get; set; }


    }
}
