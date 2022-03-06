﻿using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;
using Lab1.Infrastructure;
using PromLab01.Commands;

namespace PromLab01
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IXmlFigureRepository, XmlFigureRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<AddFigureCommand>("add");
                config.AddCommand<DeleteCommand>("delete");
                config.AddCommand<DeleteAllCommand>("deleteall");
                config.AddCommand<TableCommand>("table");
                config.AddCommand<SumCommands>("sum");
                config.AddCommand<CompareCommand>("compare");
            });

            app.Run(args);
        }
    }
}