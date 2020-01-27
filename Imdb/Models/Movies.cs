using Imdb.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.Models
{
    public class Movies : IMedia
    {
        public ObservableCollection<Movie> Search { get; set; }
    }
}
