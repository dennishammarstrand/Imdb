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
    public class SeriesViewModel : NotificationPropertyChangeBase
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

		private Series series;

		public Series Series
		{
			get { return series; }
			set
			{
				series = value;
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

		public async Task SearchForSeries()
		{
			GotResults = Visibility.Collapsed;

			Series = await ApiHandler<Series>.GetMedias(SearchText, 1, "series");

			if (Series.Search == null)
			{
				GotResults = Visibility.Visible;
			}
			else if (Series.Search.Count == 10)
			{
				ShowPagination = Visibility.Visible;
			}
			else if (Series.Search.Count < 10)
			{
				ShowPagination = Visibility.Collapsed;
			}
		}

		public async Task ChangeToNextPage()
		{
			Series = await ApiHandler<Series>.GetMedias(SearchText, NextPage, "series");
			Page++;
			NextPage++;
			PrevEnabled = true;
			if (Series.Search == null)
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
				Series = await ApiHandler<Series>.GetMedias(SearchText, Page, "series");
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
