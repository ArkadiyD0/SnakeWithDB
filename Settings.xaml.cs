using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Snake
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        private bool isWaitingForKey = false;
        private string TapedButton = ""; //Переменная для switch, для определения нажатой кнопки
        private DispatcherTimer _timer;
        public static int TimerInterval = 3000;

        public Settings()
        {
            InitializeComponent();
            Up.Content = Game.selectedKeyForUp.ToString();
            Down.Content = Game.selectedKeyForDown.ToString();
            Left.Content = Game.selectedKeyForLeft.ToString(); 
            Right.Content = Game.selectedKeyForRight.ToString();

            UpSecond.Content = Game.selectedKeyForUpSecond.ToString();
            DownSecond.Content = Game.selectedKeyForDownSecond.ToString();
            LeftSecond.Content = Game.selectedKeyForLeftSecond.ToString();
            RightSecond.Content = Game.selectedKeyForRightSecond.ToString();
            settings.Focus();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            switch (TapedButton)
            {
                /* Up.Content = Game.selectedKeyForUp.ToString();
                   Down.Content = Game.selectedKeyForDown.ToString();
                   Left.Content = Game.selectedKeyForLeft.ToString();
                   Right.Content = Game.selectedKeyForRight.ToString();
                   UpSecond.Content = Game.selectedKeyForUpSecond.ToString();
                   DownSecond.Content = Game.selectedKeyForDownSecond.ToString();
                   LeftSecond.Content = Game.selectedKeyForLeftSecond.ToString();
                   RightSecond.Content = Game.selectedKeyForRightSecond.ToString();
                   */

                case "Up":
                    Up.Content = Game.selectedKeyForUp.ToString();
                    _timer.Stop();
                    break;
                case "Down":
                    Down.Content = Game.selectedKeyForDown.ToString();
                    _timer.Stop();
                    break;
                case "Left":
                    Left.Content = Game.selectedKeyForLeft.ToString();
                    _timer.Stop();
                    break;
                case "Right":
                    Right.Content = Game.selectedKeyForRight.ToString();
                    _timer.Stop();
                    break;
                case "UpSecond":
                    {
                        UpSecond.Content = Game.selectedKeyForUpSecond.ToString();
                        _timer.Stop();
                    } break;
                case "DownSecond":
                    {
                        DownSecond.Content = Game.selectedKeyForDownSecond.ToString();
                        _timer.Stop();
                    } break;
                case "LeftSecond": 
                    {
                        LeftSecond.Content = Game.selectedKeyForLeftSecond.ToString();
                        _timer.Stop();
                    } break;
                case " RightSecond":
                    {
                        RightSecond.Content = Game.selectedKeyForRightSecond.ToString();
                        _timer.Stop();
                    } break;
            }
        }
        public void Page_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.Key == Key.Escape)
            {
                App.MainWindowFrame.Navigate(new MainMenu());
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            e.Handled = true;
            if (isWaitingForKey)
            {
                switch (TapedButton)
                {
                    case "Up":
                        {
                            if (e.Key != Game.selectedKeyForDown &&
                                e.Key != Game.selectedKeyForRight &&
                                e.Key != Game.selectedKeyForLeft &&
                                e.Key != Game.selectedKeyForDownSecond &&
                                 e.Key != Game.selectedKeyForUpSecond &&
                                e.Key != Game.selectedKeyForRightSecond &&
                                e.Key != Game.selectedKeyForLeftSecond &&
                                e.Key != Key.Escape)
                            {

                                Game.selectedKeyForUp = e.Key;
                                isWaitingForKey = false;
                                Up.Content = Game.selectedKeyForUp.ToString();
                                settings.Focus();
                            }
                            else
                            {
                               
                                Up.Content = "Ошибка";
                                _timer = new DispatcherTimer();
                                _timer.Tick += Timer_Tick;
                                _timer.Interval = TimeSpan.FromMilliseconds(TimerInterval);
                                _timer.Start();
                            }

                        }
                        break;
                    case "Down":
                        {
                            if (e.Key != Game.selectedKeyForUp &&
                                e.Key != Game.selectedKeyForRight && 
                                e.Key != Game.selectedKeyForLeft &&
                                e.Key != Game.selectedKeyForUpSecond &&
                                 e.Key != Game.selectedKeyForDownSecond &&
                                e.Key != Game.selectedKeyForRightSecond &&
                                e.Key != Game.selectedKeyForLeftSecond &&
                                e.Key != Key.Escape)
                            {

                                Game.selectedKeyForDown = e.Key;
                                isWaitingForKey = false;
                                Down.Content = Game.selectedKeyForDown.ToString();
                                settings.Focus();
                            }
                            else
                            {

                                Down.Content = "Ошибка";
                                _timer = new DispatcherTimer();
                                _timer.Tick += Timer_Tick;
                                _timer.Interval = TimeSpan.FromMilliseconds(TimerInterval);
                                _timer.Start();
                            }
                        }
                        break;
                    case "Left":
                        {

                            if (e.Key != Game.selectedKeyForUp &&
                                e.Key != Game.selectedKeyForRight &&
                                e.Key != Game.selectedKeyForDown &&
                                e.Key != Game.selectedKeyForUpSecond &&
                                 e.Key != Game.selectedKeyForLeftSecond &&
                                e.Key != Game.selectedKeyForRightSecond &&
                                e.Key != Game.selectedKeyForDownSecond &&
                                e.Key != Key.Escape)
                            {

                                Game.selectedKeyForLeft = e.Key;
                                isWaitingForKey = false;
                                Left.Content = Game.selectedKeyForLeft.ToString();
                                settings.Focus();
                            }
                            else
                            {

                                Left.Content = "Ошибка";
                                _timer = new DispatcherTimer();
                                _timer.Tick += Timer_Tick;
                                _timer.Interval = TimeSpan.FromMilliseconds(TimerInterval);
                                _timer.Start();
                            }

                        }
                        break;
                    case "Right":
                        {
                            if (e.Key != Game.selectedKeyForUp && 
                                e.Key != Game.selectedKeyForDown && 
                                e.Key != Game.selectedKeyForLeft &&
                                e.Key != Game.selectedKeyForUpSecond &&
                                 e.Key != Game.selectedKeyForRightSecond &&
                                e.Key != Game.selectedKeyForDownSecond &&
                                e.Key != Game.selectedKeyForLeftSecond &&
                                e.Key != Key.Escape)
                            {

                                Game.selectedKeyForRight = e.Key;
                                isWaitingForKey = false;
                                Right.Content = Game.selectedKeyForRight.ToString();
                                settings.Focus();
                            }
                            else
                            {
                                Right.Content = "Ошибка ";
                                _timer = new DispatcherTimer();
                                _timer.Tick += Timer_Tick;
                                _timer.Interval = TimeSpan.FromMilliseconds(TimerInterval);
                                _timer.Start();
                            }
                        }
                        break;
                    case "UpSecond":
                        {
                            {
                                if (e.Key != Game.selectedKeyForDown &&
                                    e.Key != Game.selectedKeyForRight &&
                                    e.Key != Game.selectedKeyForLeft &&
                                    e.Key != Game.selectedKeyForUp &&
                                    e.Key != Game.selectedKeyForDownSecond &&
                                    e.Key != Game.selectedKeyForRightSecond &&
                                    e.Key != Game.selectedKeyForLeftSecond &&
                                    e.Key != Key.Escape)
                                {

                                    Game.selectedKeyForUpSecond = e.Key;
                                    isWaitingForKey = false;
                                    UpSecond.Content = Game.selectedKeyForUpSecond.ToString();
                                    settings.Focus();
                                }
                                else
                                {
                                    UpSecond.Content = "Ошибка";
                                    _timer = new DispatcherTimer();
                                    _timer.Tick += Timer_Tick;
                                    _timer.Interval = TimeSpan.FromMilliseconds(TimerInterval);
                                    _timer.Start();
                                }

                            }
                            break;
                        } 
                    case "DownSecond": 
                        {

                            {
                                if (e.Key != Game.selectedKeyForUp &&
                                    e.Key != Game.selectedKeyForRight &&
                                   e.Key != Game.selectedKeyForDown &&
                                    e.Key != Game.selectedKeyForLeft &&
                                    e.Key != Game.selectedKeyForUpSecond &&
                                    e.Key != Game.selectedKeyForRightSecond &&
                                    e.Key != Game.selectedKeyForLeftSecond &&
                                    e.Key != Key.Escape)
                                {

                                    Game.selectedKeyForDownSecond = e.Key;
                                    isWaitingForKey = false;
                                    DownSecond.Content = Game.selectedKeyForDownSecond.ToString();
                                    settings.Focus();
                                }
                                else
                                {

                                    DownSecond.Content = "Ошибка";
                                    _timer = new DispatcherTimer();
                                    _timer.Tick += Timer_Tick;
                                    _timer.Interval = TimeSpan.FromMilliseconds(TimerInterval);
                                    _timer.Start();
                                }
                            }
                            break;
                        } 
                    case "LeftSecond": 
                        {

                            {

                                if (e.Key != Game.selectedKeyForUp &&
                                    e.Key != Game.selectedKeyForRight &&
                                    e.Key != Game.selectedKeyForDown &&
                                    e.Key != Game.selectedKeyForLeft &&
                                    e.Key != Game.selectedKeyForUpSecond &&
                                    e.Key != Game.selectedKeyForRightSecond &&
                                    e.Key != Game.selectedKeyForDownSecond &&
                                    e.Key != Key.Escape)
                                {

                                    Game.selectedKeyForLeftSecond = e.Key;
                                    isWaitingForKey = false;
                                    LeftSecond.Content = Game.selectedKeyForLeftSecond.ToString();
                                    settings.Focus();
                                }
                                else
                                {

                                    LeftSecond.Content = "Ошибка";
                                    _timer = new DispatcherTimer();
                                    _timer.Tick += Timer_Tick;
                                    _timer.Interval = TimeSpan.FromMilliseconds(TimerInterval);
                                    _timer.Start();
                                }

                            }
                            break;
                        } 
                    case "RightSecond":
                        {

                            {
                                if (e.Key != Game.selectedKeyForUp &&
                                    e.Key != Game.selectedKeyForDown &&
                                    e.Key != Game.selectedKeyForLeft &&
                                    e.Key != Game.selectedKeyForRight &&
                                    e.Key != Game.selectedKeyForUpSecond &&
                                    e.Key != Game.selectedKeyForDownSecond &&
                                    e.Key != Game.selectedKeyForLeftSecond &&
                                    e.Key != Key.Escape)
                                {

                                    Game.selectedKeyForRightSecond = e.Key;
                                    isWaitingForKey = false;
                                    RightSecond.Content = Game.selectedKeyForRightSecond.ToString();
                                    settings.Focus();
                                }
                                else
                                {
                                    RightSecond.Content = "Ошибка";
                                    _timer = new DispatcherTimer();
                                    _timer.Tick += Timer_Tick;
                                    _timer.Interval = TimeSpan.FromMilliseconds(TimerInterval);
                                    _timer.Start();
                                }
                            }
                            break;
                        }
                }
            }
        }
        private void Up_Click(object sender, RoutedEventArgs e)
        {
            Up.Content = Game.selectedKeyForUp.ToString();
            Down.Content = Game.selectedKeyForDown.ToString();
            Left.Content = Game.selectedKeyForLeft.ToString();
            Right.Content = Game.selectedKeyForRight.ToString();
            UpSecond.Content = Game.selectedKeyForUpSecond.ToString();
            DownSecond.Content = Game.selectedKeyForDownSecond.ToString();
            LeftSecond.Content = Game.selectedKeyForLeftSecond.ToString();
            RightSecond.Content = Game.selectedKeyForRightSecond.ToString();
            isWaitingForKey = true;
            Up.Content = "Выбери клавишу";
            TapedButton = "Up";
        }
        private void Down_Click(object sender, RoutedEventArgs e)
        {
            Up.Content = Game.selectedKeyForUp.ToString();
            Down.Content = Game.selectedKeyForDown.ToString();
            Left.Content = Game.selectedKeyForLeft.ToString();
            Right.Content = Game.selectedKeyForRight.ToString();
            UpSecond.Content = Game.selectedKeyForUpSecond.ToString();
            DownSecond.Content = Game.selectedKeyForDownSecond.ToString();
            LeftSecond.Content = Game.selectedKeyForLeftSecond.ToString();
            RightSecond.Content = Game.selectedKeyForRightSecond.ToString();
            isWaitingForKey = true;
            Down.Content = "Выбери клавишу";
            TapedButton = "Down";
        }
        private void Left_Click(object sender, RoutedEventArgs e)
        {
            Up.Content = Game.selectedKeyForUp.ToString();
            Down.Content = Game.selectedKeyForDown.ToString();
            Left.Content = Game.selectedKeyForLeft.ToString();
            Right.Content = Game.selectedKeyForRight.ToString();
            UpSecond.Content = Game.selectedKeyForUpSecond.ToString();
            DownSecond.Content = Game.selectedKeyForDownSecond.ToString();
            LeftSecond.Content = Game.selectedKeyForLeftSecond.ToString();
            RightSecond.Content = Game.selectedKeyForRightSecond.ToString();
            isWaitingForKey = true;
            Left.Content = "Выбери клавишу";
            TapedButton = "Left";
        }
        private void Right_Click(object sender, RoutedEventArgs e)
        {
            Up.Content = Game.selectedKeyForUp.ToString();
            Down.Content = Game.selectedKeyForDown.ToString();
            Left.Content = Game.selectedKeyForLeft.ToString();
            Right.Content = Game.selectedKeyForRight.ToString();
            UpSecond.Content = Game.selectedKeyForUpSecond.ToString();
            DownSecond.Content = Game.selectedKeyForDownSecond.ToString();
            LeftSecond.Content = Game.selectedKeyForLeftSecond.ToString();
            RightSecond.Content = Game.selectedKeyForRightSecond.ToString();
            isWaitingForKey = true;
            Right.Content = "Выбери клавишу";
            TapedButton = "Right";
        }
        private void settings_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            settings.Focus();
        }
        private void UpSecond_Click(object sender, RoutedEventArgs e)
        {
            Up.Content = Game.selectedKeyForUp.ToString();
            Down.Content = Game.selectedKeyForDown.ToString();
            Left.Content = Game.selectedKeyForLeft.ToString();
            Right.Content = Game.selectedKeyForRight.ToString();
            UpSecond.Content = Game.selectedKeyForUpSecond.ToString();
            DownSecond.Content = Game.selectedKeyForDownSecond.ToString();
            LeftSecond.Content = Game.selectedKeyForLeftSecond.ToString();
            RightSecond.Content = Game.selectedKeyForRightSecond.ToString();
            isWaitingForKey = true;
            UpSecond.Content = "Выбери клавишу";
            TapedButton = "UpSecond";
        }
        private void DownSecond_Click(object sender, RoutedEventArgs e)
        {
            Up.Content = Game.selectedKeyForUp.ToString();
            Down.Content = Game.selectedKeyForDown.ToString();
            Left.Content = Game.selectedKeyForLeft.ToString();
            Right.Content = Game.selectedKeyForRight.ToString();
            UpSecond.Content = Game.selectedKeyForUpSecond.ToString();
            DownSecond.Content = Game.selectedKeyForDownSecond.ToString();
            LeftSecond.Content = Game.selectedKeyForLeftSecond.ToString();
            RightSecond.Content = Game.selectedKeyForRightSecond.ToString();
            isWaitingForKey = true;
            DownSecond.Content = "Выбери клавишу";
            TapedButton = "DownSecond";
        }
        private void LeftSecond_Click(object sender, RoutedEventArgs e)
        {
            Up.Content = Game.selectedKeyForUp.ToString();
            Down.Content = Game.selectedKeyForDown.ToString();
            Left.Content = Game.selectedKeyForLeft.ToString();
            Right.Content = Game.selectedKeyForRight.ToString();
            UpSecond.Content = Game.selectedKeyForUpSecond.ToString();
            DownSecond.Content = Game.selectedKeyForDownSecond.ToString();
            LeftSecond.Content = Game.selectedKeyForLeftSecond.ToString();
            RightSecond.Content = Game.selectedKeyForRightSecond.ToString();
            isWaitingForKey = true;
            LeftSecond.Content = "Выбери клавишу";
            TapedButton = "LeftSecond";
        }
        private void RightSecond_Click(object sender, RoutedEventArgs e)
        {
            Up.Content = Game.selectedKeyForUp.ToString();
            Down.Content = Game.selectedKeyForDown.ToString();
            Left.Content = Game.selectedKeyForLeft.ToString();
            Right.Content = Game.selectedKeyForRight.ToString();
            UpSecond.Content = Game.selectedKeyForUpSecond.ToString();
            DownSecond.Content = Game.selectedKeyForDownSecond.ToString();
            LeftSecond.Content = Game.selectedKeyForLeftSecond.ToString();
            RightSecond.Content = Game.selectedKeyForRightSecond.ToString();
            isWaitingForKey = true;
            RightSecond.Content = "Выбери клавишу";
            TapedButton = "RightSecond";
        }
    }
}


