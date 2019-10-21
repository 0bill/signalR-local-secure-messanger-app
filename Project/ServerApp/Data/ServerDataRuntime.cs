using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace ServerApp.Data
{
    public interface IServerDataRuntime
    {
        void AddConnectedUser(User user);
        void RemoveConnectedUser(User user);
        bool CheckToken(string token);
    }

    public class ServerDataRuntime : IServerDataRuntime
    {
        private static List<User> _connectedUsers = new List<User>();

        public void AddConnectedUser(User user)
        {
            foreach (var n in _connectedUsers.Where(u => u.Id == user.Id).ToArray()) _connectedUsers.Remove(n);
            _connectedUsers.Add(user);
        }

        public void RemoveConnectedUser(User user)
        {
            _connectedUsers.Remove(user);
        }

        public List<User> getConnected()
        {
            return _connectedUsers;
        }

        public bool CheckToken(string token)
        {
            var singleOrDefault = _connectedUsers.SingleOrDefault(x => x.Token == token);
            if (singleOrDefault != null)
            {
                return true;
            }

            return false;
        }
    }
}
