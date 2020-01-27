using Imdb.Models;
using Imdb.Resources;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Imdb.Controls
{
    public sealed partial class MovieListControl : UserControl
    {
        public ObservableCollection<Movie> Movies
        {
            get { return (ObservableCollection<Movie>)GetValue(MoviesProperty); }
            set { SetValue(MoviesProperty, value); }
        }

        public static readonly DependencyProperty MoviesProperty =
            DependencyProperty.Register("Movies", typeof(ObservableCollection<Movie>), typeof(MovieListControl), new PropertyMetadata(default(Movie)));

        public MovieListControl()
        {
            this.InitializeComponent();
        }

        private void MovieHoverEntered(object sender, PointerRoutedEventArgs e)
        {
            var shadow = (sender as RelativePanel).Children[0] as DropShadowPanel;
            var image = shadow.Content as Image;
            shadow.ShadowOpacity = 0.4;
            image.Width = 205;
        }

        private void MovieHoverExited(object sender, PointerRoutedEventArgs e)
        {
            var shadow = (sender as RelativePanel).Children[0] as DropShadowPanel;
            var image = shadow.Content as Image;
            shadow.ShadowOpacity = 0.3;
            image.Width = 200;
        }

        private async void DetailedView(object sender, TappedRoutedEventArgs e)
        {
            var movie = (sender as RelativePanel).DataContext as Movie;

            DetailedMovieView detailedMovieView = new DetailedMovieView();
            var modal = detailedMovieView.ShowAsync();
            await detailedMovieView.modalViewModel.SetMedia(movie.ImdbId, "movie");
            await modal;
        }
    }
}
