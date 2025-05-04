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
using System.Xml.Linq;

namespace Snake
{
    /// <summary>
    /// Логика взаимодействия для GameForTwoPlayer.xaml
    /// </summary>

    public partial class GameForTwoPlayer : Page
    {
        public static int selectedmap { get; set; }
        public static string PathFood = "pack://application:,,,/Skins/" + "SkinFood" + 1 + ".png";
        public static string PathSnakeHead = "pack://application:,,,/Skins/" + "SkinEat" + 1 + ".png";
        public static string PathSnakeBody = "pack://application:,,,/Skins/" + "SkinBody" + 1 + ".png";

        public static string PathFood2 = "pack://application:,,,/Skins/" + "SkinFood" + 2 + ".png";
        public static string PathSnakeHead2 = "pack://application:,,,/Skins/" + "SkinEat" + 2 + ".png";
        public static string PathSnakeBody2 = "pack://application:,,,/Skins/" + "SkinBody" + 2 + ".png";

        public const int CanvasWidth = 600;
        public const int CanvasHeight = 600;
        public const int SnakeSquareSize = 30;
        private enum Direction
        {
            Left, Right, Top, Bottom
        }
      
        public static int TimerInterval = 90;
        public static bool TimerIntervalPause = false;
        private DispatcherTimer _timer;
        private Point _foodPosition;
        private static readonly Random randomPositionFood = new Random();

        private Rectangle _snakeHead;
        private static Direction _direction = Direction.Right;
        private List<Rectangle> _snake = new List<Rectangle>();


        private int _score = 0;
        public static SolidColorBrush color = (SolidColorBrush)(new BrushConverter().ConvertFrom("#3d2b84"));
        public static SolidColorBrush color2 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#373952"));
        public static SolidColorBrush color3 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7B68EE"));
        private Rectangle _foodBorder;
        private List<Point> _obstacles = new List<Point>();

        private Rectangle _snakeHead2;
        private List<Rectangle> _snake2 = new List<Rectangle>();
        private static Direction _direction2 = Direction.Right;

        public static Key selectedKeyForUp = Game.selectedKeyForUp;
        public static Key selectedKeyForDown = Game.selectedKeyForDown;
        public static Key selectedKeyForLeft = Game.selectedKeyForLeft;
        public static Key selectedKeyForRight = Game.selectedKeyForRight;

        public static Key selectedKeyForUpSecond = Game.selectedKeyForUpSecond;
        public static Key selectedKeyForDownSecond = Game.selectedKeyForDownSecond;
        public static Key selectedKeyForLeftSecond = Game.selectedKeyForLeftSecond;
        public static Key selectedKeyForRightSecond = Game.selectedKeyForRightSecond;

        public GameForTwoPlayer()
        {
            InitializeComponent();
        }

