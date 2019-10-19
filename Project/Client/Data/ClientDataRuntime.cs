using Domain;

namespace Client.Data
{
    public interface IClientDataRuntime
    {
        User CurrentUser { get; set; }
    }


    public class ClientDataRuntime : IClientDataRuntime
    {
        public User CurrentUser { get; set; }
        public ClientDataRuntime()
        {
            CurrentUser = null;
        }

        
    }
}