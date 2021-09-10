using MyDatingAppH2.ViewModels;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyDatingAppH2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProfilePage : Page
    {
        private ProfilePageViewModel defaultViewModel = new ProfilePageViewModel();

        public ProfilePage()
        {
            this.InitializeComponent();

            this.DataContext = defaultViewModel;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            App.TryGoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            defaultViewModel.Email = (string)e.Parameter;
            defaultViewModel.HentData();

            base.OnNavigatedTo(e);
        }

    }
}
