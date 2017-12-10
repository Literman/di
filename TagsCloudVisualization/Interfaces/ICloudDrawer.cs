using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization
{
    public interface ICloudDrawer
    {
        void Draw(Dictionary<string, Rectangle> rectangles);

        void Save(Dictionary<string, Rectangle> rectangles);
    }
}