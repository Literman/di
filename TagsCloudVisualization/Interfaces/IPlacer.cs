using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization
{
    public interface IPlacer
    {
        IEnumerable<Point> GetPoint();
    }
}