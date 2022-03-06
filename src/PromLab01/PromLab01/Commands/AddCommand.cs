﻿using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PromLab01.Commands
{
    public class AddFigureCommand : Command<AddFigureCommand.AddFigureSettings>
    {

        public class AddFigureSettings : CommandSettings { }


        private readonly IXmlFigureRepository _figureRepository;

        public AddFigureCommand(IXmlFigureRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] AddFigureSettings settings)
        {
            var exit = 0;
            while (exit != -1)
            {
                _figureRepository.OpenFile(_figureRepository.StorageFileName);
                var add = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                .Title("Please select [#0eef59]menu prompt[/], that you're interested in")
                                .AddChoices("Rectangle", "Circle", "Triangle", "Exit"));
                if (add != "Exit")
                {
                    if (_figureRepository.Figures.Count == 0)
                    {
                        AnsiConsole.Write("Please, enter '0'\n");
                    }
                    else
                    {
                        AnsiConsole.Write("Previously used index:{0}\n", _figureRepository.Figures.Count - 1);
                    }


                }
                int indexAdd = AnsiConsole.Prompt(new TextPrompt<int>(" Index :"));


                if (_figureRepository.CheckIndex(indexAdd) || indexAdd == _figureRepository.Figures.Count)
                {
                    switch (add)
                    {
                        case "Rectangle":
                            _figureRepository.AddRectangle(
                                indexAdd,
                                FirstPointCoordinate(),
                                SecondPointCoordinate());
                            Console.Clear();
                            break;
                        case "Circle":
                            _figureRepository.AddCircle(
                                indexAdd,
                                FirstPointCoordinate(),
                                AnsiConsole.Prompt(new TextPrompt<double>("Radius :")));
                            Console.Clear();
                            break;
                        case "Triangle":
                            _figureRepository.AddTriangle(
                                indexAdd,
                                FirstPointCoordinate(),
                                SecondPointCoordinate(),
                                ThirdPointCoordinate());
                            Console.Clear();
                            break;


                        case "Exit":
                            exit = -1;
                            break;

                        default:
                            break;
                    };
                }
                else
                {
                    AnsiConsole.Write("Incorrect index");
                    Console.ReadLine();
                }
                _figureRepository.SaveFile(_figureRepository.StorageFileName);
            }

            return 0;
        }


        private Point FirstPointCoordinate()
        {
            return new Point(
                AnsiConsole.Prompt(new TextPrompt<double>("First Point X Coordinate:")),
                AnsiConsole.Prompt(new TextPrompt<double>("First Point Y Coordinate:")));
        }
        private Point SecondPointCoordinate()
        {
            return new Point(
                AnsiConsole.Prompt(new TextPrompt<double>("Second Point X Coordinate:")),
                AnsiConsole.Prompt(new TextPrompt<double>("Second Point Y Coordinate:")));
        }
        private Point ThirdPointCoordinate()
        {
            return new Point(
                AnsiConsole.Prompt(new TextPrompt<double>("Third Point X Coordinate:")),
                AnsiConsole.Prompt(new TextPrompt<double>("Third Point Y Coordinate:")));
        }
    }
}