using Imdb.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.Models
{
    public class Series : IMedia
    {
        public ObservableCollection<Serie> Search { get; set; }
    }
}
