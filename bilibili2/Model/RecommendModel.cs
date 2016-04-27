using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bilibili2.Model
{
    public class ReCommendModel
    {
        [JsonProperty("badgepay")]
        public bool Badgepay { get; set; }
        [JsonProperty("stow")]
        public int Stow { get; set; }
        [JsonProperty("pubdate")]
        public int Pubdate { get; set; }
        [JsonProperty("typeid")]
        public int Typeid { get; set; }
        [JsonProperty("editdate")]
        public int Editdate { get; set; }
        [JsonProperty("pic")]
        public string Pic { get; set; }
        [JsonProperty("author_name")]
        public string AuthorName { get; set; }
        [JsonProperty("click")]
        public string Click { get; set; }
        [JsonProperty("dm_count")]
        public int DmCount { get; set; }
        [JsonProperty("season_info")]
        public SeasonInfoModel SeasonInfo { get; set; }
        [JsonProperty("scores")]
        public int Scores { get; set; }
        [JsonProperty("duration")]
        public string Duration { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
    }
    public class SeasonInfoModel
    {
        [JsonProperty("pub_time")]
        public string PubTime { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("cover")]
        public string Cover { get; set; }
        [JsonProperty("season_id")]
        public int SeasonId { get; set; }
        [JsonProperty("pub_timestamp")]
        public int PubTimestamp { get; set; }
        [JsonProperty("ep_index")]
        public string EpIndex { get; set; }
        [JsonProperty("categories")]
        public List<string> Categories { get; set; }
        [JsonProperty("is_finish")]
        public bool IsFinish { get; set; }
    }

}
