using Imdb.Helpers;
using Imdb.ViewModels;
using Windows.System;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Imdb.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MoviesView : BasePage
    {
        private MoviesViewModel moviesViewModel;

        public override string Header => "Movies";
        public MoviesView()
        {
            this.InitializeComponent();
            moviesViewModel = new MoviesViewModel();
        }

        private async void Search(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                await moviesViewModel.SearchForMovies();
            }
        }
    }
}
