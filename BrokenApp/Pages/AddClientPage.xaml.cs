using BrokenApp.DataBase;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace BrokenApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        private byte[] _photoData;

        public AddClientPage()
        {
            InitializeComponent();
            GenderCB.ItemsSource = App.DB.Gender.ToList();
            GenderCB.DisplayMemberPath = "Name";
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e) =>
            NavigationService.GoBack();

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|All files (*.*)|*.*"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                _photoData = File.ReadAllBytes(openFile.FileName);
                PhotoIMG.Source = new BitmapImage(new Uri(openFile.FileName)); ;
            }
        }

        private void AddClientBtn_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client()
            {
                LastName = LastNameTB.Text,
                FirstName = FirstNameTB.Text,
                Patronymic = PatronymicTB.Text,
                Email = EmailTB.Text,
                Phone = PhoneNumberTB.Text,
                Birthday = DateTime.Parse(BirthdayDP.Text),
                RegistrationDate = DateTime.Parse(RegistationDP.Text),
                IsRemoved = false,
                PhotoBinary = _photoData,
                Gender = GenderCB.SelectedItem as Gender
            };
            App.DB.Client.Add(client);
            App.DB.SaveChanges();
            NavigationService.Navigate(new ClientListPage());
        }
    }
}
