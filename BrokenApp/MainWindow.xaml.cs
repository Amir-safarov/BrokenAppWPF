using BrokenApp.Pages;
using System.Windows;
using System.Windows.Controls;

namespace BrokenApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Current;
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new ClientListPage());
            if (Current == null)
                Current = this;
            else
                return;
            //foreach (var item in App.DB.Client.ToArray())
            //{
            //    item.PhotoBinary = File.ReadAllBytes("C:\\Users\\AMIR\\Desktop\\Поломка\\данные\\Клиенты\\"+item.PhotoPath);
            //}
            //App.DB.SaveChanges();
        }

        public void Naviagate(Page page) =>
            MainFrame.NavigationService.Navigate(page);
    }
}
