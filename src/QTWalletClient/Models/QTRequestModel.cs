using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace QTWalletClient.Models
{
    internal class QTRequestModel
    {
        [JsonProperty("jsonrpc")]
        public string JsonRPC { get; set; } = "1.0";

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params")]
        public string[] Params { get; set; }

        public QTRequestModel(string method, string[] args)
        {
            Id = Guid.NewGuid().ToString();
            Method = method;
            Params = args;
        }
    }
}
