using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab01.Commands
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
            _shapeRepository.OpenFile(_shapeRepository.StorageFileName);
            if (_shapeRepository.Shapes.Count == 0)
            {
                AnsiConsole.Write("There are no figures\n");
                return 0;
            }
            int index = 0;
            index = AnsiConsole.Prompt(new TextPrompt<int>(" Please enter desired shape index :"));
            if (_shapeRepository.CheckIndex(index))
            {
                _shapeRepository.DeleteShape(index);
            }
            else
                AnsiConsole.Write("Incorrect index\n");
            _shapeRepository.SaveFile(_shapeRepository.StorageFileName);
            return 0;
        }
    }
}
