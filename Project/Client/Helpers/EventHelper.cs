using System;

namespace Client.Helpers
{
    /// <summary>
    /// Global event handler
    /// </summary>
    public static class EventHelper
    {
        public static event EventHandler GlobalUserLoggedOff;
        public static event EventHandler OnIncomingMessage;
       
        public static event EventHandler PlayIncomingSound;

        /// <summary>
        /// Raise user logged off event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public static void RaiseGlobalUserLoggedOff(object sender, EventArgs args)
        {
            GlobalUserLoggedOff?.Invoke(sender,args);
        }
        
        /// <summary>
        /// Raise incoming message event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public static void RaiseOnIncomingMessage(object sender, EventArgs args)
        {
            OnIncomingMessage?.Invoke(sender,args);
        }
        
        /// <summary>
        /// Raise play sound on incoming message event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public static void RaisePlayIncomingSound(object sender, EventArgs args)
        {
            PlayIncomingSound?.Invoke(sender,args);
        }
        
        
        
 
        

       
    }
}
