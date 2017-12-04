using CommandLine;

namespace TagsCloudVisualization
{
    public class Options
    {
        [Option('i', "input", Required = true, HelpText = "input file")]
        public string InputFile { get; private set; }

        [Option('o', "output", Required = true, HelpText = "output file")]
        public string OutputFile { get; set; }

        [Option('w', "width", DefaultValue = 800, HelpText = "image width")]
        public int Width { get; set; }

        [Option('h', "height", DefaultValue = 800, HelpText = "image height")]
        public int Height { get; set; }

        [Option('c', "count", DefaultValue = 100, HelpText = "words count in cloud")]
        public int Count { get; set; }

        [Option('l', "length", DefaultValue = 3, HelpText = "minimum words length in cloud")]
        public int Length { get; set; }

        [Option('f', "font", DefaultValue = "Arial", HelpText = "font name")]
        public string Font { get; set; }
    }
}