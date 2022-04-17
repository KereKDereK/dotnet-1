using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab01.Commands
{
    public class CompareShapesCommand : Command<CompareShapesCommand.CompareShapesSettings>
    {
        public class CompareShapesSettings : CommandSettings
        {
        }

        private readonly IXmlRepository _shapeRepository;

        public CompareShapesCommand(IXmlRepository shapeRepository)
        {
            _shapeRepository = shapeRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] CompareShapesSettings settings)
        {
            _shapeRepository.OpenFile(_shapeRepository.StorageFileName);
            var rule = new Rule("[#0eef59]Main Menu[/]");
            rule.Style = Style.Parse("#0eef59");
            var figure = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Please select [#0eef59]menu prompt[/], that you're interested in")
            .PageSize(10)
            .AddChoices(new[] {
                "Area comparing", "Perimeter comparing", "Exit"
            }));
            var i = 0;
            switch (figure)
            {
                case "Area comparing":
                    i = _shapeRepository.CompareArea(
                        AnsiConsole.Ask<int>("Type [green]first[/] shape [green]index[/]: "),
                        AnsiConsole.Ask<int>("Type [green]second[/] shape [green]index[/]: "));
                    AnsiConsole.Write($"{i} shape is larger");
                    break;

                case "Perimeter comparing":
                    i = _shapeRepository.ComparePerimeter(
                        AnsiConsole.Ask<int>("Type [green]first[/] shape [green]index[/]: "),
                        AnsiConsole.Ask<int>("Type [green]second[/] shape [green]index[/]: "));
                    AnsiConsole.Write("{0} shape is larger", i);
                    break;

                case "Exit":
                    return 0;

                default:
                    break;
            }
            return 0;
        }
    }
}

