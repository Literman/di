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
            var container = Inject(options);
            MakeCloud(container, options).OnFail(Console.WriteLine);
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

        private static Result<None> MakeCloud(IContainer container, Options options)
        {
            return Result.Of(() => File.ReadLines(options.InputFile))
                .Then(container.Resolve<ICloud>().Build);
        }
    }
}
