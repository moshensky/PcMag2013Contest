using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Timers;

namespace Algorithm
{
    public class TilesMain
    {
        public static void Main(String[] args)
        {
            TilesMain game = new TilesMain();
            Engine engine = new Engine();
            List<Figure> figures = new List<Figure>();
            String[] input = game.ReadInput();

            game.CreateFigures(input, engine, figures);
            engine.Run();
            PrintResult(figures);
        }

        private static void PrintResult(List<Figure> figures)
        {
            StringBuilder result = new StringBuilder(10000);

            foreach (var resultFigure in figures)
            {
                result.Append(resultFigure.PosX + " " + resultFigure.PosY + "\n");
            }

            result.Remove(result.Length - 1, 1);
            Console.WriteLine(result.ToString());
        }

        private String[] ReadInput()
        {
            // TODO: Check for correct input for the application part
            string line = Console.ReadLine();
            int commandsCount = int.Parse(line);

            String[] commands = new String[commandsCount];

            for (int i = 0; i < commandsCount; i++)
            {
                commands[i] = Console.ReadLine();
            }

            return commands;
        }

        private void CreateFigures(String[] input, Engine engine, List<Figure> figures)
        {
            Figure figure;
            String createFigure;
            int firstWhiteSpaceIndex;
            int secondWhiteSpaceIndex;
            int posX;
            int posY;

            foreach (var command in input)
            {
                // TODO: Check if the commands have correct values for the application part
                firstWhiteSpaceIndex = command.IndexOf(' ');
                secondWhiteSpaceIndex = command.IndexOf(' ', firstWhiteSpaceIndex + 1);
                createFigure = command.Substring(0, firstWhiteSpaceIndex);

                string xPosString = command.Substring(firstWhiteSpaceIndex, secondWhiteSpaceIndex - firstWhiteSpaceIndex);
                string yPosString = command.Substring(secondWhiteSpaceIndex + 1);

                posX = int.Parse(xPosString);
                posY = int.Parse(yPosString);

                switch (createFigure)
                {
                    case "ninetile":
                        figure = new Ninetile(posX, posY);
                        break;
                    case "plus":
                        figure = new Plus(posX, posY);
                        break;
                    case "hline":
                        figure = new HorizontalLine(posX, posY);
                        break;
                    case "vline":
                        figure = new VerticalLine(posX, posY);
                        break;
                    case "angle-ur":
                        figure = new UpRightCorner(posX, posY);
                        break;
                    case "angle-dr":
                        figure = new DownRightCorner(posX, posY);
                        break;
                    case "angle-dl":
                        figure = new DownLeftCorner(posX, posY);
                        break;
                    case "angle-ul":
                        figure = new UpLeftCorner(posX, posY);
                        break;

                    default:
                        throw new Exception("No such name of figure exists: " + createFigure);
                }

                engine.AddFigure(figure);
                figures.Add(figure);
            }
        }
    }
}
