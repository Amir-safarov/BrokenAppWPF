using BrokenApp.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml;

namespace BrokenApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientServiceListPage.xaml
    /// </summary>
    public partial class ClientServiceListPage : Page
    {
        private Client _client;
        public ClientServiceListPage(Client client)
        {
            InitializeComponent();
            _client = client;
            SericeList.ItemsSource = App.DB.ClientService.Where(x => x.ClientID == _client.ID).ToList();

        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientListPage());
        }
    }
}
