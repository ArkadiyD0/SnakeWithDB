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
using System.Windows.Media.Animation;

namespace Snake
{
    public partial class MainMenu : Page
    {
        public static bool IsReg;
        public static bool IsLoggin;
        public MainMenu()
        {
            InitializeComponent();
            if (IsLoggin == true)
            {
                PlayerLog.Text = Registration.thisplayer.Login.ToString();
                LogginGrid.Visibility = Visibility.Hidden;
                RegGrid.Visibility = Visibility.Hidden;
                PlayerLogGrid.Visibility = Visibility.Visible;
                Loggout.Visibility = Visibility.Visible;
            }
            if (IsLoggin == false) { Skins.IsEnabled = false; }
           
        }
    
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MenuClose.Visibility = Visibility.Hidden;
            Menu.Visibility = Visibility.Hidden;
            MenuOpen.Visibility = Visibility.Visible;
        }

        private void MenuOpen_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MenuClose.Visibility = Visibility.Visible;
            Menu.Visibility = Visibility.Visible;
            MenuOpen.Visibility = Visibility.Hidden;
        }

        private void StartGame_MouseDown(object sender, MouseButtonEventArgs e)
        {
            App.MainWindowFrame.Navigate(new Select_Complexety());
        }

        private void Table_MouseDown(object sender, MouseButtonEventArgs e)
        {
            App.MainWindowFrame.Navigate(new Table());
        }

        private void Skins_MouseDown(object sender, MouseButtonEventArgs e)
        {
            App.MainWindowFrame.Navigate(new Skins());
        }

        private void Settings_MouseDown(object sender, MouseButtonEventArgs e)
        {
            App.MainWindowFrame.Navigate(new Settings());
        }

        private void Achif_MouseDown(object sender, MouseButtonEventArgs e)
        {
            App.MainWindowFrame.Navigate(new Achievment());
        }

        private void Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Skills_MouseDown(object sender, MouseButtonEventArgs e)
        {
            App.MainWindowFrame.Navigate(new Skills());
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            IsReg = true;
            App.MainWindowFrame.Navigate(new Registration());
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IsReg = false;
            App.MainWindowFrame.Navigate(new Registration());
        }

        private void Loggout_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Registration.thisplayer = new Players();
            Registration.thisplayerinv = new Inventory();
            IsLoggin = false;
            App.MainWindowFrame.Navigate(new MainMenu());
            LogginGrid.Visibility = Visibility.Visible;
            RegGrid.Visibility = Visibility.Visible;
        }
    }
}
