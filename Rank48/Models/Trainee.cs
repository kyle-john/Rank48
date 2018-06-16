using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Rank48.Models
{
    public class Trainee
    {
        [JsonProperty("spec")]
        public string Spec { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("bType")]
        public string BloodType { get; set; }

        [JsonProperty("drop")]
        public bool IsDrop { get; set; }

        [JsonProperty("hobby")]
        public string Hobby { get; set; }

        [JsonProperty("agency")]
        public string AgencyId { get; set; }

        public Agency Agency { get => Produce48Manager.Instance.Agencies[AgencyId]; }

        public string AgencyName => Agency.Name;

        [JsonProperty("image")]
        public string ImageUrl { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }

        [JsonProperty("clips")]
        public Video[] Clips { get; set; }

        [JsonProperty("mainImage")]
        public string MainImageUrl { get; set; }

        [JsonProperty("eName")]
        public string EnglishName { get; set; }

        [JsonProperty("photos")]
        public Photo[] Photos { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("open")]
        public bool IsOpen { get; set; }

        // 각오 한마디
        [JsonProperty("aWord")]
        public string AWord { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("nick")]
        public string Nick { get; set; }

        [JsonProperty("age")]
        public string YearOfBirth { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("vods")]
        public Video[] Vods { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Video
    {
        [JsonProperty("CLIP_ID")]
        public string ClipId { get; set; }

        [JsonProperty("CLIP_TYPE_CD")]
        public string ClipTypeCd { get; set; }

        [JsonProperty("BROAD_YMD")]
        public string BroadYmd { get; set; }

        [JsonProperty("RUNNING_TIME")]
        public DateTimeOffset RunningTime { get; set; }

        [JsonProperty("CLIP_TITLE")]
        public string ClipTitle { get; set; }

        [JsonProperty("CLIP_INTRO")]
        public string ClipIntro { get; set; }

        [JsonProperty("IMG_URL")]
        public string ImageUrl { get; set; }
    }

    public class Photo
    {
        [JsonProperty("photo")]
        public string Url { get; set; }
    }
}
