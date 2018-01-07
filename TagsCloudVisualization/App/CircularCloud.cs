using System.Collections.Generic;

namespace TagsCloudVisualization
{
    public class CircularCloud : ICloud
    {
        private readonly IFiltrator filtrator;
        private readonly ICloudLayouter layouter;
        private readonly ICloudDrawer drawer;
        private readonly ICloudBuilder builder;

        public CircularCloud(IFiltrator filtrator, ICloudLayouter layouter, ICloudDrawer drawer, ICloudBuilder builder)
        {
            this.filtrator = filtrator;
            this.layouter = layouter;
            this.drawer = drawer;
            this.builder = builder;
        }

        public Result<None> Build(IEnumerable<string> input)
        {
            return filtrator.Preprocessing(input)
                .Then(builder.MakeCloud)
                .Then(drawer.Draw);
        }
    }
}