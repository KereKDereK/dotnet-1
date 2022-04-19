using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
{
    public class DeleteShapeCommand : Command<DeleteShapeCommand.DeleteShapeSettings>
    {
        public class DeleteShapeSettings : CommandSettings
        {
        }

        private readonly IXmlRepository _shapeRepository;

        public DeleteShapeCommand(IXmlRepository shapeRepository)
        {
            _shapeRepository = shapeRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] DeleteShapeSettings settings)
        {
            if (_shapeRepository.GetAll().Count == 0)
            {
                AnsiConsole.Write("There are no figures\n");
                return 0;
            }
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
            _shapeRepository.DeleteShape(index);
            return 0;
        }
    }
}
