using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization
{
    public interface ICloudDrawer
    {
        Result<None> Draw(WordsBox wordsBox);

        Result<None> Save(Dictionary<string, Rectangle> rectangles);
    }
}