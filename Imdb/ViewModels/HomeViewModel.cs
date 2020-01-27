using Imdb.Helpers;
using Imdb.Models;
using Imdb.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.ViewModels
{
    public class HomeViewModel : NotificationPropertyChangeBase
    {
        private Movie movie;

        public Movie Movie
        {
            get { return movie; }
            set 
            {
                movie = value;
                NotifyPropertyChanged();
            }
        }

        public async Task SetMovie()
        {
            string[] movies = new string[8] 
            {
                "Fight Club",
                "300",
                "Interstellar",
                "The wolf of Wall Street",
                "Inception",
                "The Dark Knight",
                "Lord of The Rings",
                "Pulp Fiction"
            };
            Random rnd = new Random();
            int index = rnd.Next(0, 8);
            Movie = await ApiHandler<Movie>.GetMedia(movies[index], "movie");
        }
	}
}
