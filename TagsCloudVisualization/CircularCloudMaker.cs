using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TagsCloudVisualization
{
    public class CircularCloudMaker
    {
        private readonly CircularCloudLayouter cloudMaker;
        private readonly string fontName;
        private const int MaxSize = 80;
        private const int MinSize = 20;

        public CircularCloudMaker(CircularCloudLayouter cloudMaker, Options options)
        {
            this.cloudMaker = cloudMaker;
            fontName = options.Font;
        }

        public Dictionary<string, Rectangle> MakeCloud(Dictionary<string, int> tags)
        {
            return tags.ToDictionary(
                tag => tag.Key, 
                tag => GetRectangle(tags.Values.Max(), tag));
        }

        private Rectangle GetRectangle(int maxCount, KeyValuePair<string, int> tag)
        {
            var tagSize = (int)((double)tag.Value / maxCount * (MaxSize - MinSize) + MinSize);
            var font = new Font(fontName, tagSize, GraphicsUnit.Pixel);
            var rectangleSize = TextRenderer.MeasureText(tag.Key, font);
            return cloudMaker.PutNextRectangle(rectangleSize);
        }
    }
}