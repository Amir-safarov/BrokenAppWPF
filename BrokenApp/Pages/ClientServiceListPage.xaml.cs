using BrokenApp.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BrokenApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientServiceListPage.xaml
    /// </summary>
    public partial class ClientServiceListPage : Page
    {
        private List<Client> _clientList;
        public ClientServiceListPage()
        {
            InitializeComponent();
            _clientList = App.DB.Client.ToList();
            ClientsCB.ItemsSource = _clientList;
            ClientsCB.DisplayMemberPath = "FirstName";
            Refresh();
        }

        private void Refresh()
        {
            Client client = ClientsCB.SelectedItem as Client;
            if (client == null)
                return;
            SericeList.ItemsSource = App.DB.ClientService.Where(x => x.ClientID == client.ID).ToList();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientListPage());
        }

        private void ClientsCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
