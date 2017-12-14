namespace TagsCloudVisualization
{
    public class CircularCloudBuilder : ICloudBuilder
    {
        private readonly ICloudLayouter layouter;
        private readonly string fontName;

        public CircularCloudBuilder(ICloudLayouter layouter, Options options)
        {
            this.layouter = layouter;
            fontName = options.Font;
        }

        public WordsBox MakeCloud(WordsBox words) => words.CreateRectangles(layouter, fontName);
    }
}