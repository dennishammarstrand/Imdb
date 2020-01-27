using Imdb.Helpers;
using Imdb.Interfaces;
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
    public class ModalViewModel<TMedia> : NotificationPropertyChangeBase, IMedia where TMedia : class, IMedia
    {
		private TMedia detailedMedia;

		public TMedia DetailedMedia
		{
			get { return detailedMedia; }
			set 
			{
				detailedMedia = value;
				NotifyPropertyChanged();
			}
		}

		private Visibility isLoading;

		public Visibility IsLoading
		{
			get { return isLoading; }
			set 
			{
				isLoading = value;
				NotifyPropertyChanged();
			}
		}

		public async Task SetMedia(string id, string type)
		{
			IsLoading = Visibility.Visible;
			var loading = ApiHandler<TMedia>.GetMediaById(id, type);
			await Task.Delay(1000);
			DetailedMedia = await loading;
			IsLoading = Visibility.Collapsed;
		}
	}
}
