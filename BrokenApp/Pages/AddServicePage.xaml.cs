using BrokenApp.DataBase;
using System.Text;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BrokenApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddServicePage.xaml
    /// </summary>
    public partial class AddServicePage : Page
    {
        public AddServicePage()
        {
            InitializeComponent();
        }

        private void AddClientBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (string.IsNullOrWhiteSpace(PriceTB.Text))
                stringBuilder.AppendLine("Введите цену услуги");
            if (string.IsNullOrWhiteSpace(ServiceDurationTB.Text))
                stringBuilder.AppendLine("Введите продолжительность услуги");
            if (string.IsNullOrWhiteSpace(ServiceNameTB.Text))
                stringBuilder.AppendLine("Введите наименование услуги");
            if (stringBuilder.Length > 0)
            {
                MessageBox.Show($"{stringBuilder}", "Ошибка");
                return;
            }
            else
            {
                double sale = 0;
                if (double.TryParse(SaleTB.Text, out double result))
                    sale = result;
                Service service = new Service()
                {
                    Cost = decimal.Parse(PriceTB.Text),
                    DurationInSeconds = int.Parse(ServiceDurationTB.Text),
                    IsRemoved = false,
                    Title = ServiceNameTB.Text,
                    Discount = sale
                };
                App.DB.Service.Add(service);
                App.DB.SaveChanges();
                NavigationService.Navigate(new ServiceListPage());
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ServiceListPage());
        }

        private void Digit_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
        }
    }
}
