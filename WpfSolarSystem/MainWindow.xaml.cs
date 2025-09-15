using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace WpfSolarSystem
{ 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //The positions which to orbit around
            int x = 370;
            int y = 225;

            Planets Earth = new Planets(90, 90, 0.04, x, y, 180, Brushes.LimeGreen);
            this.solarSystemCanvas.Children.Add(Earth.PlanetEllipse);
            
            Planets Pluto = new Planets(10, 10, 0.03, x, y, 240, Brushes.DarkRed);
            this.solarSystemCanvas.Children.Add(Pluto.PlanetEllipse);

            Planets Mercury = new Planets(40, 40, 0.05, x, y, 120, Brushes.DimGray);
            this.solarSystemCanvas.Children.Add(Mercury.PlanetEllipse);

            //Setting different times for the timer to upload new positions for the planets
            DispatcherTimer earthTimer = new DispatcherTimer();
            earthTimer.Interval = TimeSpan.FromMilliseconds(10);
            earthTimer.Tick += Earth.Move;
            earthTimer.Start();

            DispatcherTimer plutoTimer = new DispatcherTimer();
            plutoTimer.Interval = TimeSpan.FromMilliseconds(20);
            plutoTimer.Tick += Pluto.Move;
            plutoTimer.Start();

            DispatcherTimer MarcuryTimer = new DispatcherTimer();
            MarcuryTimer.Interval = TimeSpan.FromMilliseconds(15);
            MarcuryTimer.Tick += Mercury.Move;
            MarcuryTimer.Start();
        }
    }
}