using System;

namespace Client.Views.Events
{
    public class SendMessageArgs : EventArgs
    {
        public string Message { get; private set; }
        public Domain.Message MessageObject { get; private set; }

        public SendMessageArgs(string message)
        {
            Message = message;
        }
        
        public SendMessageArgs(Domain.Message message)
        {
            MessageObject = message;
        }
    }
}