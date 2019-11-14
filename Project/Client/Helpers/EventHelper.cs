using System;

namespace Client.Helpers
{
    public static class EventHelper
    {
        public static event EventHandler GlobalUserLoggedOff;
        public static event EventHandler OnIncomingMessage;
       
        public static event EventHandler PlayIncomingSound;

        public static void RaiseGlobalUserLoggedOff(object sender, EventArgs args)
        {
            GlobalUserLoggedOff?.Invoke(sender,args);
        }
        

        
        public static void RaiseOnIncomingMessage(object sender, EventArgs args)
        {
            OnIncomingMessage?.Invoke(sender,args);
        }
        
        public static void RaisePlayIncomingSound(object sender, EventArgs args)
        {
            PlayIncomingSound?.Invoke(sender,args);
        }
        
        
        
 
        

       
    }
}
