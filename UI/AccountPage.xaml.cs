using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MyDatingAppH2.ViewModels;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyDatingAppH2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountPage : Page
    {
        private AccountPageViewModel accountViewModel = new AccountPageViewModel();

        public AccountPage()
        {
            this.InitializeComponent();

            this.DataContext = accountViewModel;
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            if (accountViewModel.IsUserValid())
            {
                string param = accountViewModel.Email;
                //string param = JsonConvert.SerializeObject(myClass);

                this.Frame.Navigate(typeof(ProfilePage), param);
            }
        }

        // Button to navigate to sub.xaml page.
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to sub.xaml page.
            this.Frame.Navigate(typeof(CreateAccountPage));
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            this.accountViewModel.Password = passwordBox.Password;
        }
    }
}
