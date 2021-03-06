﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        string aword;
        [JsonProperty("aWord")]
        public string AWord 
        { 
            get => aword; 
            set 
            {
                aword = value.Replace("<br> ", "\n");
            }
        }

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

        Dictionary<string, int> rankings;
        public Dictionary<string, int> GetRankings() 
        {
            if (rankings == null)
            { 
                var manager = Produce48Manager.Instance;

                var ranks = (from x in manager.Ranking
                            select (key: x.Key, ranking: x.Value.Ranks.First(y => y.TraineeId == Id).Ranking))
                           .ToDictionary(x => x.key, x => x.ranking);
                
                rankings = ranks;
            }

            return rankings;
        }

        public int GetRankingUpdatedCount(string week)
        {
            var ranks = GetRankings();

            if (week == "1")
                return 0;

            int previous = ranks[$"{int.Parse(week) - 1}"];
            int current = ranks[week];

            return previous - current;
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
