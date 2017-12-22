using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization
{
    public interface ICloudBuilder
    {
        Result<WordsBox> MakeCloud(WordsBox words);
    }
}