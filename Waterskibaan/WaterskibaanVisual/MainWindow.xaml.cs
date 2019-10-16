using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using Waterskibaan;

namespace WaterskibaanVisual
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _dispatcherTimer;
        private readonly Game _game;
        private readonly List<Sporter> _newVisitors = new List<Sporter>();
        private readonly List<Sporter> _newSporters = new List<Sporter>();
        private readonly List<Sporter> _finishedSporters = new List<Sporter>();
        private LinkedList<Lijn> _lines = new LinkedList<Lijn>();

        public MainWindow()
        {
            ResizeMode = ResizeMode.CanMinimize;
            InitializeComponent();

            _game = new Game();

            _dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal)
            {
                Interval = TimeSpan.FromMilliseconds(200)
            };

            _game.NieuweBezoeker += OnNewVisitor;
            _game.InstructieAfgelopen += OnInstructionFinished;
            _game.LijnenVerplaatst += OnMoveLines;

            _dispatcherTimer.Tick += (source, args) => canvas.Children.Clear();
            _dispatcherTimer.Tick += (source, args) => InstructionQueueCanvas.Children.Clear();
            _dispatcherTimer.Tick += (source, args) => InstuctionGroupCanvas.Children.Clear();
            _dispatcherTimer.Tick += (source, args) => StartQueueCanvas.Children.Clear();
            _dispatcherTimer.Tick += (source, args) => WaterSkiLijnCanvas.Children.Clear();
            _dispatcherTimer.Tick += DrawGame;

            _game.Initialize(_dispatcherTimer);
            _dispatcherTimer.Start();
        }

        private void OnMoveLines(LijnenVerplaatsArgs e)
        {
            _finishedSporters.Remove(e.Sporter);
            _lines = e.Lijnen;
        }

        private void OnInstructionFinished(InstructieAfgelopenArgs e)
        {
            foreach (var sporter in e.SportersNieuw)
            {
                _newVisitors.Remove(sporter);
                _newSporters.Add(sporter);
            }

            foreach (var sporter in e.SportersKlaar)
            {
                _newSporters.Remove(sporter);
                _finishedSporters.Add(sporter);
            }
        }

        private void OnNewVisitor(NieuweBezoekerArgs e)
        {
            _newVisitors.Add(e.Sporter);
        }

        private static Rectangle CreateDrawableSporter(Sporter sporter)
        {
            Color color = Color.FromArgb(sporter.KledingKleur.A, sporter.KledingKleur.R, sporter.KledingKleur.G, sporter.KledingKleur.B);
            var converter = new BrushConverter();
            var fillBrush = (SolidColorBrush)converter.ConvertFromString(color.ToString());
            var strokeBrush = new SolidColorBrush(Colors.Black);
            var sp = new Rectangle
            {
                Stroke = strokeBrush,
                Fill = fillBrush,
                Height = 20,
                Width = 20,
                RadiusX = 5,
                RadiusY = 5
            };

            return sp;
        }

        private void DrawGame(object sender, EventArgs e)
        {
            DrawInstructionQueue();
            DrawInstructionGroup();
            DrawStartQueue();
            DrawWaterSkiLanes();
        }


        private void Start_Click(object sender, RoutedEventArgs e)
        {
            _dispatcherTimer.Start();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            _dispatcherTimer.Stop();
        }

        private void DrawInstructionQueue()
        {
            var BackGround = new Rectangle()
            {
                Stroke = InstructionQueueCanvas.Background,
                Fill = InstructionQueueCanvas.Background,
                Width = InstructionQueueCanvas.Width,
                Height = InstructionQueueCanvas.Height
            };

            Canvas.SetLeft(BackGround, 0);
            Canvas.SetTop(BackGround, 0);
            InstructionQueueCanvas.Children.Add(BackGround);

            var fence = new Line()
            {
                Height = InstructionQueueCanvas.Height,
                Fill = new SolidColorBrush(Colors.Black),
                Stroke = new SolidColorBrush(Colors.Black),
                X1 = 0,
                X2 = 0,
                Y1 = 26,
                Y2 = InstructionQueueCanvas.Height
            };

            Canvas.SetLeft(fence, 0);
            Canvas.SetTop(fence, 0);
            InstructionQueueCanvas.Children.Add(fence);

            for (var i = 0; i < 5; i++)
            {
                var line = new Line()
                {
                    Height = InstructionQueueCanvas.Height,
                    Fill = new SolidColorBrush(Colors.Black),
                    Stroke = new SolidColorBrush(Colors.Black),
                    X1 = 0,
                    X2 = 0,
                    Y1 = 26,
                    Y2 = InstructionQueueCanvas.Height - 30
                };

                Canvas.SetLeft(line, i * 30 + 30);

                Canvas.SetTop(line, i % 2 == 0 ? 30 : 0);

                InstructionQueueCanvas.Children.Add(line);
            }

            for (var i = 0; i < _newVisitors.Count; i++)
            {
                var sporter = CreateDrawableSporter(_newVisitors[i]);

                if (i < 13)
                {
                    Canvas.SetTop(sporter, 29 + (28 * i));
                    Canvas.SetLeft(sporter, 125);
                }
                else if (i >= 13 && i < 26)
                {
                    Canvas.SetTop(sporter, InstructionQueueCanvas.Height - 25 - (28 * (i - 13)));
                    Canvas.SetLeft(sporter, 95);
                }
                else if (i >= 26 && i < 39)
                {
                    Canvas.SetTop(sporter, 29 + (28 * (i - 26)));
                    Canvas.SetLeft(sporter, 65);
                }
                else if (i >= 39 && i < 52)
                {
                    Canvas.SetTop(sporter, InstructionQueueCanvas.Height - 25 - (28 * (i - 39)));
                    Canvas.SetLeft(sporter, 35);
                }
                else
                {
                    Canvas.SetTop(sporter, 29 + (28 * (i - 52)));
                    Canvas.SetLeft(sporter, 5);
                }

                InstructionQueueCanvas.Children.Add(sporter);
            }
        }

        private void DrawInstructionGroup()
        {
            var BackGround = new Rectangle()
            {
                Stroke = InstuctionGroupCanvas.Background,
                Fill = InstuctionGroupCanvas.Background,
                Width = InstuctionGroupCanvas.Width,
                Height = InstuctionGroupCanvas.Height
            };

            Canvas.SetLeft(BackGround, 0);
            Canvas.SetTop(BackGround, 0);
            InstuctionGroupCanvas.Children.Add(BackGround);

            for (var i = 0; i < 5; i++)
            {
                var sporter = _newSporters.Count >= i + 1 ? _newSporters[i] : null;

                if (sporter == null) continue;

                var placeSporter = CreateDrawableSporter(sporter);

                Canvas.SetTop(placeSporter, 29 + (28 * i));
                Canvas.SetLeft(placeSporter, 20);
                InstuctionGroupCanvas.Children.Add(placeSporter);

            }
        }

        private void DrawStartQueue()
        {
            var BackGround = new Rectangle()
            {
                Stroke = StartQueueCanvas.Background,
                Fill = StartQueueCanvas.Background,
                Width = StartQueueCanvas.Width,
                Height = StartQueueCanvas.Height
            };

            Canvas.SetLeft(BackGround, 0);
            Canvas.SetTop(BackGround, 0);
            StartQueueCanvas.Children.Add(BackGround);

            for (var i = 0; i < _finishedSporters.Count; i++)
            {
                var sporter = CreateDrawableSporter(_finishedSporters[i]);

                if (i < 10)
                {
                    Canvas.SetTop(sporter, 29 + (i * 28));
                    Canvas.SetRight(sporter, 5);
                }
                else
                {
                    Canvas.SetTop(sporter, 29 + ((i - 10) * 28));
                    Canvas.SetRight(sporter, 35);
                }

                StartQueueCanvas.Children.Add(sporter);
            }
        }

        private void DrawWaterSkiLanes()
        {
            var BackGround = new Rectangle()
            {
                Stroke = WaterSkiLijnCanvas.Background,
                Fill = WaterSkiLijnCanvas.Background,
                Width = WaterSkiLijnCanvas.Width,
                Height = WaterSkiLijnCanvas.Height
            };

            Canvas.SetLeft(BackGround, 0);
            Canvas.SetTop(BackGround, 0);
            WaterSkiLijnCanvas.Children.Add(BackGround);

            for (var i = 0; i < 10; i++)
            {

                var location = new Ellipse()
                {
                    Stroke = new SolidColorBrush(Colors.Black),
                    Fill = new SolidColorBrush(Colors.White),
                    Width = 20,
                    Height = 20
                };

                var number = new TextBlock()
                {
                    Text = i.ToString(),
                    Foreground = new SolidColorBrush(Colors.Black)
                };

                switch (i)
                {
                    case 0:
                    case 1:
                    case 2:
                        Canvas.SetTop(location, 40);
                        Canvas.SetLeft(location, WaterSkiLijnCanvas.Width - 400 + (i * 120));

                        Canvas.SetTop(number, 40);
                        Canvas.SetLeft(number, WaterSkiLijnCanvas.Width - 370 + (i * 120));
                        break;
                    case 3:
                    case 9:
                        Canvas.SetTop(location, 140);
                        Canvas.SetLeft(location, WaterSkiLijnCanvas.Width - 400 + (i == 9 ? 0 : 2 * 120));

                        Canvas.SetTop(number, 140);
                        Canvas.SetLeft(number, WaterSkiLijnCanvas.Width - 370 + (i == 9 ? 0 : 2 * 120));
                        break;
                    case 4:
                    case 8:
                        Canvas.SetTop(location, 240);
                        Canvas.SetLeft(location, WaterSkiLijnCanvas.Width - 400 + (i == 8 ? 0 : 2 * 120));

                        Canvas.SetTop(number, 240);
                        Canvas.SetLeft(number, WaterSkiLijnCanvas.Width - 370 + (i == 8 ? 0 : 2 * 120));
                        break;
                    default:
                        Canvas.SetTop(location, 340);
                        Canvas.SetLeft(location, WaterSkiLijnCanvas.Width - (160 + (i - 5) * 120));

                        Canvas.SetTop(number, 340);
                        Canvas.SetLeft(number, WaterSkiLijnCanvas.Width - (130 + (i - 5) * 120));
                        break;
                }

                WaterSkiLijnCanvas.Children.Add(location);
                WaterSkiLijnCanvas.Children.Add(number);

                foreach (var line in _lines)
                {
                    var sporter = CreateDrawableSporter(line.Sporter);

                    TextBlock move = null;

                    if (line.Sporter.HuidigeMove != null)
                    {
                        move = new TextBlock()
                        {
                            Text = line.Sporter.HuidigeMove.ToString(),
                            Foreground = new SolidColorBrush(Colors.Black)
                        };
                    }

                    switch (line.PositieOpDeKabel)
                    {
                        case 0:
                            Canvas.SetTop(sporter, 40);
                            Canvas.SetLeft(sporter, WaterSkiLijnCanvas.Width - 400);

                            if (move != null)
                            {
                                Canvas.SetTop(move, 20);
                                Canvas.SetLeft(move, WaterSkiLijnCanvas.Width - 400);
                            }
                            break;
                        case 1:
                            Canvas.SetTop(sporter, 40);
                            Canvas.SetLeft(sporter, WaterSkiLijnCanvas.Width - 280);

                            if (move != null)
                            {
                                Canvas.SetTop(move, 20);
                                Canvas.SetLeft(move, WaterSkiLijnCanvas.Width - 280);
                            }
                            break;
                        case 2:
                            Canvas.SetTop(sporter, 40);
                            Canvas.SetLeft(sporter, WaterSkiLijnCanvas.Width - 160);

                            if (move != null)
                            {
                                Canvas.SetTop(move, 20);
                                Canvas.SetLeft(move, WaterSkiLijnCanvas.Width - 160);
                            }
                            break;
                        case 3:
                            Canvas.SetTop(sporter, 140);
                            Canvas.SetLeft(sporter, WaterSkiLijnCanvas.Width - 160);

                            if (move != null)
                            {
                                Canvas.SetTop(move, 120);
                                Canvas.SetLeft(move, WaterSkiLijnCanvas.Width - 160);
                            }
                            break;
                        case 4:
                            Canvas.SetTop(sporter, 240);
                            Canvas.SetLeft(sporter, WaterSkiLijnCanvas.Width - 160);

                            if (move != null)
                            {
                                Canvas.SetTop(move, 220);
                                Canvas.SetLeft(move, WaterSkiLijnCanvas.Width - 160);
                            }
                            break;
                        case 5:
                            Canvas.SetTop(sporter, 340);
                            Canvas.SetLeft(sporter, WaterSkiLijnCanvas.Width - 160);

                            if (move != null)
                            {
                                Canvas.SetTop(move, 320);
                                Canvas.SetLeft(move, WaterSkiLijnCanvas.Width - 160);
                            }
                            break;
                        case 6:
                            Canvas.SetTop(sporter, 340);
                            Canvas.SetLeft(sporter, WaterSkiLijnCanvas.Width - 280);

                            if (move != null)
                            {
                                Canvas.SetTop(move, 320);
                                Canvas.SetLeft(move, WaterSkiLijnCanvas.Width - 280);
                            }
                            break;
                        case 7:
                            Canvas.SetTop(sporter, 340);
                            Canvas.SetLeft(sporter, WaterSkiLijnCanvas.Width - 400);

                            if (move != null)
                            {
                                Canvas.SetTop(move, 320);
                                Canvas.SetLeft(move, WaterSkiLijnCanvas.Width - 400);
                            }
                            break;
                        case 8:
                            Canvas.SetTop(sporter, 240);
                            Canvas.SetLeft(sporter, WaterSkiLijnCanvas.Width - 400);

                            if (move != null)
                            {
                                Canvas.SetTop(move, 220);
                                Canvas.SetLeft(move, WaterSkiLijnCanvas.Width - 400);
                            }
                            break;
                        case 9:
                            Canvas.SetTop(sporter, 140);
                            Canvas.SetLeft(sporter, WaterSkiLijnCanvas.Width - 400);

                            if (move != null)
                            {
                                Canvas.SetTop(move, 120);
                                Canvas.SetLeft(move, WaterSkiLijnCanvas.Width - 400);
                            }
                            break;
                    }

                    WaterSkiLijnCanvas.Children.Add(sporter);
                    if (move != null)
                    {
                        WaterSkiLijnCanvas.Children.Add(move);
                    }
                }
            }
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
//using System.Windows.Threading;
//using Waterskibaan;
//using System.Timers;

//namespace WaterskibaanVisual
//{
//    //class RefreshHandeler
//    //{
//    //    public event Action<int> CounterUpdated;
//    //    public System.Timers.Timer _timer;
//    //    public RefreshHandeler(System.Timers.Timer timer)
//    //    {
//    //        _timer = timer;
//    //        _timer.Elapsed += OnTimerEvent;
//    //        _timer.AutoReset = true;
//    //        _timer.Enabled = true;
//    //    }
//    //    public int counter;
//    //    public void OnTimerEvent(object sender, EventArgs e)
//    //    {
//    //        counter++;
//    //        if (CounterUpdated != null)
//    //            CounterUpdated(counter);
//    //    }
//    //}

//    /// <summary>
//    /// Interaction logic for MainWindow.xaml
//    /// </summary>
//    public partial class MainWindow : Window
//    {
//        //RefreshHandeler refreshHandeler;
//        Game game;
//        public System.Timers.Timer _timer;
//        public int _counter;
//        private static Random _random = new Random();

//        LinkedList<Brush> colors = new LinkedList<Brush>();
//        Dictionary<int, int> sporterGegevens = new Dictionary<int, int>();
//        LinkedList<int> IDs = new LinkedList<int>();
//        List<int> scores = new List<int>();

//        public MainWindow()
//        {
//            ResizeMode = ResizeMode.CanMinimize;
//            InitializeComponent();

//            game = new Game();
//            game.Initialize();
//            _timer = new System.Timers.Timer(getRandomTime());
//            SetTimer(_timer);
//            game.SetTimer(_timer);
//        }

//        private void SetTimer(System.Timers.Timer _timer)
//        {
//            _timer.Elapsed += OnTimerEvent;
//            _timer.Elapsed += game.OnTimerEvent;
//            _timer.AutoReset = true;
//            _timer.Enabled = true;


//            _counter = 0;
//        }

//        private int getRandomTime()
//        {
//            return _random.Next(500, 1501);
//        }

//        private void OnTimerEvent(object source, ElapsedEventArgs e)
//        {
//            _counter++;
//            Update();
//        }

//        public void Update()
//        {
//            //Counter.Content = game._counter;
//            //WachtrijInstructieNummer.Content = game._wachtrijInstructie.GetAlleSporters().Count;
//            //InstructieGroepNummer.Content = game._instructieGroep.GetAlleSporters().Count;
//            //WachtrijStartenNummer.Content = game._wachtrijStarten.GetAlleSporters().Count;
//            //LijnenvoorraadCounter.Content = game.waterskibaan._lijnen.GetAantalLijnen();

//            if (_counter % 4 == 0)
//            {
//                int i = 0;
//                foreach (var item in game.waterskibaan._kabel.Lijnen)
//                {
//                    System.Drawing.Color kleur = game.waterskibaan._kabel.Lijnen.ElementAt(i).Sporter.KledingKleur;
//                    int id = game.waterskibaan._kabel.Lijnen.ElementAt(i).Sporter.Id;
//                    Brush tempBrush = new SolidColorBrush(Color.FromArgb(kleur.A, kleur.R, kleur.G, kleur.B));
//                    Brush wit = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
//                    colors.AddFirst(tempBrush);
//                    IDs.AddFirst(id);

//                    Positie0.Fill = colors.ElementAt(0) ?? wit;
//                    IDSpeler0.Content = IDs.ElementAt(0);
//                    Positie1.Fill = colors.ElementAt(1) ?? wit;
//                    IDSpeler1.Content = IDs.ElementAt(1);
//                    Positie2.Fill = colors.ElementAt(2) ?? wit;
//                    IDSpeler2.Content = IDs.ElementAt(2);
//                    Positie3.Fill = colors.ElementAt(3) ?? wit;
//                    IDSpeler3.Content = IDs.ElementAt(3);
//                    Positie4.Fill = colors.ElementAt(4) ?? wit;
//                    IDSpeler4.Content = IDs.ElementAt(4);
//                    Positie5.Fill = colors.ElementAt(5) ?? wit;
//                    IDSpeler5.Content = IDs.ElementAt(5);
//                    Positie6.Fill = colors.ElementAt(6) ?? wit;
//                    IDSpeler6.Content = IDs.ElementAt(6);
//                    Positie7.Fill = colors.ElementAt(7) ?? wit;
//                    IDSpeler7.Content = IDs.ElementAt(7);
//                    Positie8.Fill = colors.ElementAt(8) ?? wit;
//                    IDSpeler8.Content = IDs.ElementAt(8);
//                    Positie9.Fill = colors.ElementAt(9) ?? wit;
//                    IDSpeler9.Content = IDs.ElementAt(9);

//                    int score = game.waterskibaan._kabel.Lijnen.ElementAt(i).Sporter.Score;
//                    scores.Add(score);

//                    scores.Sort();
//                    scores.Reverse();
//                    i++;
//                }

//            }
//        }

//        private void Start_Click(object sender, RoutedEventArgs e)
//        {
//            game.waterskibaan.Start();
//            //game._timer.Start();
//            _timer.Start();

//            Counter.Content = game._counter;
//            WachtrijInstructieNummer.Content = game._wachtrijInstructie.GetAlleSporters().Count;
//            InstructieGroepNummer.Content = game._instructieGroep.GetAlleSporters().Count;
//            WachtrijStartenNummer.Content = game._wachtrijStarten.GetAlleSporters().Count;
//            LijnenvoorraadCounter.Content = game.waterskibaan._lijnen.GetAantalLijnen();
//            Update();

//            /*
//            i++;

//            try
//            {
//                if (game._counter % 4 == 0)
//                {
//                    System.Drawing.Color kleur = game.waterskibaan._kabel.Lijnen.ElementAt(i).Sporter.KledingKleur;
//                    int id = game.waterskibaan._kabel.Lijnen.ElementAt(i).Sporter.Id;
//                    Brush tempBrush = new SolidColorBrush(Color.FromArgb(kleur.A, kleur.R, kleur.G, kleur.B));
//                    Brush wit = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
//                    colors.AddFirst(tempBrush);
//                    IDs.AddFirst(id);


//                    Positie0.Fill = colors.ElementAt(0) ?? wit;
//                    IDSpeler0.Content = IDs.ElementAt(0);
//                    Positie1.Fill = colors.ElementAt(1) ?? wit;
//                    IDSpeler1.Content = IDs.ElementAt(1);
//                    Positie2.Fill = colors.ElementAt(2) ?? wit;
//                    IDSpeler2.Content = IDs.ElementAt(2);
//                    Positie3.Fill = colors.ElementAt(3) ?? wit;
//                    IDSpeler3.Content = IDs.ElementAt(3);
//                    Positie4.Fill = colors.ElementAt(4) ?? wit;
//                    IDSpeler4.Content = IDs.ElementAt(4);
//                    Positie5.Fill = colors.ElementAt(5) ?? wit;
//                    IDSpeler5.Content = IDs.ElementAt(5);
//                    Positie6.Fill = colors.ElementAt(6) ?? wit;
//                    IDSpeler6.Content = IDs.ElementAt(6);
//                    Positie7.Fill = colors.ElementAt(7) ?? wit;
//                    IDSpeler7.Content = IDs.ElementAt(7);
//                    Positie8.Fill = colors.ElementAt(8) ?? wit;
//                    IDSpeler8.Content = IDs.ElementAt(8);
//                    Positie9.Fill = colors.ElementAt(9) ?? wit;
//                    IDSpeler9.Content = IDs.ElementAt(9);

//                    int score = game.waterskibaan._kabel.Lijnen.ElementAt(i).Sporter.Score;
//                    scores.Add(score);

//                    scores.Sort();
//                    scores.Reverse();
//                }
//            }
//            catch (Exception ex)
//            {
//                Test.Content = ex;
//            }

//            Counter.Refresh();*/
//            //Thread.Sleep(500);
//        }



//        private void Stop_Click(object sender, RoutedEventArgs e)
//        {
//            game.waterskibaan.Stop();
//            Test.Content = game.waterskibaan.isGestart;
//        }
//    }

//    public static class ExtensionMethods
//    {
//        private static Action EmptyDelegate = delegate () { };

//        public static void Refresh(this UIElement uiElement)
//        {
//            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
//        }
//    }
//}