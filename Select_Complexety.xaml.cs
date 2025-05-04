using Snake.Properties;
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
    /// Логика взаимодействия для Select_Complexety.xaml
    /// </summary>
    public partial class Select_Complexety : Page
    {
        private List<Point> _obstaclesSelectMap = new List<Point>();
        public static int NumberMap = 1;
        public Select_Complexety()
        {
            InitializeComponent();
            GenerateBoard();
            GenerateObstacles();
            FF.Focus();
        }
        

        private void Page_KeyDown_1(object sender, KeyEventArgs e)
        {   
            if (e.Key == Key.Escape)
            {
                App.MainWindowFrame.Navigate(new MainMenu());
            }
        }
        private void GenerateBoard()
        {
            int rows = Game.CanvasHeight / Game.SnakeSquareSize;
            int columns = Game.CanvasWidth / Game.SnakeSquareSize;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Rectangle cell = new Rectangle
                    {
                        Width = Game.SnakeSquareSize,
                        Height = Game.SnakeSquareSize,
                        Fill = (row + col) % 2 == 0 ? Game.color : Game.color2
                    };
                    Canvas.SetLeft(cell, col * Game.SnakeSquareSize);
                    Canvas.SetTop(cell, row * Game.SnakeSquareSize);

                    SelectMapCanvas.Children.Add(cell);
                }
            }
        }

            private void GenerateObstacles()
        {
            _obstaclesSelectMap.Clear();

            switch (NumberMap)
            {
                case 1:
                    //Верхняя//
                    _obstaclesSelectMap.Add(new Point(0, 9));
                    _obstaclesSelectMap.Add(new Point(1, 9));
                    _obstaclesSelectMap.Add(new Point(2, 9));

                    _obstaclesSelectMap.Add(new Point(6, 9));
                    _obstaclesSelectMap.Add(new Point(7, 9));
                    _obstaclesSelectMap.Add(new Point(8, 9));
                    _obstaclesSelectMap.Add(new Point(9, 9));
                    _obstaclesSelectMap.Add(new Point(10, 9));
                    _obstaclesSelectMap.Add(new Point(11, 9));
                    _obstaclesSelectMap.Add(new Point(12, 9));
                    _obstaclesSelectMap.Add(new Point(13, 9));

                    _obstaclesSelectMap.Add(new Point(17, 9));
                    _obstaclesSelectMap.Add(new Point(18, 9));
                    _obstaclesSelectMap.Add(new Point(19, 9));
                    _obstaclesSelectMap.Add(new Point(0, 10));
                    _obstaclesSelectMap.Add(new Point(1, 10));
                    _obstaclesSelectMap.Add(new Point(2, 10));

                    _obstaclesSelectMap.Add(new Point(6, 10));
                    _obstaclesSelectMap.Add(new Point(7, 10));
                    _obstaclesSelectMap.Add(new Point(8, 10));
                    _obstaclesSelectMap.Add(new Point(9, 10));
                    _obstaclesSelectMap.Add(new Point(10, 10));
                    _obstaclesSelectMap.Add(new Point(11, 10));
                    _obstaclesSelectMap.Add(new Point(12, 10));
                    _obstaclesSelectMap.Add(new Point(13, 10));

                    _obstaclesSelectMap.Add(new Point(17, 10));
                    _obstaclesSelectMap.Add(new Point(18, 10));
                    _obstaclesSelectMap.Add(new Point(19, 10));

                    //Нижняя//
                    _obstaclesSelectMap.Add(new Point(9, 0));
                    _obstaclesSelectMap.Add(new Point(9, 1));
                    _obstaclesSelectMap.Add(new Point(9, 2));

                    _obstaclesSelectMap.Add(new Point(9, 6));
                    _obstaclesSelectMap.Add(new Point(9, 7));
                    _obstaclesSelectMap.Add(new Point(9, 8));
                    _obstaclesSelectMap.Add(new Point(9, 9));
                    _obstaclesSelectMap.Add(new Point(9, 10));
                    _obstaclesSelectMap.Add(new Point(9, 11));
                    _obstaclesSelectMap.Add(new Point(9, 12));
                    _obstaclesSelectMap.Add(new Point(9, 13));

                    _obstaclesSelectMap.Add(new Point(9, 17));
                    _obstaclesSelectMap.Add(new Point(9, 18));
                    _obstaclesSelectMap.Add(new Point(9, 19));
                    _obstaclesSelectMap.Add(new Point(10, 0));
                    _obstaclesSelectMap.Add(new Point(10, 1));
                    _obstaclesSelectMap.Add(new Point(10, 2));

                    _obstaclesSelectMap.Add(new Point(10, 6));
                    _obstaclesSelectMap.Add(new Point(10, 7));
                    _obstaclesSelectMap.Add(new Point(10, 8));
                    _obstaclesSelectMap.Add(new Point(10, 9));
                    _obstaclesSelectMap.Add(new Point(10, 10));
                    _obstaclesSelectMap.Add(new Point(10, 11));
                    _obstaclesSelectMap.Add(new Point(10, 12));
                    _obstaclesSelectMap.Add(new Point(10, 13));

                    _obstaclesSelectMap.Add(new Point(10, 17));
                    _obstaclesSelectMap.Add(new Point(10, 18));
                    _obstaclesSelectMap.Add(new Point(10, 19));

                    break;
                case 2:
                    _obstaclesSelectMap.Add(new Point(0, 0));
                    
                  
                    _obstaclesSelectMap.Add(new Point(5, 5));
                    _obstaclesSelectMap.Add(new Point(5, 6));
                    _obstaclesSelectMap.Add(new Point(5, 7));
                    _obstaclesSelectMap.Add(new Point(6, 5));
                    _obstaclesSelectMap.Add(new Point(7, 5));
                    _obstaclesSelectMap.Add(new Point(15, 15));
                    _obstaclesSelectMap.Add(new Point(15, 16));
                    _obstaclesSelectMap.Add(new Point(15, 17));
                    _obstaclesSelectMap.Add(new Point(16, 15));
                    _obstaclesSelectMap.Add(new Point(17, 15));
                    _obstaclesSelectMap.Add(new Point(10, 0));
                    _obstaclesSelectMap.Add(new Point(10, 1));
                    _obstaclesSelectMap.Add(new Point(10, 2));
                    _obstaclesSelectMap.Add(new Point(10, 3));
                    _obstaclesSelectMap.Add(new Point(10, 4));
                    _obstaclesSelectMap.Add(new Point(0, 10));
                    _obstaclesSelectMap.Add(new Point(1, 10));
                    _obstaclesSelectMap.Add(new Point(2, 10));
                    _obstaclesSelectMap.Add(new Point(3, 10));
                    _obstaclesSelectMap.Add(new Point(4, 10));
                    _obstaclesSelectMap.Add(new Point(8, 8));
                    _obstaclesSelectMap.Add(new Point(9, 9));
                    _obstaclesSelectMap.Add(new Point(10, 10));
                    _obstaclesSelectMap.Add(new Point(11, 11));
                    _obstaclesSelectMap.Add(new Point(12, 12));
                    break;
                case 3:
                    _obstaclesSelectMap.Add(new Point(0, 5));
                    _obstaclesSelectMap.Add(new Point(0, 6));
                    _obstaclesSelectMap.Add(new Point(0, 7));
                    _obstaclesSelectMap.Add(new Point(0, 8));
                    _obstaclesSelectMap.Add(new Point(0, 9));
                    _obstaclesSelectMap.Add(new Point(19, 5));
                    _obstaclesSelectMap.Add(new Point(19, 6));
                    _obstaclesSelectMap.Add(new Point(19, 7));
                    _obstaclesSelectMap.Add(new Point(19, 8));
                    _obstaclesSelectMap.Add(new Point(19, 9));
                    _obstaclesSelectMap.Add(new Point(5, 0));
                    _obstaclesSelectMap.Add(new Point(6, 0));
                    _obstaclesSelectMap.Add(new Point(7, 0));
                    _obstaclesSelectMap.Add(new Point(8, 0));
                    _obstaclesSelectMap.Add(new Point(9, 0));
                    _obstaclesSelectMap.Add(new Point(5, 19));
                    _obstaclesSelectMap.Add(new Point(6, 19));
                    _obstaclesSelectMap.Add(new Point(7, 19));
                    _obstaclesSelectMap.Add(new Point(8, 19));
                    _obstaclesSelectMap.Add(new Point(9, 19));
                    _obstaclesSelectMap.Add(new Point(10, 10));
                    _obstaclesSelectMap.Add(new Point(10, 11));
                    _obstaclesSelectMap.Add(new Point(10, 12));
                    _obstaclesSelectMap.Add(new Point(11, 10));
                    _obstaclesSelectMap.Add(new Point(12, 10));
                    _obstaclesSelectMap.Add(new Point(14, 14));
                    _obstaclesSelectMap.Add(new Point(14, 15));
                    _obstaclesSelectMap.Add(new Point(14, 16));
                    _obstaclesSelectMap.Add(new Point(15, 14));
                    _obstaclesSelectMap.Add(new Point(16, 14));
                    _obstaclesSelectMap.Add(new Point(2, 2));
                    _obstaclesSelectMap.Add(new Point(3, 3));
                    _obstaclesSelectMap.Add(new Point(4, 4));
                    _obstaclesSelectMap.Add(new Point(5, 5));
                    _obstaclesSelectMap.Add(new Point(6, 6));
                    _obstaclesSelectMap.Add(new Point(17, 17));
                    _obstaclesSelectMap.Add(new Point(16, 18));
                    _obstaclesSelectMap.Add(new Point(18, 16));
                    _obstaclesSelectMap.Add(new Point(12, 5));
                    _obstaclesSelectMap.Add(new Point(13, 5));
                    _obstaclesSelectMap.Add(new Point(14, 5));
                    _obstaclesSelectMap.Add(new Point(5, 12));
                    _obstaclesSelectMap.Add(new Point(5, 13));
                    _obstaclesSelectMap.Add(new Point(5, 14));

                    break;
                default:
                 
                    break;
            }
            foreach (var obstaclePosition in _obstaclesSelectMap)
            {
                Rectangle obstacle = new Rectangle
                {
                    Width = Game.SnakeSquareSize,
                    Height = Game.SnakeSquareSize,
                    Fill = Brushes.Black
                };
                Canvas.SetLeft(obstacle, obstaclePosition.X * Game.SnakeSquareSize);
                Canvas.SetTop(obstacle, obstaclePosition.Y * Game.SnakeSquareSize);
                SelectMapCanvas.Children.Add(obstacle);
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NumberMap++;
            if (1 <= NumberMap && NumberMap <= 3)
            {

                App.MainWindowFrame.Navigate(new Select_Complexety());

            }
            else { NumberMap--; }
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            NumberMap--;
            if (1 <= NumberMap && NumberMap <= 3)
            {
                App.MainWindowFrame.Navigate(new Select_Complexety());
            }
            else { NumberMap++; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.MainWindowFrame.Navigate(new Game());
            Game.selectedmap = NumberMap;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.MainWindowFrame.Navigate(new GameForTwoPlayer());
            GameForTwoPlayer.selectedmap = NumberMap;
        }
    }
}
