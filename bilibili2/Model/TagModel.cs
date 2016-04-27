using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bilibili2.Model
{
    public class TagRootModel
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("result")]
        public List<TagModel> Result { get; set; }
        [JsonProperty("total")]
        public int Total { get; set; }
    }
    public class TagModel
    {
        [JsonProperty("cover")]
        public string Cover { get; set; }
        [JsonProperty("index")]
        public string Index { get; set; }
        [JsonProperty("orderType")]
        public int OrderType { get; set; }
        [JsonProperty("tag_id")]
        public string TagId { get; set; }
        [JsonProperty("tag_name")]
        public string TagName { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
