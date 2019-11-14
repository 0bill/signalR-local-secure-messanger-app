using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Data;
using Client.Exceptions;
using Client.Helpers;
using Domain;
using Newtonsoft.Json;
using Unity;
using Message = Domain.Message;

namespace Client.Contact
{
    public interface IRestApiContext
    {
        IRestApiContext EstablishConnection(Token token);

        Task<User> PostAuthUser(User user);
        Task<Conversation> PostGetConversation(List<User> users);
        Task<List<Message>> PostGetAllMessagesForConversation(int conversationId);
        Task<List<User>> PostGetAllUsers();
        
    }


    public class RestApiContext : IRestApiContext
    {
        private HttpClient _client;
        private string _url = "https://localhost:5001/api";
        private Token _token;
        private readonly IUnityContainer _container;
        private readonly int attempts = 3;

        public RestApiContext(IUnityContainer container)
        {
            _container = container;
        }
        public IRestApiContext EstablishConnection(Token token)
        {
            _token = token;
            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            _client = new HttpClient(clientHandler);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            _client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            if(token!=null)
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.JwtToken);
            return this;
        }

        public async Task<User> PostAuthUser(User user)
        {
            var json = JsonConvert.SerializeObject(user);
          

            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_url + "/UserAuth", stringContent);
            if (response.StatusCode != HttpStatusCode.OK) throw new DataNotFoundException();
            var readAsStringAsync = await response.Content.ReadAsStringAsync();
            var verifiedUser = JsonConvert.DeserializeObject<User>(readAsStringAsync);
            return verifiedUser;
        }


        public async Task<List<User>> PostGetAllUsers()
        {
            var readAsStringAsync = await ExecuteRequestTask("", "/UserList");
            var users = JsonConvert.DeserializeObject<List<User>>(readAsStringAsync);
            return users;
        }

        private async Task<Token> PostRefreshToken(Token token)
        {
            var json = JsonConvert.SerializeObject(token);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_url + "/UserAuth/refresh", stringContent);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                EventHelper.RaiseGlobalUserLoggedOff(this,null);
            }
            var readAsStringAsync = await response.Content.ReadAsStringAsync();
            _token = JsonConvert.DeserializeObject<Token>(readAsStringAsync);
            _container.Resolve<IClientDataRuntime>().CurrentUser.Token = _token;
            return _token;
        }


        public async Task<List<Message>> PostGetAllMessagesForConversation(int conversationId)
        {
            
            var json = JsonConvert.SerializeObject(new Conversation()
            {
                Id = conversationId
            });
            var readAsStringAsync = await ExecuteRequestTask(json,"/ConversationMessages/messages");
            var messages = JsonConvert.DeserializeObject<List<Message>>(readAsStringAsync);
            return messages;
        }

        public async Task<Conversation> PostGetConversation(List<User> users)
        {            
            
            var json = JsonConvert.SerializeObject(users);
            var readAsStringAsync = await ExecuteRequestTask(json, "/ConversationMessages/conversation");
            var conversationWithId = JsonConvert.DeserializeObject<Conversation>(readAsStringAsync);
            return conversationWithId;
        }
        
        private async Task<string> ExecuteRequestTask(string json, string controlerURL)
        {
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;

            try
            {
                int counter = 0;
                do
                {
                    response = await _client.PostAsync(_url + controlerURL, stringContent);
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        Token postRefreshToken = await PostRefreshToken(_token);
                        EstablishConnection(postRefreshToken);
                    }

                    counter++;
                } while (counter < attempts && response.StatusCode == HttpStatusCode.Unauthorized);

            }
            catch(Exception e)
            {
                if (e.GetType() == typeof(HttpRequestException))
                {
                    MessageBox.Show("You lost connection. Server not respond.");
                    EventHelper.RaiseGlobalUserLoggedOff(this,null);
                    
                }
            }
            if (response.StatusCode == HttpStatusCode.Unauthorized) throw new TokenNotValidException("Token not valid or expired");
            if (response.StatusCode == HttpStatusCode.NotFound) throw new DataNotFoundException("Messages not found");
            if (response.StatusCode != HttpStatusCode.OK) return null;
            var readAsStringAsync = await response.Content.ReadAsStringAsync();
            return readAsStringAsync;
        }
        
    }
}