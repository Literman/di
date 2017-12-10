using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization
{
    public interface ICloudMaker
    {
        Dictionary<string, Rectangle> MakeCloud(Dictionary<string, int> tags);
    }
}