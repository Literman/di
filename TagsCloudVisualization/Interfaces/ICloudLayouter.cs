using System.Drawing;

namespace TagsCloudVisualization
{
    public interface ICloudLayouter
    {
        Result<Rectangle> PutNextRectangle(Size rectangleSize);
    }
}