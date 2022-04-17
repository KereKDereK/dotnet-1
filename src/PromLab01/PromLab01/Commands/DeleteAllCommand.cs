using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab01.Commands
{
    public class DeleteAllCommand : Command<DeleteAllCommand.DeleteAllSettings>
    {
        public class DeleteAllSettings : CommandSettings
        {
        }

        private readonly IXmlRepository _shapeRepository;

        public DeleteAllCommand(IXmlRepository shapeRepository)
        {
            _shapeRepository = shapeRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] DeleteAllSettings settings)
        {
            _shapeRepository.OpenFile(_shapeRepository.StorageFileName);
            if (_shapeRepository.Shapes.Count == 0)
            {
                AnsiConsole.Write("There are no figures\n");
                return 0;
            }
            _shapeRepository.DeleteAll();
            _shapeRepository.SaveFile(_shapeRepository.StorageFileName);
            return 0;
        }
    }
}
