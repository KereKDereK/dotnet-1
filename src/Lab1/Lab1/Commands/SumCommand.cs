using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lab1
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
            var data = _figureRepository.GetAll();
            var sum = 0.0;
            foreach (var shape in data)
                sum += shape.GetArea();
            AnsiConsole.Write("Total area:\n" + sum);
            AnsiConsole.Write("\nTotal area using System.Linq:\n" + data.Sum(f => f.GetArea()));
            return 0;
        }
    }
}