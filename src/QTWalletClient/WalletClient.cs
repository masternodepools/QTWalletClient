using Newtonsoft.Json;
using QTWalletClient.Models;
using System.Net;
using System.Text;

namespace QTWalletClient
{
    public class WalletClient
    {
        private WalletSettings _settings;

        public WalletClient(WalletSettings settings)
            => _settings = settings;

        public QTResponseModel SendCommand(WalletCommands command)
            => SendCommand(command, new string[0]);

        public QTResponseModel SendCommand(WalletCommands command, params string[] args)
        {
            var request = new QTRequestModel(command.GetValue(), args);
            var responseText = SendRequest(request);
            return JsonConvert.DeserializeObject<QTResponseModel>(responseText);
        }

        private string SendRequest(QTRequestModel request)
        {
            using (var wc = CreateAuthorizedRPCClient())
            {
                var bytes = ConvertToJsonBytes(request);
                var response = wc.UploadData(_settings.IpAddress, bytes);
                return Encoding.UTF8.GetString(response);
            }
        }

        private byte[] ConvertToJsonBytes(QTRequestModel obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return Encoding.UTF8.GetBytes(json);
        }

        private WebClient CreateAuthorizedRPCClient()
        {
            var wc = new WebClient();
            wc.Headers.Add("Content-Type", "application/json-rpc");
            wc.Credentials = new NetworkCredential(_settings.UserName, _settings.Password);
            return wc;
        }
    }
}
