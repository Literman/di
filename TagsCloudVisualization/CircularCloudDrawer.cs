using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TagsCloudVisualization
{
    public class CircularCloudDrawer
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

        public void Draw(string path, Dictionary<string, Rectangle> rectangles)
        {
            Draw(rectangles);
            Save(path, center, rectangles, options.Width, options.Height, options.Font);
        }

        public static void Save(string path, Point center, Dictionary<string, Rectangle> rectangles, int width, int height, string fontName)
        {
            using (var bitmap = new Bitmap(width, height))
            {
                Draw(center, rectangles, bitmap, fontName);
                bitmap.Save(path);
            }
        }

        private static void Draw(Point center, Dictionary<string, Rectangle> rectangles, Bitmap bitmap, string fontName)
        {
            using (var g = Graphics.FromImage(bitmap))
            {
                //var rectPen = new Pen(Color.Blue);
                g.DrawRectangle(new Pen(Color.Red), center.X, center.Y, 1, 1);

                foreach (var rectangle in rectangles)
                {
                    TextRenderer.DrawText(g, rectangle.Key, new Font(fontName, rectangle.Value.Height / 2), rectangle.Value, Color.Orange);
                    //g.DrawRectangle(rectPen, rectangle.Value);
                }
            }
        }
    }
}