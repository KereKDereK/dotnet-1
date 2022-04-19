using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
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
            var rule = new Rule("[#0eef59]Main Menu[/]");
            rule.Style = Style.Parse("#0eef59");
            int index = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter desired shape index:")
            .ValidationErrorMessage("Invalid index")
                .Validate(index =>
                {
                    return index switch
                    {
                        < 0 => ValidationResult.Error("The index must be positive number"),
                        _ => ValidationResult.Success(),
                    };
                }));
            var figure = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Please select [#0eef59]menu prompt[/], that you're interested in")
                .PageSize(10)
                .AddChoices(new[] {
                "Rectangle", "Circle", "Triangle"
                }));
            switch (figure)
            {
                case "Rectangle":
                    _shapeRepository.AddShape(index, new Rectangle
                        (new Point(AnsiConsole.Ask<double>("Type [green]first[/] point [green]X[/]: "),
                        AnsiConsole.Ask<double>("Type [green]first[/] point [green]Y[/]: ")),
                        new Point(AnsiConsole.Ask<double>("Type [green]second[/] point [green]X[/]: "),
                        AnsiConsole.Ask<double>("Type [green]second[/] point [green]Y[/]: "))));
                    break;

                case "Circle":

                    _shapeRepository.AddShape(index, new Circle
                        (new Point(AnsiConsole.Ask<double>("Type [green]first[/] point [green]X[/]: "),
                        AnsiConsole.Ask<double>("Type [green]first[/] point [green]Y[/]: ")),
                        AnsiConsole.Ask<double>("Type [green]radius[/] of a circle: ")));
                    break;

                case "Triangle":
                    _shapeRepository.AddShape(index, new Triangle
                        (new Point(AnsiConsole.Ask<double>("Type [green]first[/] point [green]X[/]: "),
                        AnsiConsole.Ask<double>("Type [green]first[/] point [green]Y[/]: ")), new Point(AnsiConsole.Ask<double>("Type [green]second[/] point [green]X[/]: "),
                        AnsiConsole.Ask<double>("Type [green]second[/] point [green]Y[/]: ")), new Point(AnsiConsole.Ask<double>("Type [green]third[/] point [green]X[/]: "),
                        AnsiConsole.Ask<double>("Type [green]third[/] point [green]Y[/]: "))));
                    break; ;

                default:
                    break;
            }
            return 0;
        }
    }
}
