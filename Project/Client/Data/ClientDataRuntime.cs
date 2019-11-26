using System.Collections.Generic;
using Domain;

namespace Client.Data
{
    public interface IClientDataRuntime
    {
        User CurrentUser { get; set; }
        List<User> UserList { get; set; }
    }

    /// <summary>
    /// Class designed to store data globally
    /// </summary>
    public class ClientDataRuntime : IClientDataRuntime
    {
        public User CurrentUser { get; set; }
        public List<User> UserList { get; set; }

        public ClientDataRuntime()
        {
            CurrentUser = null;
            UserList = new List<User>();
        }

        
    }
}