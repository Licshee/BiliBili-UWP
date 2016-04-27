using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bilibili2.Model
{
    public class HomeLiveRootModel
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public HomeLiveDataModel Data { get; set; }
    }
    public class HomeLiveDataModel
    {
        [JsonProperty("banner")]
        public List<HomeLiveBannerModel> Banner { get; set; }
        [JsonProperty("entranceIcons")]
        public List<EntranceIconModel> EntranceIcons { get; set; }
        [JsonProperty("partitions")]
        public List<PartitionModel> Partitions { get; set; }
    }
    public class HomeLiveBannerModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("img")]
        public string Img { get; set; }
        [JsonProperty("remark")]
        public string Remark { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
    }
    public class EntranceIconModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("entrance_icon")]
        public IconDataModel EntranceIcon { get; set; }
    }
    public class IconDataModel
    {
        [JsonProperty("src")]
        public string Src { get; set; }
        [JsonProperty("height")]
        public string Height { get; set; }
        [JsonProperty("width")]
        public string Width { get; set; }
    }
    public class PartitionModel
    {
        [JsonProperty("partition")]
        public PartitionDataModel Partition { get; set; }
        [JsonProperty("lives")]
        public List<LifeModel> Lives { get; set; }
    }
    public class PartitionDataModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("area")]
        public string Area { get; set; }
        [JsonProperty("sub_icon")]
        public IconDataModel SubIcon { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
    }
    public class LifeModel
    {
        [JsonProperty("owner")]
        public OwnerModel Owner { get; set; }
        [JsonProperty("cover")]
        public CoverModel Cover { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("room_id")]
        public int RoomId { get; set; }
        [JsonProperty("online")]
        public int Online { get; set; }
    }
    public class OwnerModel
    {
        [JsonProperty("face")]
        public string Face { get; set; }
        [JsonProperty("mid")]
        public int Mid { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public class CoverModel
    {
        [JsonProperty("src")]
        public string Src { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
    }

}
