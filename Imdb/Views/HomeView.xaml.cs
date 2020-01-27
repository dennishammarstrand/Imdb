using Imdb.Helpers;
using Imdb.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Imdb.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomeView : BasePage
    {
        private HomeViewModel HomeViewModel;
        public override string Header => "Home";
        public HomeView()
        {
            this.InitializeComponent();
            HomeViewModel = new HomeViewModel();
            SetMovie();
        }

        private async void SetMovie()
        {
            await HomeViewModel.SetMovie();
        }
    }
}
