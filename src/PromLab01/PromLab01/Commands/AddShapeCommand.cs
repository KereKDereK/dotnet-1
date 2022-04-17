using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Lab01.Commands
{
    public class AddShapeCommand : Command<AddShapeCommand.AddShapeSettings>
    {
        public class AddShapeSettings : CommandSettings
        {
        }

        private readonly IXmlRepository _shapeRepository;

        public AddShapeCommand(IXmlRepository shapeRepository)
        {
            _shapeRepository = shapeRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] AddShapeSettings settings)
        {
            var exit = 0;
            _shapeRepository.OpenFile(_shapeRepository.StorageFileName);
            var rule = new Rule("[#0eef59]Main Menu[/]");
            rule.Style = Style.Parse("#0eef59");

            while (exit != -1)
            {
                if (_shapeRepository.Shapes.Count == 0)
                {
                    AnsiConsole.Write("Please, enter '0'\n");
                }
                else
                {
                    AnsiConsole.Write("Previously used index:{0}\n", _shapeRepository.Shapes.Count - 1);
                }

                int index = 0;

                try
                {
                    index = AnsiConsole.Prompt(new TextPrompt<int>(" Index :"));
                    if (index != _shapeRepository.Shapes.Count) throw new Exception("Incorrect index");
                }

                catch (Exception)
                {
                    index = AnsiConsole.Prompt(new TextPrompt<int>(" Please enter correct index :"));
                }
                var figure = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Please select [#0eef59]menu prompt[/], that you're interested in")
                .PageSize(10)
                .AddChoices(new[] {
                "Rectangle", "Circle", "Triangle", "Exit"
                }));
                switch (figure)
                {
                    case "Rectangle":
                        _shapeRepository.AddRectangle(index, new Point(AnsiConsole.Ask<double>("Type [green]first[/] point [green]X[/]: "),
                            AnsiConsole.Ask<double>("Type [green]first[/] point [green]Y[/]: ")),
                            new Point(AnsiConsole.Ask<double>("Type [green]second[/] point [green]X[/]: "),
                            AnsiConsole.Ask<double>("Type [green]second[/] point [green]Y[/]: ")));
                        AnsiConsole.Clear();
                        break;

                    case "Circle":

                        _shapeRepository.AddCircle(index, new Point(AnsiConsole.Ask<double>("Type [green]first[/] point [green]X[/]: "),
                            AnsiConsole.Ask<double>("Type [green]first[/] point [green]Y[/]: ")),
                            AnsiConsole.Ask<double>("Type [green]radius[/] of a circle: "));
                        AnsiConsole.Clear();
                        break;

                    case "Triangle":
                        _shapeRepository.AddTriangle(index, new Point(AnsiConsole.Ask<double>("Type [green]first[/] point [green]X[/]: "),
                            AnsiConsole.Ask<double>("Type [green]first[/] point [green]Y[/]: ")), new Point(AnsiConsole.Ask<double>("Type [green]second[/] point [green]X[/]: "),
                            AnsiConsole.Ask<double>("Type [green]second[/] point [green]Y[/]: ")), new Point(AnsiConsole.Ask<double>("Type [green]third[/] point [green]X[/]: "),
                            AnsiConsole.Ask<double>("Type [green]third[/] point [green]Y[/]: ")));
                        AnsiConsole.Clear();
                        break; ;

                    case "Exit":
                        exit = -1;
                        break;

                    default:
                        break;
                }
            }
            _shapeRepository.SaveFile(_shapeRepository.StorageFileName);
            return 0;
        }
    }
}
