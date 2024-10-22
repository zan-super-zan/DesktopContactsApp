using System.Configuration;
using System.Data;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly static string DatabaseName = "Contacts.db";
        private readonly static string FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public  readonly static string DatabasePath = System.IO.Path.Combine(FolderPath, DatabaseName);
    }

}
