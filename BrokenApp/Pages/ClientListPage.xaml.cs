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
        private List<Client> _allClients; 
        private IEnumerable<Client> _filteredClients; 

        public ClientListPage()
        {
            InitializeComponent();

            _allClients = App.DB.Client.Where(x => !x.IsRemoved).ToList();
            _filteredClients = _allClients;

            RefreshList();
        }

        private void AddNewClientBtn_Click(object sender, System.Windows.RoutedEventArgs e) =>
            NavigationService.Navigate(new AddClientPage());

        private void FIOFilterTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = FIOFilterTB.Text.ToLower().Trim();

            _filteredClients = _allClients.Where(x =>
                x.LastName.ToLower().Contains(searchText) ||
                x.FirstName.ToLower().Contains(searchText) ||
                x.Patronymic.ToLower().Contains(searchText) ||
                $"{x.LastName} {x.FirstName} {x.Patronymic}".ToLower().Contains(searchText)
            );

            RefreshList();
        }

        private void RefreshList()
        {
            ClientWrap.Children.Clear(); 

            foreach (Client client in _filteredClients)
            {
                ClientWrap.Children.Add(new CLientUserControl(client));
            }
        }
    }
}