        private void GenerateObstacles()
        {
            _obstacles.Clear();

            switch (GameForTwoPlayer.selectedmap)
            {
                case 1:
                    //Верхняя//
                    _snakeHead = CreateSnakeSegment(new Point(2, 4), true);
                    _snake.Add(_snakeHead);
                    GameCanvas.Children.Add(_snakeHead);

                    _snakeHead2 = CreateSnakeSegment2(new Point(17, 15), true); 
                    _snake2.Add(_snakeHead2);
                    GameCanvas.Children.Add(_snakeHead2);
                    _direction2 = Direction.Left;

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
                    _snakeHead = CreateSnakeSegment(new Point(2, 16), true);
                    _snake.Add(_snakeHead);
                    GameCanvas.Children.Add(_snakeHead);
                    _direction = Direction.Right;

                    _snakeHead2 = CreateSnakeSegment2(new Point(16, 2), true);
                    _snake2.Add(_snakeHead2);
                    GameCanvas.Children.Add(_snakeHead2);
                    _direction2 = Direction.Bottom;

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
                    _snakeHead = CreateSnakeSegment(new Point(2, 16), true);
                    _snake.Add(_snakeHead);
                    GameCanvas.Children.Add(_snakeHead);
                    _direction = Direction.Right;
                    _snakeHead2 = CreateSnakeSegment2(new Point(16, 2), true);
                    _snake2.Add(_snakeHead2);
                    GameCanvas.Children.Add(_snakeHead2);
                    _direction2 = Direction.Bottom;
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

                    _snakeHead2 = CreateSnakeSegment2(new Point(5, 5), true);
                    _snake2.Add(_snakeHead2);
                    GameCanvas.Children.Add(_snakeHead2);
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
        private void Timer_Tick(object sender, EventArgs e)
        {
            Point newHeadPosition = CalculeteNewHeadPosition();
            Point newHeadPosition2 = CalculeteNewHeadPosition2();
            if (newHeadPosition == _foodPosition)
            {
                EatFood();
                PlaceFood();
            }
            if (newHeadPosition2 == _foodPosition)
            {
                EatFood2();
                PlaceFood();
            }
            if (_obstacles.Contains(newHeadPosition))
            {
                EndGame();
                return;
            }
            if (_obstacles.Contains(newHeadPosition2))
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
            if (newHeadPosition2.X < 0 || newHeadPosition2.Y < 0
               || newHeadPosition2.X >= GameCanvas.ActualWidth / SnakeSquareSize
                || newHeadPosition2.Y >= GameCanvas.ActualHeight / SnakeSquareSize)
            {
                EndGame();
                return;
            }

            if (_snake.Count >= 1)
            {
                for (int i = 0; i < _snake.Count; i++)
                {
                    Point currentPos = new Point(Canvas.GetLeft(_snake[i]), Canvas.GetTop(_snake[i]));

                    for (int j = i + 1; j < _snake.Count; j++)
                    {
                        Point nextPos = new Point(Canvas.GetLeft(_snake[j]), Canvas.GetTop(_snake[j]));

                        if (currentPos == nextPos)
                        {
                            EndGame();
                            return;
                        }
                    }
                }
                for (int i = 0; i < _snake.Count; i++)
                {
                    Point currentPos = new Point(Canvas.GetLeft(_snake[i]), Canvas.GetTop(_snake[i]));

                    for (int j = i + 1; j < _snake2.Count; j++)
                    {
                        Point nextPos = new Point(Canvas.GetLeft(_snake2[j]), Canvas.GetTop(_snake2[j]));

                        if (currentPos == nextPos)
                        {
                            EndGame();
                            return;
                        }
                    }
                }
            }
            if (_snake2.Count >= 1)
            {
                for (int i = 0; i < _snake2.Count; i++)
                {
                    Point currentPos2 = new Point(Canvas.GetLeft(_snake2[i]), Canvas.GetTop(_snake2[i]));

                    for (int j = i + 1; j < _snake2.Count; j++)
                    {
                        Point nextPos2 = new Point(Canvas.GetLeft(_snake2[j]), Canvas.GetTop(_snake2[j]));

                        if (currentPos2 == nextPos2)
                        {
                            EndGame(); return;
                        }
                    }
                }
                for (int i = 0; i < _snake2.Count; i++)
                {
                    Point currentPos2 = new Point(Canvas.GetLeft(_snake2[i]), Canvas.GetTop(_snake2[i]));

                    for (int j = i + 1; j < _snake.Count; j++)
                    {
                        Point nextPos2 = new Point(Canvas.GetLeft(_snake[j]), Canvas.GetTop(_snake[j]));

                        if (currentPos2 == nextPos2)
                        {
                            EndGame(); return;
                        }
                    }
                }
            }

            AnimateSnakeMovement(newHeadPosition);
            AnimateSnakeMovement2(newHeadPosition2);
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
        private Point CalculeteNewHeadPosition2()
        {
            double left = Canvas.GetLeft(_snakeHead2) / SnakeSquareSize;
            double top = Canvas.GetTop(_snakeHead2) / SnakeSquareSize;
            Point headCurrentPosition2 = new Point(left, top);
            Point newHeadPosition2 = new Point();

            switch (_direction2)
            {
                case Direction.Left:
                    newHeadPosition2 = new Point(headCurrentPosition2.X - 1, headCurrentPosition2.Y);
                    break;
                case Direction.Right:
                    newHeadPosition2 = new Point(headCurrentPosition2.X + 1, headCurrentPosition2.Y);
                    break;
                case Direction.Top:
                    newHeadPosition2 = new Point(headCurrentPosition2.X, headCurrentPosition2.Y - 1);
                    break;
                case Direction.Bottom:
                    newHeadPosition2 = new Point(headCurrentPosition2.X, headCurrentPosition2.Y + 1);
                    break;
            }
            return newHeadPosition2;
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
        private void AnimateSnakeMovement2(Point newHeadPosition)
        {
            _timer.Stop();

            var animation = new DoubleAnimation
            {
                From = Canvas.GetLeft(_snakeHead2),
                To = newHeadPosition.X * SnakeSquareSize,
                Duration = TimeSpan.FromMilliseconds(TimerInterval)
            };

            var animationY = new DoubleAnimation
            {
                From = Canvas.GetTop(_snakeHead2),
                To = newHeadPosition.Y * SnakeSquareSize,
                Duration = TimeSpan.FromMilliseconds(TimerInterval)
            };

            animation.Completed += (s, e) => AnimationCompleted();

            _snakeHead2.BeginAnimation(Canvas.LeftProperty, animation);
            _snakeHead2.BeginAnimation(Canvas.TopProperty, animationY);

            for (int i = _snake2.Count - 1; i > 0; i--)
            {
                var segment = _snake2[i];
                var prevSegment = _snake2[i - 1];

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
        private void EndGame()
        {
            _timer.Stop();
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
        private void EatFood2()
        {
            _score++;
            ScoreTextBlock.Text = "Score: " + _score.ToString();
            GameCanvas.Children.Remove(GameCanvas.Children.OfType<Image>().FirstOrDefault());
            GameCanvas.Children.Remove(_foodBorder);
            Rectangle newSnake2 = CreateSnakeSegment2(_foodPosition, false);
            _snake2.Add(newSnake2);
            GameCanvas.Children.Add(newSnake2);
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
        private Rectangle CreateSnakeSegment2(Point position, bool isHead)
        {
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri(isHead ? PathSnakeHead2 : PathSnakeBody2));
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
            if (e.Key == selectedKeyForUp)
            {
                if (_direction != Direction.Bottom)
                    _direction = Direction.Top;

            }
            else if (e.Key == selectedKeyForDown )
            {
                if (_direction != Direction.Top)
                    _direction = Direction.Bottom;
            }
            else if (e.Key == selectedKeyForLeft)
            {
                if (_direction != Direction.Right)
                    _direction = Direction.Left;
            }
            else if (e.Key == selectedKeyForRight)
            {
                if (_direction != Direction.Left)
                    _direction = Direction.Right;
            }
            if (e.Key == selectedKeyForUpSecond)
            {
                if (_direction2 != Direction.Bottom)
                    _direction2 = Direction.Top;

            }
            else if (e.Key == selectedKeyForDownSecond)
            {
                if (_direction2 != Direction.Top)
                    _direction2 = Direction.Bottom;
            }
            else if (e.Key == selectedKeyForLeftSecond)
            {
                if (_direction2 != Direction.Right)
                    _direction2 = Direction.Left;
            }
            else if (e.Key == selectedKeyForRightSecond)
            {
                if (_direction2 != Direction.Left)
                    _direction2 = Direction.Right;
            }

            else if (e.Key == Key.Escape)
            {
                App.MainWindowFrame.Navigate(new MainMenu());
            }
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
            _snake2.Clear();
            _direction2 = Direction.Right;
            InitianalGame();

        }

        private void StartGame_MouseDown(object sender, RoutedEventArgs e)
        {

            tbStart.Visibility = Visibility.Hidden;
            StartGame.Visibility = Visibility.Hidden;
            ScoreTextBlock.Visibility = Visibility.Visible;
            InitianalGame();
        }
    }
}

