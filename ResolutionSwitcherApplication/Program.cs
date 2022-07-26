using CommandLine;
using ResolutionSwitcher.Shared;

namespace ResolutionSwitcherApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args)
                .WithParsed(RunOptions)
                .WithNotParsed(HandleParseError);
        }

        static void RunOptions(Options opts)
        {
            var resHelper = new ResolutionHelper();
            resHelper.ChangeDisplaySettings(opts.Width, opts.Heigth);
            resHelper.ChangeDpiSettings(opts.DPI);
        }
        static void HandleParseError(IEnumerable<Error> errs)
        {
            // Handle errors that have to do with options binding
        }
    }
}