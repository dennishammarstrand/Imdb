using Imdb.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.Models
{
    public class Serie : MediaBase ,IMedia
    {
        [JsonProperty("totalSeasons")]
        public string TotalSeasons { get; set; }
    }
}
