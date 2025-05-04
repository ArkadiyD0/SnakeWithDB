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
using System.Windows.Threading;

namespace Snake
{
    /// <summary>
    /// Логика взаимодействия для Skins.xaml
    /// </summary>
    public partial class Skins : Page
    {
        private const int SnakeSquareSize = 30;
        private const int CanvasWidth = 300;
        private const int CanvasHeight = 200;
        public static int SkinI = 1;
        private string PathFood = Game.PathFood;
        private string PathSnakeHead = Game.PathSnakeHead;
        private string PathSnakeBody = Game.PathSnakeBody;
        private Image foodEater;
        private Image foodImage;
        private Image BodySkin;
        public Skins()
        {
            InitializeComponent();
            SkinsGenerateBoard();
            PlaceFood();
            PlaceEater();
            PlaceBodyEater();
            TB_skin.Text = "Скин #" + SkinI.ToString();
            skins.Focus(); 
        }
        public void SkinsGenerateBoard()
        {
            int rows = CanvasHeight / SnakeSquareSize;
            int columns = CanvasWidth / SnakeSquareSize;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Rectangle cell = new Rectangle
                    {
                        Width = SnakeSquareSize,
                        Height = SnakeSquareSize,
                        Fill = (row + col) % 2 == 0 ? Game.color : Game.color2
                    };
                    Canvas.SetLeft(cell, col * SnakeSquareSize);
                    Canvas.SetTop(cell, row * SnakeSquareSize);

                    SkinCanvas.Children.Add(cell);
                }
            }
        }
        private void PlaceFood()
        {
            int foodX = 8;
            int foodY = 3;
             foodImage = new Image
            {
                Width = SnakeSquareSize,
                Height = SnakeSquareSize,
                Source = new BitmapImage(new Uri(PathFood))
            };
            Canvas.SetLeft(foodImage, foodX * SnakeSquareSize);
            Canvas.SetTop(foodImage, foodY * SnakeSquareSize);
            SkinCanvas.Children.Add(foodImage);
        }
        private void PlaceEater()
        {
            int foodX = 6;
            int foodY = 3;
            foodEater = new Image
            {
                Width = SnakeSquareSize,
                Height = SnakeSquareSize,
                Source = new BitmapImage(new Uri(PathSnakeHead))
            };
            Canvas.SetLeft(foodEater, foodX * SnakeSquareSize);
            Canvas.SetTop(foodEater, foodY * SnakeSquareSize);
            SkinCanvas.Children.Add(foodEater);
        }
        private void PlaceBodyEater()
        {
            for (int i = 1; i < 6; i++)
            {
                int foodX = i;
                int foodY = 3;
                 BodySkin = new Image
                {
                    Width = SnakeSquareSize,
                    Height = SnakeSquareSize,
                    Source = new BitmapImage(new Uri(PathSnakeBody))
                };
                Canvas.SetLeft(BodySkin, foodX * SnakeSquareSize);
                Canvas.SetTop(BodySkin, foodY * SnakeSquareSize);
                SkinCanvas.Children.Add(BodySkin);
                
            }
        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SkinI++;
            if (1 <= SkinI && SkinI <= 3)
            {
               
                Game.PathFood = "pack://application:,,,/Skins/" + "SkinFood" + Skins.SkinI + ".png";
                Game.PathSnakeHead = "pack://application:,,,/Skins/" + "SkinEat" + Skins.SkinI + ".png";
                Game.PathSnakeBody = "pack://application:,,,/Skins/" + "SkinBody" + Skins.SkinI + ".png";
                App.MainWindowFrame.Navigate(new Skins());

            }
            else { SkinI--; }
        }
        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            SkinI--;
            if (1 <= SkinI && SkinI <= 3)
            {
               
                Game.PathFood = "pack://application:,,,/Skins/" + "SkinFood" + Skins.SkinI + ".png";
                Game.PathSnakeHead = "pack://application:,,,/Skins/" + "SkinEat" + Skins.SkinI + ".png";
                Game.PathSnakeBody = "pack://application:,,,/Skins/" + "SkinBody" + Skins.SkinI + ".png";
                App.MainWindowFrame.Navigate(new Skins());

            }
            else { SkinI++;  }
        }
        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                App.MainWindowFrame.Navigate(new MainMenu());
            }
        }
    }
}
