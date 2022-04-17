using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab01
{
    public class SumCommand : Command<SumCommand.SumSquareCommandSettings>
    {
        public class SumSquareCommandSettings : CommandSettings
        {
        }

        private readonly IXmlRepository _figureRepository;

        public SumCommand(IXmlRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] SumSquareCommandSettings settings)
        {
            _figureRepository.OpenFile(_figureRepository.StorageFileName);
            AnsiConsole.Write("Total area:\n" + _figureRepository.Sum());
            AnsiConsole.Write("\nTotal area using System.Linq:\n" + _figureRepository.SumLinq());
            return 0;
        }
    }
}