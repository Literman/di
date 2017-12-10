using System.Drawing;
using System.IO;
using System.Linq;
using Autofac;
using CommandLine;

namespace TagsCloudVisualization
{
    class Program
    {
        static void Main(string[] args)
        {
            var parseResult = Parser.Default.ParseArguments<Options>(args);
            if (parseResult.Errors.Any()) return;
            var options = parseResult.Value;

            var text = File.ReadLines(options.InputFile);
            var imgSize = new Size(options.Width, options.Height);
            var center = new Point(imgSize.Width / 2, imgSize.Height / 2);

            var builder = new ContainerBuilder();
            builder.Register(c => center);
            builder.Register(o => options);

            builder.RegisterType<CircularCloudLayouter>().As<ICloudLayouter>();
            builder.RegisterType<CircularCloudMaker>().As<ICloudMaker>();
            builder.RegisterType<CircularCloudDrawer>().As<ICloudDrawer>();

            builder.RegisterType<Placer>().As<IPlacer>();
            builder.RegisterType<WordsFilter>().As<IFilter>();
            var container = builder.Build();

            var dict = container.Resolve<IFilter>().Preprocessing(text);
            var maker = container.Resolve<ICloudMaker>();
            var drawer = container.Resolve<ICloudDrawer>();

            var rectangles = maker.MakeCloud(dict);
            drawer.Draw(rectangles);
        }
    }
}
