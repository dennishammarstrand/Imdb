using Imdb.Models;
using Imdb.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Imdb.Resources
{
    public sealed partial class DetailedMovieView : ContentDialog
    {
        public ModalViewModel<Movie> modalViewModel;

        public DetailedMovieView()
        {
            this.InitializeComponent();
            modalViewModel = new ModalViewModel<Movie>();
        }
    }
}
