using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bilibili2.Model
{
    public class HotRootModel
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("seid")]
        public string Seid { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }
        [JsonProperty("list")]
        public List<HotListModel> List { get; set; }
        [JsonProperty("cost")]
        public CostModel Cost { get; set; }
    }
    public class HotListModel
    {
        [JsonProperty("keyword")]
        public string Keyword { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
    public class CostModel
    {
        [JsonProperty("timer")]
        public string Timer { get; set; }
        [JsonProperty("total")]
        public string Total { get; set; }
        [JsonProperty("read file")]
        public string Readfile { get; set; }
    }
}
