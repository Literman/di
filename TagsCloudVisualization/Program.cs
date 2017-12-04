using System;
using System.Collections.Generic;
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
            
            builder.RegisterType<CircularCloudLayouter>();
            builder.RegisterType<CircularCloudMaker>();
            builder.RegisterType<CircularCloudDrawer>();

            builder.RegisterType<Placer>().As<IPlacer>();
            builder.RegisterType<WordsFilter>();
            var container = builder.Build();

            var dict = container.Resolve<WordsFilter>().Preprocessing(text);
            var maker = container.Resolve<CircularCloudMaker>();
            var drawer = container.Resolve<CircularCloudDrawer>();

            var rectangles = maker.MakeCloud(dict);

            drawer.Draw(rectangles);
        }
    }
}
