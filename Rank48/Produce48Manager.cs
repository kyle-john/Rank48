using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rank48.Models;

namespace Rank48
{
    class Produce48Manager
    {
        public static Produce48Manager Instance => instance.Value;

        static Lazy<Produce48Manager> instance = new Lazy<Produce48Manager>();

        public Dictionary<string, Trainee> Trainees { get; set; }

        public Dictionary<string, Agency> Agencies { get; set; }

        public Dictionary<string, Ranking> Ranking { get; set; }

        public async Task InitializeAsync()
        {
            var (trainees, agencies) = await DownloadTraineesAndAgenciesAsync();
            Trainees = trainees;
            Agencies = agencies;

            var ranking = await DownloadRankingAsync();
            Ranking = ranking;
        }

        async Task<(Dictionary<string, Trainee>, Dictionary<string, Agency>)> DownloadTraineesAndAgenciesAsync()
        {
            string url = "http://onairimg.mnet.com/data/od/mnettv/resources/js/mnettv/data/gen/produce48/trainee.js?v=1529082320726";
            using (var client = new HttpClient())
            using (var response = await client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    // read response
                    string code = await response.Content.ReadAsStringAsync();

                    // parse json from js code
                    string[] temp = code.Split('\n');
                    string traineeJson = GetJson(temp[2]);
                    string agencyJson = GetJson(temp[3]);

                    // deserialize
                    var trainees = JsonConvert.DeserializeObject<Dictionary<string, Trainee>>(traineeJson);
                    var agencies = JsonConvert.DeserializeObject<Dictionary<string, Agency>>(agencyJson, Converter.Settings);

                    return (trainees, agencies);
                }
            }

            return (null, null);
        }

        async Task<Dictionary<string, Ranking>> DownloadRankingAsync()
        {
            string url = "http://onairimg.mnet.com/data/od/mnettv/resources/js/mnettv/data/gen/produce48/rank.js?v=1529082320726";
            using (var client = new HttpClient())
            using (var response = await client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    // read response
                    string code = await response.Content.ReadAsStringAsync();

                    // parse json from js code
                    code = code.Split('\n')[2];
                    string json = GetJson(code);

                    // deserialize
                    var ranking = JsonConvert.DeserializeObject<Dictionary<string, Ranking>>(json);
                    return ranking;
                }
            }

            return null;
        }

        static string GetJson(string jsCode)
        {
            int index = jsCode.IndexOf('=') + 1;
            jsCode = jsCode.Substring(index);
            return jsCode.Substring(0, jsCode.IndexOf(';'));
        }
    }
}
