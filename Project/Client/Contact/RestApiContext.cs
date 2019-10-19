using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Newtonsoft.Json;

namespace Client.Contact
{
    public interface IRestApiContext
    {
        IRestApiContext EstablishConnection();
        Task<bool> Post(User user);
    }


    public class RestApiContext : IRestApiContext
    {
        private HttpClient _client;


        public IRestApiContext EstablishConnection()
        {
            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            _client = new HttpClient(clientHandler);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            _client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            return this;
        }

        public async Task<bool> Post(User user)
        {
            var json = JsonConvert.SerializeObject(user);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await _client.PostAsync("https://localhost:5001/api/UserAuth", stringContent);


            if (response.StatusCode != HttpStatusCode.OK) return false;
            
            var readAsStringAsync = await response.Content.ReadAsStringAsync();
            var user1 = JsonConvert.DeserializeObject<User>(readAsStringAsync);
            Console.WriteLine(user1.Username);
            return true;

        }
    }
}