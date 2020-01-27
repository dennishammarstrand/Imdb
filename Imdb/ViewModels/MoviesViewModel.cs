using Imdb.Helpers;
using Imdb.Models;
using Imdb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Imdb.ViewModels
{
    public class MoviesViewModel : NotificationPropertyChangeBase
	{
		private string searchText;

		public string SearchText
		{
			get { return searchText; }
			set 
			{
				searchText = value;
				NotifyPropertyChanged();
			}
		}

		private Movies movies;

		public Movies Movies
		{
			get { return movies; }
			set 
			{
				movies = value;
				NotifyPropertyChanged();
			}
		}

		private Visibility gotResults = Visibility.Collapsed;

		public Visibility GotResults
		{
			get { return gotResults; }
			set 
			{
				gotResults = value;
				NotifyPropertyChanged();
			}
		}

		private int page = 1;

		public int Page
		{
			get { return page; }
			set 
			{
				page = value;
				NotifyPropertyChanged();
			}
		}

		private int nextPage = 2;

		public int NextPage
		{
			get { return nextPage; }
			set 
			{
				nextPage = value;
				NotifyPropertyChanged();
			}
		}

		private bool prevEnabled = false;

		public bool PrevEnabled
		{
			get { return prevEnabled; }
			set 
			{
				prevEnabled = value;
				NotifyPropertyChanged();
			}
		}

		private bool nextEnabled = true;

		public bool NextEnabled
		{
			get { return nextEnabled; }
			set 
			{
				nextEnabled = value;
				NotifyPropertyChanged();
			}
		}


		private Visibility showPagination = Visibility.Collapsed;

		public Visibility ShowPagination
		{
			get { return showPagination; }
			set 
			{
				showPagination = value;
				NotifyPropertyChanged();
			}
		}



		public async Task SearchForMovies()
		{
			GotResults = Visibility.Collapsed;

			Movies = await ApiHandler<Movies>.GetMedias(SearchText, 1, "movie");

			if (Movies.Search == null)
			{
				GotResults = Visibility.Visible;
			}
			else if (Movies.Search.Count == 10)
			{
				ShowPagination = Visibility.Visible;
			}
			else if (Movies.Search.Count < 10)
			{
				ShowPagination = Visibility.Collapsed;
			}

		}

		public async Task ChangeToNextPage()
		{
			Movies = await ApiHandler<Movies>.GetMedias(SearchText, NextPage, "movie");
			Page++;
			NextPage++;
			PrevEnabled = true;
			if (Movies.Search == null)
			{
				NextEnabled = false;
				GotResults = Visibility.Visible;
			}
		}

		public async Task ChangeToPreviousPage()
		{
			if (Page >= 2)
			{
				Page--;
				NextPage--;
				Movies = await ApiHandler<Movies>.GetMedias(SearchText, Page, "movie");
				NextEnabled = true;
				GotResults = Visibility.Collapsed;
			}
			if (Page == 1)
			{
				PrevEnabled = false;
			}
		}
	}
}
