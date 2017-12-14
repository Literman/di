namespace TagsCloudVisualization
{
    public class CircularCloudMaker : ICloudMaker
    {
        private readonly ICloudLayouter cloudMaker;
        private readonly string fontName;

        public CircularCloudMaker(ICloudLayouter cloudMaker, Options options)
        {
            this.cloudMaker = cloudMaker;
            fontName = options.Font;
        }

        public WordsBox MakeCloud(WordsBox words) => words.CreateRectangles(cloudMaker, fontName);
    }
}