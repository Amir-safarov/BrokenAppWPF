using BrokenApp.DataBase;
using BrokenApp.UserControlls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace BrokenApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientListPage.xaml
    /// </summary>
    public partial class ClientListPage : Page
    {
        private IEnumerable<Client> _clients; 

        public ClientListPage()
        {
            InitializeComponent();

            _clients = App.DB.Client.Where(x => !x.IsRemoved).ToList();

            RefreshList();
        }

        private void AddNewClientBtn_Click(object sender, System.Windows.RoutedEventArgs e) =>
            NavigationService.Navigate(new AddClientPage());

        private void RefreshList()
        {
            ClientWrap.Children.Clear(); 

            foreach (Client client in _clients)
            {
                ClientWrap.Children.Add(new CLientUserControl(client));
            }
        }

        private void ExitBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new DistributionPage());
        }
    }
}
