using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Commands
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
            if (_shapeRepository.GetAll().Count == 0)
            {
                AnsiConsole.Write("There are no figures\n");
                return 0;
            }
            _shapeRepository.DeleteAll();
            return 0;
        }
    }
}
