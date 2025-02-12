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
        private IEnumerable<Service> _allservices;
        private IEnumerable<Service> _filteredServices;

        public ServiceListPage()
        {
            InitializeComponent();
            _allservices = App.DB.Service.ToList();
            _filteredServices = _allservices.Where(x => !x.IsRemoved);
            RefreshList();
        }

        private void RefreshList()
        {
            ServiceWrap.Children.Clear();

            foreach (Service service in _filteredServices)
            {
                ServiceWrap.Children.Add(new ServiceUserControl(service));
            }
        }

        private void AddNewServiceBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddServicePage());
        }

        private void NameFilterTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = NameFilterTB.Text.ToLower().Trim();

            _filteredServices = _allservices.Where(x => !x.IsRemoved &&
                $"{x.Title}".ToLower().Contains(searchText)
            );
            RefreshList();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DistributionPage());
        }
    }
}
