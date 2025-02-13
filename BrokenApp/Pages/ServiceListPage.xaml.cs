using BrokenApp.DataBase;
using BrokenApp.UserControlls;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BrokenApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServiceListPage.xaml
    /// </summary>
    public partial class ServiceListPage : Page
    {
        private IEnumerable<Service> _services;

        public ServiceListPage()
        {
            InitializeComponent();
            _services = App.DB.Service.Where(x => !x.IsRemoved);
            RefreshList();
        }

        private void RefreshList()
        {
            ServiceWrap.Children.Clear();

            foreach (Service service in _services)
            {
                ServiceWrap.Children.Add(new ServiceUserControl(service));
            }
        }

        private void AddNewServiceBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddServicePage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DistributionPage());
        }
    }
}
