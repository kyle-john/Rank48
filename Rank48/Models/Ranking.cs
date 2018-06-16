using System;
using Newtonsoft.Json;

namespace Rank48.Models
{
    public class Ranking
    {
        [JsonProperty("ranks")]
        public Rank[] Ranks { get; set; }

        //[JsonProperty("template")]
        //public string Template { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        //[JsonProperty("count")]
        //public bool Count { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("active")]
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Rank
    {
        [JsonProperty("r")]
        public int Ranking { get; set; }

        [JsonProperty("t")]
        public string TraineeId { get; set; }

        //[JsonProperty("c")]
        //public string C { get; set; }

        //[JsonProperty("d")]
        //public bool D { get; set; }

        //[JsonProperty("dd")]
        //public string Dd { get; set; }
    }
}
