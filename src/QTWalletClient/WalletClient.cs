using Newtonsoft.Json;
using QTWalletClient.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QTWalletClient
{
    public class WalletClient
    {
        private string _walletAddress;
        private string _user;
        private string _password;

        public WalletClient(WalletSettings settings)
        {
            _walletAddress = $"http://{settings.Ip}:{settings.Port}";
            _user = settings.UserName;
            _password = settings.Password;
        }

        public async Task<QTResponseModel> SendCommandAsync(WalletCommands command)
            => await SendCommandAsync(command.GetValue(), new string[0]);

        public async Task<QTResponseModel> SendCommandAsync(WalletCommands command, params string[] args)
            => await SendCommandAsync(command.GetValue(), args);

        public async Task<QTResponseModel> SendCommandAsync(string command, params string[] args)
        {
            var request = new QTRequestModel(command, args);
            var responseText = await SendRequest(request);
            return JsonConvert.DeserializeObject<QTResponseModel>(responseText);
        }

        private async Task<string> SendRequest(QTRequestModel request)
        {
            using (var handler = CreateAuthorizedClientHandler())
            using (var client = new HttpClient(handler))
            {
                var content = CreateJsonContent(request);
                var result = await client.PostAsync(_walletAddress, content);

                AssertSuccessful(result);

                return await result.Content.ReadAsStringAsync();
            }
        }

        private HttpClientHandler CreateAuthorizedClientHandler()
            => new HttpClientHandler
            {
                Credentials = new NetworkCredential(_user, _password)
            };

        private StringContent CreateJsonContent(QTRequestModel request)
        {
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.Default, "application/json");
            return content;
        }

        private void AssertSuccessful(HttpResponseMessage response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Server response code: {response.StatusCode}");
            }
        }
    }
}
