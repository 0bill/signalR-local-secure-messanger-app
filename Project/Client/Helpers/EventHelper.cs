using System;

namespace Client.Helpers
{
    public static class EventHelper
    {
        public static event EventHandler GlobalEvent;
        public static event EventHandler GlobalUserLoggedOff;
        
        
        
        public static void Raise(object sender, EventArgs args)
        {
            var evt = GlobalEvent;
            evt?.Invoke(sender,args);
        }
        
        public static void RaiseGlobalUserLoggedOff(object sender, EventArgs args)
        {
            GlobalUserLoggedOff?.Invoke(sender,args);
        }
        
 
        

       
    }
}
