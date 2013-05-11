using System;

class MainGenerate
{
    static void Main()
    {
        InputDataGenerator inputGenerator = new InputDataGenerator();
        inputGenerator.GenerateData(1000, "1000-all-on-one.txt");
    }
}
