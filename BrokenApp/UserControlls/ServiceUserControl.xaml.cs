using BrokenApp.DataBase;
using BrokenApp.Pages;
using System;
using System.Data.Entity.Migrations.Model;
using System.Windows;
using System.Windows.Controls;

namespace BrokenApp.UserControlls
{
    /// <summary>
    /// Логика взаимодействия для ServiceUserControl.xaml
    /// </summary>
    public partial class ServiceUserControl : UserControl
    {
        private Service _service;
        public ServiceUserControl(Service service)
        {
            InitializeComponent();
            _service = service;
            UpdateData();
        }

        private void UpdateData()
        {
            ServiceNameTB.Text = _service.Title;
            ServiceDurationTB.Text = _service.DurationInSeconds.ToString();
            SaleTB.Text = _service.Discount.ToString();
            PriceTB.Text = _service.Cost.ToString();
            SalePriceTB.Text = $"{_service.Cost - (_service.Cost * (decimal)_service.Discount / 100)}";
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            _service.IsRemoved = true;
            App.DB.SaveChanges();
            MainWindow.Current.Naviagate(new ServiceListPage());
        }

        private void SaleCounter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(PriceTB.Text) || string.IsNullOrEmpty(SaleTB.Text))
                return;
            SalePriceTB.Text = $"{_service.Cost - (_service.Cost * (decimal)_service.Discount / 100)}";
        }

        private void Interactable_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ServiceNameTB.Text))
                _service.Title = ServiceNameTB.Text;
            if (int.TryParse(ServiceDurationTB.Text, out int duration))
                _service.DurationInSeconds = duration;
            if (double.TryParse(SaleTB.Text, out double sale ))
                _service.Discount = sale;
            if (decimal.TryParse(SaleTB.Text, out decimal price ))
                _service.Cost = price;
            App.DB.SaveChanges();
        }

    }
}
