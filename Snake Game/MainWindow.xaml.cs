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

namespace Snake_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private const int SquareSize = 20;

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            DrawGameArea();
        }

        private void DrawGameArea()
        {
            bool doneDrawingBackground = false;
            int nextX = 0, nextY = 0;
            int rowCounter = 0;
            bool nextIsOdd = false;

            while (doneDrawingBackground == false)
            {
                Rectangle rect = new Rectangle
                {
                    Width = SquareSize,
                    Height = SquareSize,
                    Fill = nextIsOdd ? Brushes.White : Brushes.Black
                };

                GameArea.Children.Add(rect);
                Canvas.SetTop(rect, nextY);
                Canvas.SetLeft(rect, nextX);

                nextIsOdd = !nextIsOdd;
                nextX += SquareSize;

                if (nextX >= GameArea.ActualWidth)
                {
                    nextX = 0;
                    nextY += SquareSize;
                    rowCounter++;
                }

                if (nextY >= GameArea.ActualHeight)
                    doneDrawingBackground = true;
            }

        }
    }

    public class Snake
    {
        private int xPosition = 0, yPosition = 0;
        private int nextX = 0, nextY = 0;

        Snake()
        {
            xPosition = 60;
            yPosition = 40;

            Rectangle rect = new Rectangle
            {
                Width = 0,
                Height = 0,
                Fill = Brushes.Red
            };

            MainWindow w1 = new MainWindow();
            w1.GameArea.Children.Add(rect);
            Canvas.SetTop(rect, yPosition);
            Canvas.SetLeft(rect, xPosition);

        }


    }

    //public class Scoreboard (I xaml: Title="Binding ScoreBoard"
    //{
    //    Scoreboard()
    //    {
            
    //    }

    //    private string _scoreBoard;
    //    private int _score;


    //    public string ScoreBoard
    //    {
    //        get
    //        {
    //            this._scoreBoard = "GekSnake Game - Score: " + Score;
    //            return this._scoreBoard;
    //        }
    //        set { this._scoreBoard = value; }
    //    }

    //    public int Score
    //    {
    //        get { return _score; }
    //        set { this._score = value; }
    //    }
    //}
}
