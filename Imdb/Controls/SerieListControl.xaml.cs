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
    public sealed partial class SerieListControl : UserControl
    {
        public ObservableCollection<Serie> Series
        {
            get { return (ObservableCollection<Serie>)GetValue(SeriesProperty); }
            set { SetValue(SeriesProperty, value); }
        }

        public static readonly DependencyProperty SeriesProperty =
            DependencyProperty.Register("Series", typeof(ObservableCollection<Serie>), typeof(SerieListControl), new PropertyMetadata(default(Serie)));

        public SerieListControl()
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
            var serie = (sender as RelativePanel).DataContext as Serie;

            DetailedSerieView detailedSerieView = new DetailedSerieView();
            var modal = detailedSerieView.ShowAsync();
            await detailedSerieView.modalViewModel.SetMedia(serie.ImdbId, "series");
            await modal;
        }
    }
}
