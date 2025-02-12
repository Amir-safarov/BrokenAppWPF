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
        private Client _client = null;
        private List<Client> _clientList;
        public ClientServiceListPage()
        {
            InitializeComponent();
            _clientList = App.DB.Client.ToList();
            Client client = new Client()
            {
                LastName = "",
                FirstName = "Все",
                Patronymic = "",
                Email = "",
                Phone = "",
                Birthday = DateTime.Now,
                RegistrationDate = DateTime.Now,
                IsRemoved = false,
                PhotoBinary = null,
                Gender = App.DB.Gender.FirstOrDefault(),
            };
            _clientList.Insert(0, client);
            ClientsCB.ItemsSource = _clientList;
            ClientsCB.DisplayMemberPath = "FirstName";
            ClientsCB.SelectedIndex = 0;
            Refresh();
        }

        private void Refresh()
        {
            if (_client.FirstName == "Все")
                SericeList.ItemsSource = App.DB.ClientService.ToList();
            else
                SericeList.ItemsSource = App.DB.ClientService.Where(x => x.ClientID == _client.ID).ToList();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientListPage());
        }

        private void ClientsCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _client = ClientsCB.SelectedItem as Client;
            Refresh();
        }
    }
}
