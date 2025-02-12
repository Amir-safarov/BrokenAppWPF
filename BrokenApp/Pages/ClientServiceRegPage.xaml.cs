using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using BrokenApp.DataBase;

namespace BrokenApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientServiceRegPage.xaml
    /// </summary>
    public partial class ClientServiceRegPage : Page
    {
        private Client _client;

        public ClientServiceRegPage(Client client)
        {
            InitializeComponent();
            _client = client;
            ClientNameTB.Text = $"Клиент: {_client.LastName} {_client.FirstName3} {_client.Patronymic}";
            ServiceCB.ItemsSource = App.DB.Service.ToList();
            ServiceCB.DisplayMemberPath = "Title";
        }

        private void AddServiceBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (DateTime.Parse(StartDateCB.Text) < DateTime.Now)
                error.AppendLine("Дата уже прошла");
            if (ServiceCB.SelectedItem == null)
                error.AppendLine("Услуга не выбрана");
            if (error.Length > 0)
            {
                MessageBox.Show($"{error}", "Ошибка заполнения данных");
                return;
            }
            else
            {
                ClientService clientService = new ClientService()
                {
                    ClientID = _client.ID,
                    ServiceID = (ServiceCB.SelectedItem as Service).ID,
                    StartTime = DateTime.Parse(StartDateCB.Text),
                    Comment = ComentTB.Text,
                };
                App.DB.ClientService.Add(clientService);
                App.DB.SaveChanges();
                NavigationService.Navigate(new ClientListPage());
            }
        }
    }
}
