using BrokenApp.DataBase;
using System.IO;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using BrokenApp.Pages;
using Microsoft.Win32;
using System.Windows.Navigation;

namespace BrokenApp.UserControlls
{
    /// <summary>
    /// Логика взаимодействия для CLientUserControl.xaml
    /// </summary>
    public partial class CLientUserControl : UserControl
    {
        private Client _cLient;

        public CLientUserControl(Client cLient)
        {
            InitializeComponent();
            _cLient = cLient;
            UpdateClientData();
        }

        private void UpdateClientData()
        {
            PhotoIMG.Source = GetimageSources(_cLient.PhotoBinary);
            LastNameTB.Text = _cLient.LastName;
            FirstNameTB.Text = _cLient.FirstName;
            PatronymicTB.Text = _cLient.Patronymic;
            EmailTB.Text = _cLient.Email;
            PhoneNumberTB.Text = _cLient.Phone;
            BirthdayDP.Text = _cLient.Birthday.ToString();
            RegistationDP.Text = _cLient.RegistrationDate.ToString();
        }

        private BitmapImage GetimageSources(byte[] byteImage)
        {
            if (byteImage != null)
            {
                MemoryStream memoryStream = new MemoryStream(byteImage);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = memoryStream;
                image.EndInit();
                return image;
            }
            else
                return new BitmapImage(new Uri(@"\Resource\analys.png", UriKind.Relative));
        }

        private void DelBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _cLient.IsRemoved = true;
            App.DB.SaveChanges();
            MainWindow.Current.Naviagate(new ClientListPage());
        }

        private void EditImageBtn_Click(object sender, System.Windows.RoutedEventArgs e) =>
            EditImage();
        private void Interactable_LostFocus(object sender, System.Windows.RoutedEventArgs e) =>
            SaveChanges();

        private void EditImage()
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|All files (*.*)|*.*"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                _cLient.PhotoBinary = File.ReadAllBytes(openFile.FileName);
                PhotoIMG.Source = new BitmapImage(new Uri(openFile.FileName)); ;
            }
            App.DB.SaveChanges();
        }


        private void SaveChanges()
        {
            _cLient.LastName = LastNameTB.Text;
            _cLient.FirstName = FirstNameTB.Text;
            _cLient.Patronymic = PatronymicTB.Text;
            _cLient.Email = EmailTB.Text;
            _cLient.Phone = PhoneNumberTB.Text;
            _cLient.Birthday = DateTime.Parse(BirthdayDP.Text); 
            _cLient.RegistrationDate = DateTime.Parse(RegistationDP.Text);
            App.DB.SaveChanges();
        }

        private void RegClientsServicesBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.Current.Naviagate(new ClientServiceListPage(_cLient));
        }
    }
}
