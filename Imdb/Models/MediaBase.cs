using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.Models
{
    public abstract class MediaBase
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
        public string Genre { get; set; }
        public string Runtime { get; set; }

        [JsonProperty("imdbRating")]
        public string ImdbRating { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Awards { get; set; }
        [JsonProperty("imdbId")]
        public string ImdbId { get; set; }
    }
}
