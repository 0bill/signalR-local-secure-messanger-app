using System;

namespace Client.Views.Events
{
    public class SubmitUserArgs : EventArgs
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public SubmitUserArgs(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}