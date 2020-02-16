using System;
using System.Windows;

namespace NAZAR_LAB
{
    /// <summary>
    /// Interaction logic for ProfileSearchWindow.xaml
    /// </summary>
    public partial class ProfileSearchWindow : Window
    {
        static private string UserLogin;
        
        public static string GetUser()
        {
            return UserLogin;
        }

        public ProfileSearchWindow(string current_Uset_Login)
        {
            InitializeComponent();
            UserLogin = current_Uset_Login;
        }

        private void Button_Click_Profile(object sender, RoutedEventArgs e)
        {
            frame.Source = new Uri("Profile.xaml", UriKind.Relative);
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            frame.Source = new Uri("Search.xaml", UriKind.Relative);
        }
    }
}

