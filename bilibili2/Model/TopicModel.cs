using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bilibili2.Model
{
    public class TopicRootModel
    {
        [JsonProperty("results")]
        public int Results { get; set; }
        [JsonProperty("list")]
        public List<TopicModel> List { get; set; }
    }
    public class TopicModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("img")]
        public string Img { get; set; }
        [JsonProperty("simg")]
        public string Simg { get; set; }
    }
}
