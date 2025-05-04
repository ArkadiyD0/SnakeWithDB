using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Snake
{
    /// <summary>
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        public static string PathFood = "pack://application:,,,/Skins/" + "SkinFood" + Skins.SkinI + ".png";
        public static string PathSnakeHead = "pack://application:,,,/Skins/" + "SkinEat" + Skins.SkinI + ".png";
        public static string PathSnakeBody = "pack://application:,,,/Skins/" + "SkinBody" + Skins.SkinI + ".png";
        public static SolidColorBrush color = (SolidColorBrush)(new BrushConverter().ConvertFrom("#3d2b84"));
        public static SolidColorBrush color2 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#373952"));
        public static SolidColorBrush color3 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7B68EE"));

        public static Key selectedKeyForUp = Key.W;
        public static Key selectedKeyForDown = Key.S;
        public static Key selectedKeyForLeft = Key.A;
        public static Key selectedKeyForRight = Key.D;
        
        public static Key selectedKeyForUpSecond = Key.Up;
        public static Key selectedKeyForDownSecond = Key.Down;
        public static Key selectedKeyForLeftSecond = Key.Left;
        public static Key selectedKeyForRightSecond = Key.Right;

        private enum Direction
        {
            Left, Right, Top, Bottom
        }

        public const int CanvasWidth = 600;
        public const int CanvasHeight = 600;
        public const int SnakeSquareSize = 30;
        public static int TimerInterval = 50;
        public static bool TimerIntervalPause = false;
        private int _score = 0;
        private Rectangle _foodBorder;
        private DispatcherTimer _timer;
        private Point _foodPosition;
        private static readonly Random randomPositionFood = new Random();

        public static int selectedmap { get; set; }
        private List<Point> _obstacles = new List<Point>();

        private Rectangle _snakeHead;
        private static Direction _direction = Direction.Right;
        private List<Rectangle> _snake = new List<Rectangle>();

        public Game()
        {
            InitializeComponent();
        }

        private void InitianalGame()
        {
            Zalp.Focus();
            GenerateBoard();
            GenerateObstacles();
            PlaceFood();
            _timer = new DispatcherTimer();
            _timer.Tick += Timer_Tick;
            _timer.Interval = TimeSpan.FromMilliseconds(TimerInterval);
            _timer.Start();
        }

        private void GenerateBoard()
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
                        Fill = (row + col) % 2 == 0 ? color : color2
                    };
                    Canvas.SetLeft(cell, col * SnakeSquareSize);
                    Canvas.SetTop(cell, row * SnakeSquareSize);

                    GameCanvas.Children.Add(cell);
                }
            }

        }
        private void GenerateObstacles()
        {
            _obstacles.Clear();

            switch (Game.selectedmap)
            {
                case 1:
                    //Верхняя//
                    _snakeHead = CreateSnakeSegment(new Point(2, 2), true);
                    _snake.Add(_snakeHead);
                    GameCanvas.Children.Add(_snakeHead);

                    _obstacles.Add(new Point(0, 9));
                    _obstacles.Add(new Point(1, 9));
                    _obstacles.Add(new Point(2, 9));

                    _obstacles.Add(new Point(6, 9));
                    _obstacles.Add(new Point(7, 9));
                    _obstacles.Add(new Point(8, 9));
                    _obstacles.Add(new Point(9, 9));
                    _obstacles.Add(new Point(10, 9));
                    _obstacles.Add(new Point(11, 9));
                    _obstacles.Add(new Point(12, 9));
                    _obstacles.Add(new Point(13, 9));

                    _obstacles.Add(new Point(17, 9));
                    _obstacles.Add(new Point(18, 9));
                    _obstacles.Add(new Point(19, 9));
                    _obstacles.Add(new Point(0, 10));
                    _obstacles.Add(new Point(1, 10));
                    _obstacles.Add(new Point(2, 10));

                    _obstacles.Add(new Point(6, 10));
                    _obstacles.Add(new Point(7, 10));
                    _obstacles.Add(new Point(8, 10));
                    _obstacles.Add(new Point(9, 10));
                    _obstacles.Add(new Point(10, 10));
                    _obstacles.Add(new Point(11, 10));
                    _obstacles.Add(new Point(12, 10));
                    _obstacles.Add(new Point(13, 10));

                    _obstacles.Add(new Point(17, 10));
                    _obstacles.Add(new Point(18, 10));
                    _obstacles.Add(new Point(19, 10));

                    //Нижняя//
                    _obstacles.Add(new Point(9, 0));
                    _obstacles.Add(new Point(9, 1));
                    _obstacles.Add(new Point(9, 2));

                    _obstacles.Add(new Point(9, 6));
                    _obstacles.Add(new Point(9, 7));
                    _obstacles.Add(new Point(9, 8));
                    _obstacles.Add(new Point(9, 9));
                    _obstacles.Add(new Point(9, 10));
                    _obstacles.Add(new Point(9, 11));
                    _obstacles.Add(new Point(9, 12));
                    _obstacles.Add(new Point(9, 13));

                    _obstacles.Add(new Point(9, 17));
                    _obstacles.Add(new Point(9, 18));
                    _obstacles.Add(new Point(9, 19));
                    _obstacles.Add(new Point(10, 0));
                    _obstacles.Add(new Point(10, 1));
                    _obstacles.Add(new Point(10, 2));

                    _obstacles.Add(new Point(10, 6));
                    _obstacles.Add(new Point(10, 7));
                    _obstacles.Add(new Point(10, 8));
                    _obstacles.Add(new Point(10, 9));
                    _obstacles.Add(new Point(10, 10));
                    _obstacles.Add(new Point(10, 11));
                    _obstacles.Add(new Point(10, 12));
                    _obstacles.Add(new Point(10, 13));

                    _obstacles.Add(new Point(10, 17));
                    _obstacles.Add(new Point(10, 18));
                    _obstacles.Add(new Point(10, 19));

                    break;
                case 2:
                    _snakeHead = CreateSnakeSegment(new Point(9, 6), true);
                    _snake.Add(_snakeHead);
                    GameCanvas.Children.Add(_snakeHead);
                    _obstacles.Add(new Point(0, 0));
                    _obstacles.Add(new Point(5, 5));
                    _obstacles.Add(new Point(5, 6));
                    _obstacles.Add(new Point(5, 7));
                    _obstacles.Add(new Point(6, 5));
                    _obstacles.Add(new Point(7, 5));
                    _obstacles.Add(new Point(15, 15));
                    _obstacles.Add(new Point(15, 16));
                    _obstacles.Add(new Point(15, 17));
                    _obstacles.Add(new Point(16, 15));
                    _obstacles.Add(new Point(17, 15));
                    _obstacles.Add(new Point(10, 0));
                    _obstacles.Add(new Point(10, 1));
                    _obstacles.Add(new Point(10, 2));
                    _obstacles.Add(new Point(10, 3));
                    _obstacles.Add(new Point(10, 4));
                    _obstacles.Add(new Point(0, 10));
                    _obstacles.Add(new Point(1, 10));
                    _obstacles.Add(new Point(2, 10));
                    _obstacles.Add(new Point(3, 10));
                    _obstacles.Add(new Point(4, 10));
                    _obstacles.Add(new Point(8, 8));
                    _obstacles.Add(new Point(9, 9));
                    _obstacles.Add(new Point(10, 10));
                    _obstacles.Add(new Point(11, 11));
                    _obstacles.Add(new Point(12, 12));

                    break;
                case 3:
                    _snakeHead = CreateSnakeSegment(new Point(9, 6), true);
                    _snake.Add(_snakeHead);
                    GameCanvas.Children.Add(_snakeHead);

                    _obstacles.Add(new Point(0, 5));
                    _obstacles.Add(new Point(0, 6));
                    _obstacles.Add(new Point(0, 7));
                    _obstacles.Add(new Point(0, 8));
                    _obstacles.Add(new Point(0, 9));
                    _obstacles.Add(new Point(19, 5));
                    _obstacles.Add(new Point(19, 6));
                    _obstacles.Add(new Point(19, 7));
                    _obstacles.Add(new Point(19, 8));
                    _obstacles.Add(new Point(19, 9));
                    _obstacles.Add(new Point(5, 0));
                    _obstacles.Add(new Point(6, 0));
                    _obstacles.Add(new Point(7, 0));
                    _obstacles.Add(new Point(8, 0));
                    _obstacles.Add(new Point(9, 0));
                    _obstacles.Add(new Point(5, 19));
                    _obstacles.Add(new Point(6, 19));
                    _obstacles.Add(new Point(7, 19));
                    _obstacles.Add(new Point(8, 19));
                    _obstacles.Add(new Point(9, 19));
                    _obstacles.Add(new Point(10, 10));
                    _obstacles.Add(new Point(10, 11));
                    _obstacles.Add(new Point(10, 12));
                    _obstacles.Add(new Point(11, 10));
                    _obstacles.Add(new Point(12, 10));
                    _obstacles.Add(new Point(14, 14));
                    _obstacles.Add(new Point(14, 15));
                    _obstacles.Add(new Point(14, 16));
                    _obstacles.Add(new Point(15, 14));
                    _obstacles.Add(new Point(16, 14));
                    _obstacles.Add(new Point(2, 2));
                    _obstacles.Add(new Point(3, 3));
                    _obstacles.Add(new Point(4, 4));
                    _obstacles.Add(new Point(5, 5));
                    _obstacles.Add(new Point(6, 6));
                    _obstacles.Add(new Point(17, 17));
                    _obstacles.Add(new Point(16, 18));
                    _obstacles.Add(new Point(18, 16));
                    _obstacles.Add(new Point(12, 5));
                    _obstacles.Add(new Point(13, 5));
                    _obstacles.Add(new Point(14, 5));
                    _obstacles.Add(new Point(5, 12));
                    _obstacles.Add(new Point(5, 13));
                    _obstacles.Add(new Point(5, 14));

                    break;
                default:
                    _snakeHead = CreateSnakeSegment(new Point(9, 6), true);
                    _snake.Add(_snakeHead);
                    GameCanvas.Children.Add(_snakeHead);
                    break;
            }
            foreach (var obstaclePosition in _obstacles)
            {
                Rectangle obstacle = new Rectangle
                {
                    Width = SnakeSquareSize,
                    Height = SnakeSquareSize,
                    Fill = Brushes.Black
                };
                Canvas.SetLeft(obstacle, obstaclePosition.X * SnakeSquareSize);
                Canvas.SetTop(obstacle, obstaclePosition.Y * SnakeSquareSize);
                GameCanvas.Children.Add(obstacle);
            }


            /*
             * int maxX = (int)(GameCanvas.ActualWidth / SnakeSquareSize);
             int maxY = (int)(GameCanvas.ActualHeight / SnakeSquareSize);

             for (int i = 0; i < ObstacleCount; i++)
             {
                 Point newObstaclePosition;
                 bool isOnSnakeOrFood;

                 do
                 {
                     int obstacleX = randomPositionFood.Next(0, maxX);
                     int obstacleY = randomPositionFood.Next(0, maxY);
                     newObstaclePosition = new Point(obstacleX, obstacleY);

                     isOnSnakeOrFood = _snake.Any(segment =>
                     {
                         double segmentX = Canvas.GetLeft(segment) / SnakeSquareSize;
                         double segmentY = Canvas.GetTop(segment) / SnakeSquareSize;
                         return segmentX == newObstaclePosition.X && segmentY == newObstaclePosition.Y;
                     }) || newObstaclePosition == _foodPosition;
                 }
                 while (isOnSnakeOrFood);

                 _obstacles.Add(newObstaclePosition);

                 Rectangle obstacle = new Rectangle
                 {
                     Width = SnakeSquareSize,
                     Height = SnakeSquareSize,
                     Fill = Brushes.Black
                 };
                 Canvas.SetLeft(obstacle, newObstaclePosition.X * SnakeSquareSize);
                 Canvas.SetTop(obstacle, newObstaclePosition.Y * SnakeSquareSize);

                 GameCanvas.Children.Add(obstacle);
             }
            */
        }
        private void PlaceFood()
        {
            int maxX = (int)(GameCanvas.ActualWidth / SnakeSquareSize);
            int maxY = (int)(GameCanvas.ActualHeight / SnakeSquareSize);

            Point newFoodPosition;
            bool isOnObstacleOrSnake;

            do
            {
                int foodX = randomPositionFood.Next(0, (int)(GameCanvas.ActualWidth / SnakeSquareSize));
                int foodY = randomPositionFood.Next(0, (int)(GameCanvas.ActualHeight / SnakeSquareSize));
                newFoodPosition = new Point(foodX, foodY);


                isOnObstacleOrSnake = _obstacles.Contains(newFoodPosition) || _snake.Any(segment =>
                {
                    double segmentX = Canvas.GetLeft(segment) / SnakeSquareSize;
                    double segmentY = Canvas.GetTop(segment) / SnakeSquareSize;
                    return segmentX == newFoodPosition.X && segmentY == newFoodPosition.Y;
                });

            }
            while (isOnObstacleOrSnake);

            _foodPosition = newFoodPosition;

            Image foodImage = new Image
            {
                Width = SnakeSquareSize,
                Height = SnakeSquareSize,
                Source = new BitmapImage(new Uri(PathFood))
            };
            Canvas.SetLeft(foodImage, _foodPosition.X * SnakeSquareSize);
            Canvas.SetTop(foodImage, _foodPosition.Y * SnakeSquareSize);

            _foodBorder = new Rectangle
            {
                Width = SnakeSquareSize,
                Height = SnakeSquareSize,
                Stroke = color3,
                StrokeThickness = 2,
                Fill = Brushes.Transparent
            };
            Canvas.SetLeft(_foodBorder, _foodPosition.X * SnakeSquareSize);
            Canvas.SetTop(_foodBorder, _foodPosition.Y * SnakeSquareSize);

            GameCanvas.Children.Add(foodImage);
            GameCanvas.Children.Add(_foodBorder);
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            Point newHeadPosition = CalculeteNewHeadPosition();

            if (newHeadPosition == _foodPosition)
            {
                EatFood();
                PlaceFood();
            }
            if (_obstacles.Contains(newHeadPosition))
            {
                EndGame();
                return;
            }

            if (newHeadPosition.X < 0 || newHeadPosition.Y < 0
                || newHeadPosition.X >= GameCanvas.ActualWidth / SnakeSquareSize
                 || newHeadPosition.Y >= GameCanvas.ActualHeight / SnakeSquareSize)
            {
                EndGame();
                return;
            }

            if (_snake.Count >= 2)
            {
                for (int i = 0; i < _snake.Count; i++)
                {
                    Point currentPos = new Point(Canvas.GetLeft(_snake[i]), Canvas.GetTop(_snake[i]));

                    for (int j = i + 1; j < _snake.Count; j++)
                    {
                        Point nextPos = new Point(Canvas.GetLeft(_snake[j]), Canvas.GetTop(_snake[j]));

                        if (currentPos == nextPos)
                        {
                            EndGame(); return;
                        }
                    }
                }
            }

            AnimateSnakeMovement(newHeadPosition);
        }
        private Point CalculeteNewHeadPosition()
        {
            double left = Canvas.GetLeft(_snakeHead) / SnakeSquareSize;
            double top = Canvas.GetTop(_snakeHead) / SnakeSquareSize;
            Point headCurrentPosition = new Point(left, top);
            Point newHeadPosition = new Point();

            switch (_direction)
            {
                case Direction.Left:
                    newHeadPosition = new Point(headCurrentPosition.X - 1, headCurrentPosition.Y);
                    break;
                case Direction.Right:
                    newHeadPosition = new Point(headCurrentPosition.X + 1, headCurrentPosition.Y);
                    break;
                case Direction.Top:
                    newHeadPosition = new Point(headCurrentPosition.X, headCurrentPosition.Y - 1);
                    break;
                case Direction.Bottom:
                    newHeadPosition = new Point(headCurrentPosition.X, headCurrentPosition.Y + 1);
                    break;
            }
            return newHeadPosition;
        }
        private void AnimateSnakeMovement(Point newHeadPosition)
        {
            _timer.Stop();

            var animation = new DoubleAnimation
            {
                From = Canvas.GetLeft(_snakeHead),
                To = newHeadPosition.X * SnakeSquareSize,
                Duration = TimeSpan.FromMilliseconds(TimerInterval)
            };

            var animationY = new DoubleAnimation
            {
                From = Canvas.GetTop(_snakeHead),
                To = newHeadPosition.Y * SnakeSquareSize,
                Duration = TimeSpan.FromMilliseconds(TimerInterval)
            };

            animation.Completed += (s, e) => AnimationCompleted();

            _snakeHead.BeginAnimation(Canvas.LeftProperty, animation);
            _snakeHead.BeginAnimation(Canvas.TopProperty, animationY);

            for (int i = _snake.Count - 1; i > 0; i--)
            {
                var segment = _snake[i];
                var prevSegment = _snake[i - 1];

                var segmentAnimationX = new DoubleAnimation
                {
                    From = Canvas.GetLeft(segment),
                    To = Canvas.GetLeft(prevSegment),
                    Duration = TimeSpan.FromMilliseconds(TimerInterval)
                };

                var segmentAnimationY = new DoubleAnimation
                {
                    From = Canvas.GetTop(segment),
                    To = Canvas.GetTop(prevSegment),
                    Duration = TimeSpan.FromMilliseconds(TimerInterval)
                };

                segment.BeginAnimation(Canvas.LeftProperty, segmentAnimationX);
                segment.BeginAnimation(Canvas.TopProperty, segmentAnimationY);
            }
        }
        private void AnimationCompleted()
        {
            if (!TimerIntervalPause)
            {
                _timer.Start();
            }
        }


        private void EndGame()
        {
            _timer.Stop();
            if (MainMenu.IsLoggin == true & _score != 0)
            {
                UpdatePlayerRecord(Registration.thisplayer.PlayerID, Registration.thisplayer.Login, _score);
            }
            tbRestart.Visibility = Visibility.Visible;
            RestartButton.Visibility = Visibility.Visible;
        }

        private void EatFood()
        {
            _score++;
            ScoreTextBlock.Text = "Score: " + _score.ToString();
            GameCanvas.Children.Remove(GameCanvas.Children.OfType<Image>().FirstOrDefault());
            GameCanvas.Children.Remove(_foodBorder);
            Rectangle newSnake = CreateSnakeSegment(_foodPosition, false);
            _snake.Add(newSnake);
            GameCanvas.Children.Add(newSnake);
        }
        private Rectangle CreateSnakeSegment(Point position, bool isHead)
        {
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri(isHead ? PathSnakeHead : PathSnakeBody));
            Rectangle rectangle = new Rectangle
            {

                Width = SnakeSquareSize,
                Height = SnakeSquareSize,
                Fill = imageBrush
            };
            Canvas.SetLeft(rectangle, position.X * SnakeSquareSize);
            Canvas.SetTop(rectangle, position.Y * SnakeSquareSize);
            return rectangle;
        }

        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.Key == selectedKeyForUp || e.Key == selectedKeyForUpSecond)
            {
                if (_direction != Direction.Bottom)
                    _direction = Direction.Top;

            }
            else if (e.Key == selectedKeyForDown || e.Key == selectedKeyForDownSecond)
            {
                if (_direction != Direction.Top)
                    _direction = Direction.Bottom;
            }
            else if (e.Key == selectedKeyForLeft || e.Key == selectedKeyForLeftSecond)
            {
                if (_direction != Direction.Right)
                    _direction = Direction.Left;
            }
            else if (e.Key == selectedKeyForRight || e.Key == selectedKeyForRightSecond)
            {
                if (_direction != Direction.Left)
                    _direction = Direction.Right;
            }
            else if (e.Key == Key.Escape)
            {
                App.MainWindowFrame.Navigate(new MainMenu());
            }
            /* else if (e.Key == Key.P)
             {
                 if (TimerIntervalPause == false)
                 {
                     _timer.Stop();
                     TimerIntervalPause = true;
                 }
                 else
                 {
                     _timer.Start();
                     TimerIntervalPause = false;
                 }
             }*/
        }
        private void Image_MouseDown(object sender, RoutedEventArgs e)
        {
            tbRestart.Visibility = Visibility.Hidden;
            RestartButton.Visibility = Visibility.Hidden;
            _score = 0;
            ScoreTextBlock.Text = "Score: 0";
            GameCanvas.Children.Clear();
            _snake.Clear();
            _obstacles.Clear();
            _direction = Direction.Right;
            InitianalGame();
        }
        private void StartGame_MouseDown(object sender, RoutedEventArgs e)
        {
            tbStart.Visibility = Visibility.Hidden;
            StartGame.Visibility = Visibility.Hidden;
            ScoreTextBlock.Visibility = Visibility.Visible;
            InitianalGame();
        }
        public void UpdatePlayerRecord(int playerId, string login, int points)
        {
        
            var record = App.db.Records.FirstOrDefault(r => r.PlayerID == playerId);

            if (record == null)
            {
              
                record = new Records
                {
                    PlayerID = playerId,
                    Login = login,
                    Points = points
                };
                App.db.Records.Add(record);
            }
            else
            {
              
                if (points > record.Points)
                {
                    record.Points = points;
                    record.Login = login;
                }
            }

            App.db.SaveChanges();
        }

    }


}

