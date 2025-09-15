using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfSolarSystem
{
    public partial class MainWindow : Window
    {
        // List of planets and their associated timers
        private List<Tuple<Planet, Timer>> planets = new List<Tuple<Planet, Timer>>();
        public MainWindow()
        {
            const int x = 415; //center of orbit x position
            const int y = 305; //center of orbit y position

            InitializeComponent();
            Planet earth = new Planet("Earth", 250, 50, 50, 0.05, x, y, Brushes.Blue);
            Planet mars = new Planet("Mars", 300, 40, 40, 0.03, x, y, Brushes.Red);
            Planet mercury = new Planet("Mercury", 125, 25, 25, 0.06, x, y, Brushes.Gray);
            Planet venus = new Planet("Venus", 175, 35, 35, 0.04, x, y, Brushes.Orange);

            planets.AddRange
                (
                    new Tuple<Planet, Timer>
                    (
                        item1: earth, new Timer(MovePlanet, earth, 0, 20)
                    ),
                    new Tuple<Planet, Timer>
                    (
                        item1: mars, new Timer(MovePlanet, mars, 0, 20)
                    ),
                    new Tuple<Planet, Timer>
                    (
                        item1: mercury, new Timer(MovePlanet, mercury, 0, 20)
                    ),
                    new Tuple<Planet, Timer>
                    (
                        item1: venus, new Timer(MovePlanet, venus, 0, 20)
                    )
                );
            foreach (Tuple<Planet, Timer> planet in planets)
            {
                solarSystemCanvas.Children.Add(planet.Item1.Ellipse);
            }
        }

        /// <summary>
        /// Worker thread method to move the planet
        /// </summary>
        /// <param name="state"></param>
        public void MovePlanet(object state)
        {
            Planet planet = (Planet)state;
            planet.CalculateNextPlanetPosition();

            // We are not on the UI thread, so we need to use the Dispatcher to update the UI
            this.Dispatcher.Invoke(() =>
            {
                planet.MovePlanet();
            });
        }
    }
}