using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bilibili2.Model
{
    public class BangumiTimeLineRootModel
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("count")]
        public string Count { get; set; }
        [JsonProperty("list")]
        public List<BangumiTimeLineModel> List { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
    public class BangumiTimeLineModel
    {
        [JsonProperty("area")]
        public string Area { get; set; }
        [JsonProperty("arealimit")]
        public int Arealimit { get; set; }
        [JsonProperty("attention")]
        public int Attention { get; set; }
        [JsonProperty("bangumi_id")]
        public int BangumiId { get; set; }
        [JsonProperty("bgmcount")]
        public string Bgmcount { get; set; }
        [JsonProperty("cover")]
        public string Cover { get; set; }
        [JsonProperty("danmaku_count")]
        public int DanmakuCount { get; set; }
        [JsonProperty("favorites")]
        public int Favorites { get; set; }
        [JsonProperty("is_finish")]
        public int IsFinish { get; set; }
        [JsonProperty("lastupdate")]
        public int Lastupdate { get; set; }
        [JsonProperty("lastupdate_at")]
        public string LastupdateAt { get; set; }
        [JsonProperty("new")]
        public bool New { get; set; }
        [JsonProperty("play_count")]
        public int PlayCount { get; set; }
        [JsonProperty("pub_time")]
        public string PubTime { get; set; }
        [JsonProperty("season_id")]
        public int SeasonId { get; set; }
        [JsonProperty("spid")]
        public int Spid { get; set; }
        [JsonProperty("square_cover")]
        public string SquareCover { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("viewRank")]
        public int ViewRank { get; set; }
        [JsonProperty("weekday")]
        public int Weekday { get; set; }
    }
}
