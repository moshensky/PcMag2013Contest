using System;
using System.Collections.Generic;
using System.IO;

class InputDataGenerator
{
    const int MaxFieldSize = 500;
    const int MaxFigures = 1000;
    const int Seed = 3156387;

    private Dictionary<int, string> figures = new Dictionary<int, string>();
    private Random randomGenerator = new Random(Seed);

    public Dictionary<int, string> Figures 
    {
        get { return this.figures; }
        set { this.figures = value; }
    }

    public InputDataGenerator()
    {
        Figures.Add(0, "ninetile");
        Figures.Add(1, "plus");
        Figures.Add(2, "hline");
        Figures.Add(3, "vline");

        Figures.Add(4, "angle-ur");
        Figures.Add(5, "angle-dr");
        Figures.Add(6, "angle-dl");
        Figures.Add(7, "angle-ul");
    }

    public void GenerateData(int figuresCount, string filename)
    {
        if (figuresCount > 1000)
        {
            throw new ArgumentOutOfRangeException("Figures is bigger then tha maximal allowed!");
        }
        else if (figuresCount < 1)
        {
            throw new ArgumentOutOfRangeException("Figures is less then tha maximal allowed!");
        }

        StreamWriter dataWriter = new StreamWriter(filename);

        using (dataWriter)
        {
            dataWriter.WriteLine(figuresCount);
            for (int i = 0; i < figuresCount; i++)
            {
                int xCoord = 1;//randomGenerator.Next(1, MaxFieldSize - 1);
                int yCoord = 1;// randomGenerator.Next(1, MaxFieldSize - 1);
                string figure = Figures[randomGenerator.Next(Figures.Count)];
                dataWriter.WriteLine(figure + " " + xCoord + " " + yCoord + " ");
            }
        }
    }
}
