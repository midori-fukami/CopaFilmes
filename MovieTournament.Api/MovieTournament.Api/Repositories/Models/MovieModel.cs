using Newtonsoft.Json;

namespace MovieTournament.Api.Repositories.Models
{
    public class MovieModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("titulo")]
        public string Title { get; set; }

        [JsonProperty("ano")]
        public int Year { get; set; }

        [JsonProperty("nota")]
        public double Score { get; set; }
    }
}
