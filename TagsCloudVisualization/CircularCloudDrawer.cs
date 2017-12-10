using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TagsCloudVisualization
{
    public class CircularCloudDrawer : ICloudDrawer
    {
        private readonly Point center;
        private readonly Options options;

        public CircularCloudDrawer(Point center, Options options)
        {
            this.center = center;
            this.options = options;
        }

        public void Draw(Dictionary<string, Rectangle> rectangles)
        {
            using (var bitmap = new Bitmap(options.Width, options.Height))
            {
                Draw(center, rectangles, bitmap, options.Font);
                var form = new Form
                {
                    Width = options.Width,
                    Height = options.Height,
                    BackgroundImage = bitmap
                };
                form.ShowDialog();
            }
        }

        public void Save(Dictionary<string, Rectangle> rectangles)
        {
            using (var bitmap = new Bitmap(options.Width, options.Height))
            {
                Draw(center, rectangles, bitmap, options.Font);
                bitmap.Save(options.OutputFile);
            }
        }

        private static void Draw(Point center, Dictionary<string, Rectangle> rectangles, Image bitmap, string fontName)
        {
            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawRectangle(new Pen(Color.Red), center.X, center.Y, 1, 1);

                foreach (var rect in rectangles)
                    TextRenderer.DrawText(g, rect.Key, new Font(fontName, (int)((double)rect.Value.Height * 2 / 3)), rect.Value, Color.Orange);
            }
        }
    }
}