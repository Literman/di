using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TagsCloudVisualization
{
    public class WordsBox
    {
        public Dictionary<string, int> Sizes { get; }
        public Dictionary<string, Rectangle> Rectangles { get; }
        private const int MaxSize = 80;
        private const int MinSize = 20;

        public WordsBox(Dictionary<string, int> sizes)
        {
            Sizes = sizes;
            Rectangles = new Dictionary<string, Rectangle>(); 
        }

        public WordsBox CreateRectangles(ICloudLayouter layouter, string fontName)
        {
            var maxCount = Sizes.Values.Max();
            foreach (var size in Sizes)
            {
                var tagSize = (int)((double)size.Value / maxCount * (MaxSize - MinSize) + MinSize);
                var font = new Font(fontName, tagSize, GraphicsUnit.Pixel);
                var rectangleSize = TextRenderer.MeasureText(size.Key, font);
                Rectangles[size.Key] = layouter.PutNextRectangle(rectangleSize);
            }
            return this;
        }
    }
}