using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab01.Commands
{
    public class ShowDataCommand : Command<ShowDataCommand.ShowDataSettings>
    {
        public class ShowDataSettings : CommandSettings
        {
        }

        private readonly IXmlRepository _shapeRepository;

        public ShowDataCommand(IXmlRepository shapeRepository)
        {
            _shapeRepository = shapeRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ShowDataSettings settings)
        {
            _shapeRepository.OpenFile(_shapeRepository.StorageFileName);
            var table = new Table();
            table.AddColumns("Index", "Type", "Info", "Area", "Perimeter", "Borders");
            var rule = new Rule("[#0eef59]Main Menu[/]");
            rule.Style = Style.Parse("#0eef59");
            if (_shapeRepository.Shapes.Count == 0)
            {
                AnsiConsole.Write("There are no shapes\n");
                return 0;
            }
            var i = 0;
            foreach (var shape in _shapeRepository.Shapes)
            {
                table.AddRow(new Markup(i.ToString()),
                    new Markup(shape.GetType().Name),
                    new Markup("[green]" + shape.ToString() + "[/]"),
                    new Markup("[green]" + shape.GetArea() + "[/]"),
                    new Markup("[green]" + shape.GetPerimeter() + "[/]"),
                    new Markup("[green]" + shape.GetBorders().ToString() + "[/]"));
                ++i;
            }
            AnsiConsole.Write(table);
            return 0;
        }
    }
}
