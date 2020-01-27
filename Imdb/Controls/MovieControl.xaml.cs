using Imdb.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Imdb.Controls
{
    public sealed partial class MovieControl : UserControl
    {
        public Movie Movie
        {
            get { return (Movie)GetValue(MovieProperty); }
            set { SetValue(MovieProperty, value); }
        }

        public static readonly DependencyProperty MovieProperty =
            DependencyProperty.Register("Movie", typeof(Movie), typeof(MovieControl), new PropertyMetadata(default(Movie)));

        public MovieControl()
        {
            this.InitializeComponent();
        }
    }
}
