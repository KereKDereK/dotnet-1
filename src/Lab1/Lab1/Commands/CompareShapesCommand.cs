using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
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
            var data = _shapeRepository.GetAll();
            var rule = new Rule("[#0eef59]Main Menu[/]");
            rule.Style = Style.Parse("#0eef59");
            int index1 = AnsiConsole.Prompt(
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
            int index2 = AnsiConsole.Prompt(
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
                "Area comparing", "Perimeter comparing"
            }));
            switch (figure)
            {
                case "Area comparing":
                    if (data[index1].GetArea() > data[index2].GetArea())
                        AnsiConsole.Write("{0} is larger", index1);
                    else if (data[index1].GetArea() < data[index2].GetArea())
                        AnsiConsole.Write("{0} is larger", index2);
                    else AnsiConsole.Write("Shapes are equal", index2);
                    break;

                case "Perimeter comparing":
                    if (data[index1].GetPerimeter() > data[index2].GetPerimeter())
                        AnsiConsole.Write("{0} is larger", index1);
                    else if (data[index1].GetPerimeter() < data[index2].GetPerimeter())
                        AnsiConsole.Write("{0} is larger", index2);
                    else AnsiConsole.Write("Shapes are equal", index2);
                    break;

                default:
                    break;
            }
            return 0;
        }
    }
}

