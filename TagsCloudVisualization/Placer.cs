using System;
using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization
{
    public class Placer : IPlacer
    {
        private readonly Point center;

        public Placer(Point center)
        {
            this.center = center;
        }

        public IEnumerable<Point> GetPoint()
        {
            for (var radius = 0; ; radius++)
            for (var i = 0.0; i < 2 * Math.PI; i += Math.PI / 180)
                yield return center + new Size((int)(radius * Math.Cos(i)), (int)(radius * Math.Sin(i)));
        }
    }
}