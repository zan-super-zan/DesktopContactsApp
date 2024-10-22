using DesktopContactsApp.Classes;
using SQLite;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> _Contacts;

        public MainWindow()
        {
            InitializeComponent();
            _Contacts = new List<Contact>();
            ReadDatabase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();

            ReadDatabase();
        }
        void ReadDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Contact>();
                _Contacts = (connection.Table<Contact>().ToList()).OrderBy(c => c.Name).ToList(); // Retrives the table
            }

            if (_Contacts != null)
                ContactsListView.ItemsSource = _Contacts;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox? searchTextBox = sender as TextBox;
            if (searchTextBox == null)
                return;

            var filteredList = _Contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            ContactsListView.ItemsSource = filteredList;
        }

        private void ContactListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact? selectedContact = ContactsListView.SelectedItem as Contact;

            if(selectedContact == null) 
                return;

            ContactDetailsWindow contactDetailsWidnow = new ContactDetailsWindow(selectedContact);
            contactDetailsWidnow.ShowDialog();
            ReadDatabase();
        }
    }
}