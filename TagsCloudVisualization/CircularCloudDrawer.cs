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

        public void Draw(WordsBox wordsBox)
        {
            using (var bitmap = new Bitmap(options.Width, options.Height))
            {
                Draw(center, wordsBox.Rectangles, bitmap, options.Font);
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

        internal static void Save(string path, List<Rectangle> rectangles, int width, int height)
        {
            using (var bitmap = new Bitmap(width, height))
            {
                Draw(rectangles, bitmap);
                bitmap.Save(path);
            }
        }

        private static void Draw(List<Rectangle> rectangles, Image bitmap)
        {
            var center = new Point(bitmap.Width / 2, bitmap.Height / 2);
            var rectPen = new Pen(Color.Blue);

            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawRectangle(new Pen(Color.Red), center.X, center.Y, 1, 1);
                foreach (var rectangle in rectangles)
                    g.DrawRectangle(rectPen, rectangle);
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