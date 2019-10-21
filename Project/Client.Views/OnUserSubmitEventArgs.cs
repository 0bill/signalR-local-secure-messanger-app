using System;

namespace Client.Views
{
    public class OnUserSubmitEventArgs : EventArgs
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public OnUserSubmitEventArgs(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}