using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization
{
    public interface ICloudBuilder
    {
        WordsBox MakeCloud(WordsBox words);
    }
}