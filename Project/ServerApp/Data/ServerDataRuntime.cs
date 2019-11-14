using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace ServerApp.Data
{
    public interface IServerDataRuntime
    {
        bool CheckToken(Token token);
        void AddToken(Token token);
        bool CheckRefreshToken(Token token);
        void RemoveToken(Token token);
        List<Token> getToken(Token token);
        Token getToken(string jwt);

        List<User> ConntectedUsers { get; set; }
    }

    public class ServerDataRuntime : IServerDataRuntime
    {
        private static readonly List<Token> _CurrentSessionTokens = new List<Token>();
        public List<User> ConntectedUsers { get; set; }

        public ServerDataRuntime()
        {
            ConntectedUsers = new List<User>();
        }


        public void AddToken(Token token)
        {
            if (CheckToken(token))
            {
                RemoveToken(token);
            }
            _CurrentSessionTokens.Add(token);
        }

        public bool CheckRefreshToken(Token token)
        {
            var firstOrDefault = _CurrentSessionTokens.FirstOrDefault(token => token.JwtToken == token.JwtToken && token.RefreshToken == token.RefreshToken );
            return firstOrDefault != null;
        }

        public bool CheckToken(Token token)
        {
            var firstOrDefault = _CurrentSessionTokens.FirstOrDefault(stringToCheck => stringToCheck.JwtToken == token.JwtToken );
            return firstOrDefault != null;
        }

        public void RemoveToken(Token token)
        {
            _CurrentSessionTokens.RemoveAll(x=>x.JwtToken==token.JwtToken);
        }

        public List<Token> getToken(Token token)
        {
            return _CurrentSessionTokens.Where(x => x.JwtToken == token.JwtToken).ToList();
        }
        
        public Token getToken(string jwt)
        {
            return _CurrentSessionTokens.SingleOrDefault(x => x.JwtToken == jwt);
        }

    }
}
