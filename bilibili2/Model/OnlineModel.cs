using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bilibili2.Model
{
    public class OnlineRootModel
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("msg")]
        public string Msg { get; set; }
        [JsonProperty("data")]
        public List<RoomModel> Data { get; set; }
    }
    public class RoomModel
    {
        [JsonProperty("roomid")]
        public string Roomid { get; set; }
        [JsonProperty("short_id")]
        public string ShortId { get; set; }
        [JsonProperty("uname")]
        public string Uname { get; set; }
        [JsonProperty("uid")]
        public string Uid { get; set; }
        [JsonProperty("area")]
        public string Area { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("cover")]
        public string Cover { get; set; }
        [JsonProperty("live_time")]
        public string LiveTime { get; set; }
        [JsonProperty("online")]
        public int Online { get; set; }
        [JsonProperty("user_cover")]
        public string UserCover { get; set; }
        [JsonProperty("sweetheart")]
        public string Sweetheart { get; set; }
        [JsonProperty("face")]
        public string Face { get; set; }
        [JsonProperty("master_level")]
        public int MasterLevel { get; set; }
        [JsonProperty("system_cover")]
        public string SystemCover { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
    }
}
