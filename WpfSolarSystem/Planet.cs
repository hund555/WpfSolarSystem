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
        // Orbit radius from the center of orbit
        private readonly int orbitRadius = 0;
        private double speed = 0;

        // Center of orbit position
        private readonly int xpos = 0;
        private readonly int ypos = 0;

        // Next position of the planet
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

        /// <summary>
        /// Updates the planet's next position based on its current orbital parameters.
        /// This method is used my worker thread to calculate the next position of the planet in its orbit.
        /// </summary>
        /// <remarks>This method calculates the next position of the planet in its orbit by incrementing
        /// the orbital angle and applying trigonometric functions to determine the new coordinates. The calculated
        /// position is stored internally and can be used for rendering or further calculations.</remarks>
        public void CalculateNextPlanetPosition()
        {
            this.angle += this.speed;

            this.nextXPos = (int)(Math.Cos(angle) * this.orbitRadius + this.xpos);
            this.nextYPos = (int)(Math.Sin(angle) * this.orbitRadius + this.ypos);
        }

        /// <summary>
        /// Updates the position of the planet on the canvas.
        /// This method is used by the UI thread to update the graphical representation of the planet
        /// </summary>
        /// <remarks>This method sets the new position of the planet's graphical representation  by
        /// updating the <see cref="Canvas.LeftProperty"/> and <see cref="Canvas.TopProperty"/>  attached properties of
        /// the associated <see cref="Ellipse"/> object.</remarks>
        public void MovePlanet()
        {
            Ellipse.SetValue(Canvas.LeftProperty, (double)nextXPos);
            Ellipse.SetValue(Canvas.TopProperty, (double)nextYPos);
        }
    }
}
