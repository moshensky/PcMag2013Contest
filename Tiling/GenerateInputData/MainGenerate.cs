using System;

class MainGenerate
{
    static void Main()
    {
        InputDataGenerator inputGenerator = new InputDataGenerator();
        inputGenerator.GenerateData(100, "100-all-on-one.txt");
    }
}
