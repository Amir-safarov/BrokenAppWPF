using BrokenApp.DataBase;
using System.Windows;

namespace BrokenApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static BrokenEntities3 DB = new BrokenEntities3();
    }
}
