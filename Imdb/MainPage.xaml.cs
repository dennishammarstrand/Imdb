using Imdb.ViewModels;
using Imdb.Views;
using System.Linq;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Imdb
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Nav_Selection(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var route = (args.SelectedItem as NavigationViewItem).Content;
            Navigate(route);
        }

        private void InitialSelection(object sender, RoutedEventArgs e)
        {
            foreach (NavigationViewItemBase item in NavView.MenuItems)
            {
                if (item is NavigationViewItem && item.Content.ToString() == "Home")
                {
                    NavView.SelectedItem = item;
                    break;
                }
            }
        }

        private void Nav_Invoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
            Navigate(item.Content);
        }

        private void Navigate(object route)
        {
            switch (route)
            {
                case "Home":
                    MainFrame.Navigate(typeof(HomeView));
                    break;
                case "Movies":
                    MainFrame.Navigate(typeof(MoviesView));
                    break;
                case "Series":
                    MainFrame.Navigate(typeof(SeriesView));
                    break;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            SetTitleBarBackground();
        }

        private void SetTitleBarBackground()
        {
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;

            titleBar.BackgroundColor = Color.FromArgb(255, 99, 99, 99);
            titleBar.ForegroundColor = Color.FromArgb(255, 0, 0, 0);
            titleBar.ButtonBackgroundColor = Color.FromArgb(255, 99, 99, 99);
            titleBar.ButtonForegroundColor = Color.FromArgb(255, 0, 0, 0);
            titleBar.InactiveBackgroundColor = Color.FromArgb(255, 99, 99, 99);
            titleBar.InactiveForegroundColor = Color.FromArgb(255, 0, 0, 0);
            titleBar.ButtonInactiveBackgroundColor = Color.FromArgb(255, 99, 99, 99);
            titleBar.ButtonInactiveForegroundColor = Color.FromArgb(255, 0, 0, 0);
        }
    }
}
