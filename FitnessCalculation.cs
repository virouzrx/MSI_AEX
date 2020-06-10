using System;
using System.Collections.Generic;
using System.Text;

namespace MSI_AEX
{
    public class FitnessCalculation
    {
        public double[] fitness = new double[100];
        public double massiveFit = 0;
        public double[] HistroyOfFit = new double[1000];
        PopulationGenerating pg = new PopulationGenerating();
        KeysWeight kw = new KeysWeight();
        public void CalculateFitness()
        {
            
            HistroyOfFit[0] = 100000 - 2;
            HistroyOfFit[1] = 100000 - 1;
            HistroyOfFit[2] = 100000;
            massiveFit = 0;
            for (int i = 0; i < pg.Populacja.Length; i++)
            {
                for (int j = 0; j < kw.keyWeight.Length; j++)
                {
                    fitness[i] = pg.PopulacjaForWeight[i][j] * kw.keyWeight[j];
                }
                massiveFit += fitness[i]; 
            }
        }
    }
}
