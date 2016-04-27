using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bilibili2.Model
{
    public class LoginModel
    {
        [JsonProperty("ts")]
        public int Ts { get; set; }
        [JsonProperty("mid")]
        public int Mid { get; set; }
        [JsonProperty("access_key")]
        public string AccessKey { get; set; }
        [JsonProperty("expires")]
        public int Expires { get; set; }
        [JsonProperty("code")]
        public int Code { get; set; }
    }
}
