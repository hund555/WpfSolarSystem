using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfSolarSystem
{
    // Class to create our planets and update UI placements for planets
    public class Planets
    {
        public Ellipse PlanetEllipse {get; set;}
        public double Speed { get; set;}
        
        private int _xPos = 0;
        private int _yPos = 0;
        private readonly int _orbitRadius = 0;

        //Constructor with parameters to define our plantes later
        public Planets (int height, int width, double speed, int xPos, int yPos, int orbitRadius, SolidColorBrush color)
        {
            PlanetEllipse = new Ellipse()
            {
                Height = height,
                Width = width,
                Fill = color
            };
            this.Speed = speed;       
            this._orbitRadius = orbitRadius;
            this._xPos = xPos;
            this._yPos = yPos;            
        }

        double testAngle = 0;

        //Updates the plantes movements on the canvas
        public void Move(Object sender, EventArgs e)
        {
            testAngle += this.Speed;

            int newXpos = (int)(Math.Cos(testAngle) * this._orbitRadius + _xPos);
            int newYpos = (int)(Math.Sin(testAngle) * this._orbitRadius + _yPos);

            if (PlanetEllipse.Parent != null)
            {
                Canvas.SetTop(PlanetEllipse, newYpos);
                Canvas.SetLeft(PlanetEllipse, newXpos);
            }
            Console.WriteLine("Planet's move threadID: " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
