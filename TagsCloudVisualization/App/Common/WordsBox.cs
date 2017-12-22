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

        public Result<WordsBox> CreateRectangles(ICloudLayouter layouter, string fontName)
        {
            var maxCount = Sizes.Values.Max();
            foreach (var size in Sizes)
            {
                var tagSize = (int)((double)size.Value / maxCount * (MaxSize - MinSize) + MinSize);
                var fontResult = Result.Of(() => new Font(fontName, tagSize, GraphicsUnit.Pixel));
                if (!fontResult.IsSuccess)
                    return Result.Fail<WordsBox>($"Font {fontName} doesn't exist");

                var rectangleSize = TextRenderer.MeasureText(size.Key, fontResult.Value);
                var putResult = layouter.PutNextRectangle(rectangleSize);
                if (!putResult.IsSuccess)
                    return Result.Fail<WordsBox>(putResult.Error);

                Rectangles[size.Key] = putResult.Value;
            }
            return this;
        }
    }
}