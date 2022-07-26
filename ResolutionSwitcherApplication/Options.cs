using CommandLine;

namespace ResolutionSwitcherApplication
{
    internal class Options
    {
        [Option('w', "width", Required = true, HelpText = "Width of primary screen in pixels.")]
        public int Width { get; set; } = 1920;

        [Option('h', "heigth", Required = true, HelpText = "Heigth of primary screen in pixels.")]
        public int Heigth { get; set; } = 1080;

        [Option('d', "dpi", Required = false, HelpText = "Scaling level of primary screen in percentage.")]
        public int? DPI { get; set; }
    }
}
