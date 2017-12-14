using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization
{
    public interface ICloudDrawer
    {
        void Draw(WordsBox wordsBox);

        void Save(Dictionary<string, Rectangle> rectangles);
    }
}