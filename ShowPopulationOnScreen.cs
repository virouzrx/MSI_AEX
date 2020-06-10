using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MSI_AEX
{
    public class ShowPopulationOnScreen
    {
        
        public PopulationGenerating pg = new PopulationGenerating();
        public FitnessCalculation fc = new FitnessCalculation();
        public GenereteNewPopulation gnp = new GenereteNewPopulation();
        public void ShowOnScreen()
        {
            using (StreamWriter sw = File.AppendText("date.txt"))
            {
                sw.WriteLine("Pokolenie {0}:\r\n\t", gnp.t - 2);
                for (int i = 0; i < pg.Populacja.Length; i++)
                {
                    sw.Write("Osobnik {0}:\r\n", i + 1);
                    for (int j = 0; j < pg.Populacja[i].Length; j++)
                    {
                        if (j == 0)
                            sw.Write("\t\t");
                        if (j == 10 || j == 20)
                            sw.Write("\r\n\t\t");
                        sw.Write(pg.Populacja[i][j]);
                    }
                    sw.Write("\r\nFitness: {0}", fc.fitness[i]);
                    sw.Write("\r\n");
                }
            }
        }
    }
}