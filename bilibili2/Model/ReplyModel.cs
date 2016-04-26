using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bilibili2.Model
{
    public class PageModel
    {
        [JsonProperty("acount")]
        public int Acount { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("num")]
        public int Num { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
    }
    public class LevelInfoModel
    {
        [JsonProperty("current_level")]
        public int CurrentLevel { get; set; }
        [JsonProperty("current_min")]
        public int CurrentMin { get; set; }
        [JsonProperty("current_exp")]
        public int CurrentExp { get; set; }
        [JsonProperty("next_exp")]
        public int NextExp { get; set; }
    }
    public class PendantModel
    {
        [JsonProperty("pid")]
        public int Pid { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("expire")]
        public int Expire { get; set; }
    }
    public class NameplateModel
    {
        [JsonProperty("nid")]
        public int Nid { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
    }
    public class MemberModel
    {
        [JsonProperty("mid")]
        public string Mid { get; set; }
        [JsonProperty("uname")]
        public string Uname { get; set; }
        [JsonProperty("sex")]
        public string Sex { get; set; }
        [JsonProperty("sign")]
        public string Sign { get; set; }
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
        [JsonProperty("rank")]
        public string Rank { get; set; }
        [JsonProperty("DisplayRank")]
        public string DisplayRank { get; set; }
        [JsonProperty("level_info")]
        public LevelInfoModel LevelInfo { get; set; }
        [JsonProperty("pendant")]
        public PendantModel Pendant { get; set; }
        [JsonProperty("nameplate")]
        public NameplateModel Nameplate { get; set; }
    }
    public class ContentModel
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("plat")]
        public int Plat { get; set; }
        [JsonProperty("device")]
        public string Device { get; set; }
        [JsonProperty("members")]
        public IEnumerable<object> Members { get; set; }
    }
    public class ReplyModel
    {
        [JsonProperty("rpid")]
        public int Rpid { get; set; }
        [JsonProperty("oid")]
        public int Oid { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("mid")]
        public int Mid { get; set; }
        [JsonProperty("root")]
        public int Root { get; set; }
        [JsonProperty("parent")]
        public int Parent { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("rcount")]
        public int Rcount { get; set; }
        [JsonProperty("floor")]
        public int Floor { get; set; }
        [JsonProperty("state")]
        public int State { get; set; }
        [JsonProperty("ctime")]
        public int Ctime { get; set; }
        [JsonProperty("rpid_str")]
        public string RpidStr { get; set; }
        [JsonProperty("root_str")]
        public string RootStr { get; set; }
        [JsonProperty("parent_str")]
        public string ParentStr { get; set; }
        [JsonProperty("like")]
        public int Like { get; set; }
        [JsonProperty("action")]
        public int Action { get; set; }
        [JsonProperty("member")]
        public MemberModel Member { get; set; }
        [JsonProperty("content")]
        public ContentModel Content { get; set; }
        [JsonProperty("replies")]
        public IEnumerable<ReplyModel> Replies { get; set; }
    }
    public class DataModel
    {
        [JsonProperty("need_captcha")]
        public bool NeedCaptcha { get; set; }
        [JsonProperty("page")]
        public PageModel Page { get; set; }
        [JsonProperty("replies")]
        public IEnumerable<ReplyModel> Replies { get; set; }
    }
    public class ReplyRootModel
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("data")]
        public DataModel Data { get; set; }
    }
}
