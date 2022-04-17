using Lab1.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Lab01.Commands;
using Spectre.Console.Cli;

namespace Lab01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IXmlRepository, XmlShapeRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<ShowDataCommand>("table");
                config.AddCommand<AddShapeCommand>("add");
                config.AddCommand<DeleteShapeCommand>("delete");
                config.AddCommand<DeleteAllCommand>("delete_all");
                config.AddCommand<CompareShapesCommand>("compare");
                config.AddCommand<SumCommand>("sum");
            });

            app.Run(args);
        }
    }
}
