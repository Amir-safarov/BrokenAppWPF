using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BrokenApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для DistributionPage.xaml
    /// </summary>
    public partial class DistributionPage : Page
    {
        public DistributionPage()
        {
            InitializeComponent();
        }

        private void ClientListBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientListPage());
        }

        private void ServiceListBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ServiceListPage());

        }

        private void ClientServiceListBTN_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new ClientServiceListPage());

        }
    }
}
