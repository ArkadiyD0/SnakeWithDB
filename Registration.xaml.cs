using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;



namespace Snake
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public static Players thisplayer = new Players();
        public static Inventory thisplayerinv = new Inventory();
        public Registration()
        {
            InitializeComponent();
            this.Focus();
            if (MainMenu.IsReg == true)
            { RegistratrationMenu.Visibility = Visibility; }
            if (MainMenu.IsReg == false)
            { LoginMenu.Visibility = Visibility; }
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                App.MainWindowFrame.Navigate(new MainMenu());
            }
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            LoginReg.BorderThickness = new Thickness(0);
            PasswordReg.BorderThickness = new Thickness(0);
            EmailReg.BorderThickness = new Thickness(0);
            if (!string.IsNullOrWhiteSpace(LoginReg.Text) &&
                !string.IsNullOrWhiteSpace(PasswordReg.Text) &&
                !string.IsNullOrWhiteSpace(EmailReg.Text))
            {
                bool loginExists = App.db.Players.Any(p => p.Login == LoginReg.Text);

                if (loginExists)
                {
                    LoginReg.BorderBrush = Brushes.Red;
                    LoginReg.BorderThickness = new Thickness(3);
                    LoginReg.Text = "Данный логин занят";
                    return;
                }
               
                Players player = new Players()
                {
                    Login = LoginReg.Text,
                    Password = PasswordReg.Text,
                    Email = EmailReg.Text,
                    Points = 0,
                };
                App.db.Players.Add(player);
                App.db.SaveChanges();
                Inventory inventory = new Inventory()
                {
                    PlayerID = player.PlayerID, // Связываем с игроком
                    Skin1 = false,
                    Skin2 = false,
                    Skin3 = false
                };

                App.db.Inventory.Add(inventory);
                App.db.SaveChanges();
                thisplayer = AuthorizeUser(LoginReg.Text, PasswordReg.Text);
                if (thisplayer != null)
                {
                    thisplayerinv = App.db.Inventory.FirstOrDefault(i => i.PlayerID == thisplayer.PlayerID);
                    MainMenu.IsLoggin = true;
                    App.MainWindowFrame.Navigate(new MainMenu());
                }
            }
            if (string.IsNullOrWhiteSpace(LoginReg.Text))
            {
                LoginReg.BorderBrush = Brushes.Red;
                LoginReg.BorderThickness = new Thickness(3);
                
            }
            if (string.IsNullOrWhiteSpace(PasswordReg.Text))
            {
                PasswordReg.BorderBrush = Brushes.Red;
                PasswordReg.BorderThickness = new Thickness(3);
              
            }
            if (string.IsNullOrWhiteSpace(EmailReg.Text))
            {
                EmailReg.BorderBrush = Brushes.Red;
                EmailReg.BorderThickness = new Thickness(3);
                
            }

        }

        private void LogButton_Click(object sender, RoutedEventArgs e)
        {
            thisplayer = AuthorizeUser(LoginLog.Text, LoginPass.Text);

            if (thisplayer != null)
            {                
                thisplayerinv = App.db.Inventory.FirstOrDefault(i => i.PlayerID == thisplayer.PlayerID);
                MainMenu.IsLoggin = true;
                App.MainWindowFrame.Navigate(new MainMenu());
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        public Players AuthorizeUser(string login, string password)
        {
            var player = App.db.Players.Include(p => p.Inventory).FirstOrDefault(p => p.Login == login);

            if (player == null)
                return null;
            if (player.Password == password)

                return player; 

            return null;
        }
    }
}
