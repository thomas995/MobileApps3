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
using MVVMJSON.ViewModel;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MVVMJSON
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent(); // allows the code to be read into the app once its running
            ViewBreeds = new ViewModel.BreedViewModel();
        }
        public BreedViewModel ViewBreeds { get; set; } // reads in the data from the BreedVieWModel

        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BattlePage)); // brings you to the page where you battle the monsters
        }

        private async void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Windows.UI.Popups.MessageDialog("Cached credentials for user - fgdgd1h3d2fgfgdhd13f2g1jjjj2544hfcg3dg1fchcfg5fb3f");
            var result = await dialog.ShowAsync();
            btnSignIn.Visibility = Visibility.Collapsed;
            btnStartGame.Visibility = Visibility.Visible;
        }
    }
}
