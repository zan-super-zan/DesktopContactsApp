﻿using DesktopContactsApp.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopContactsApp.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {


        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(new Contact()
            {
                Name = "Fullname",
                Email = "example@domain.com",
                PhoneNumber = "123 456 789"
            }, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl? contactControl = d as ContactControl;

            if (contactControl == null)
                return;

            Contact? contact = e.NewValue as Contact;
            if (contact == null)
                return;

            contactControl.NameTextBlock.Text = contact.Name;
            contactControl.EmailTextBlock.Text = contact.Email;
            contactControl.PhoneNumberTextBlock.Text = contact.PhoneNumber;
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
