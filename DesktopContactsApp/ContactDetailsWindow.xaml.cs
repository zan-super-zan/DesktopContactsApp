using DesktopContactsApp.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        private Contact _Contact;
        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();

            _Contact = contact;
            NameTextBox.Text = contact.Name;
            EmailTextBox.Text = contact.Email;
            PhoneNumberTextBox.Text = contact.PhoneNumber;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            _Contact.Name = NameTextBox.Text;
            _Contact.Email = EmailTextBox.Text;
            _Contact.PhoneNumber = PhoneNumberTextBox.Text;

            using (SQLiteConnection connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Contact>(); // Ignored if tabel exists
                connection.Update(_Contact);
            }

            Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Contact>(); // Ignored if tabel exists
                connection.Delete(_Contact);
            }

            Close();
        }
    }
}
