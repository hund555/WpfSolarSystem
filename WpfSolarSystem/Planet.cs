using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfSolarSystem
{
    public class Planet
    {
        public Ellipse Ellipse { get; set; }
        public string Name { get; set; }

        private readonly int orbitRadius = 0;
        private double speed = 0;
        private readonly int xpos = 0;
        private readonly int ypos = 0;

        private int nextXPos = 0;
        private int nextYPos = 0;

        private double angle = 0;

        public Planet(string name, int orbitRadius, int height, int width, double speed, int xpos, int ypos, SolidColorBrush color)
        {
            Ellipse = new Ellipse()
            {
                Height = height,
                Width = width,
                Fill = color
            };
            this.Name = name;
            this.orbitRadius = orbitRadius;
            this.speed = speed;
            this.xpos = xpos;
            this.ypos = ypos;
        }

        public void CalculateNextPlanetPosition()
        {
            this.angle += this.speed;

            this.nextXPos = (int)(Math.Cos(angle) * this.orbitRadius + this.xpos);
            this.nextYPos = (int)(Math.Sin(angle) * this.orbitRadius + this.ypos);
        }

        public void MovePlanet()
        {
            Ellipse.SetValue(Canvas.LeftProperty, (double)nextXPos);
            Ellipse.SetValue(Canvas.TopProperty, (double)nextYPos);
        }
    }
}
