using System;

namespace Client.Helpers
{
    public static class EventHelper
    {
        public static event EventHandler GlobalUserLoggedOff;
        
        public static void RaiseGlobalUserLoggedOff(object sender, EventArgs args)
        {
            GlobalUserLoggedOff?.Invoke(sender,args);
        }
        
 
        

       
    }
}
