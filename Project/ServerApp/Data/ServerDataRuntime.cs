using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace ServerApp.Data
{
    public interface IServerDataRuntime
    {
        void addConnectedUser(User user);
        void removeConnectedUser(User user);
        bool checkToken(string token);
    }

    public class ServerDataRuntime : IServerDataRuntime
    {
        static List<User> connectedUsers = new List<User>();

        public void addConnectedUser(User user)
        {
            foreach (var n in connectedUsers.Where(u => u.Id == user.Id).ToArray()) connectedUsers.Remove(n);
            connectedUsers.Add(user);
        }

        public void removeConnectedUser(User user)
        {
            connectedUsers.Remove(user);
        }

        public List<User> getConnected()
        {
            return connectedUsers;
        }

        public bool checkToken(string token)
        {
            var singleOrDefault = connectedUsers.SingleOrDefault(x => x.Token == token);
            if (singleOrDefault != null)
            {
                return true;
            }

            return false;
        }
    }
}
