using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization
{
    public interface ICloudMaker
    {
        WordsBox MakeCloud(WordsBox words);
    }
}