using System;
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
            MakeCloud(options);
        }

        private static IContainer Inject(Options options)
        {
            var center = new Point(options.Width / 2, options.Height / 2);
            var builder = new ContainerBuilder();
            builder.Register(c => center);
            builder.Register(o => options);
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .AsImplementedInterfaces();
            return builder.Build();
        }

        private static Result<None> MakeCloud(Options options)
        {
            var container = Inject(options);
            return Result.Of(() => File.ReadLines(options.InputFile))
                .Then(container.Resolve<IFiltrator>().Preprocessing)
                .Then(container.Resolve<ICloudBuilder>().MakeCloud)
                .Then(container.Resolve<ICloudDrawer>().Draw);
        }
    }
}
