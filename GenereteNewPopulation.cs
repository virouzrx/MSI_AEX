using System;
using System.Collections.Generic;
using System.Text;

namespace MSI_AEX
{
    public class GenereteNewPopulation
    {
        double[] fitnessMasterPosition = new double[100];
        char[][] newPopulation = new char[100][];
        double[][] newPopulationWeight = new double[100][];
        public int t = 3;

        AEXCrossing aex = new AEXCrossing();
        FitnessCalculation fc = new FitnessCalculation();
        PopulationGenerating pg = new PopulationGenerating();
        ChildrenFitnessCalculation cfc = new ChildrenFitnessCalculation();
        public void GenerateNewPopulation()
        {
            for (int i = 0; i < fitnessMasterPosition.Length; i++)
            {
                fitnessMasterPosition[i] = 2000;
            }

            aex.number = 0;
            double tempFit;
            for (int j = 0; j < 20; j++)
            {
                newPopulationWeight[j] = new double[30];
                newPopulation[j] = new char[30];
                for (int k = 0; k < fc.fitness.Length; k++)
                {
                    if (fitnessMasterPosition[j] > fc.fitness[k])
                    {
                        tempFit = fc.fitness[k];
                        fc.fitness[aex.number] = fitnessMasterPosition[j];
                        aex.number = k;
                        fitnessMasterPosition[j] = tempFit;
                        for (int l = 0; l < pg.Populacja[k].Length; l++)
                        {
                            newPopulation[j][l] = pg.Populacja[k][l];
                            newPopulationWeight[j][l] = pg.PopulacjaForWeight[k][l];
                        }
                        fc.fitness[k] = 3000;
                    }
                }
            }
            for (int j = 20; j < 100; j++)
            {
                newPopulationWeight[j] = new double[30];
                newPopulation[j] = new char[30];
                for (int k = 0; k < cfc.fitnessChildren.Length; k++)
                {
                    if (fitnessMasterPosition[j] > cfc.fitnessChildren[k])
                    {
                        tempFit = cfc.fitnessChildren[k];
                        cfc.fitnessChildren[aex.number] = fitnessMasterPosition[j];
                        aex.number = k;
                        fitnessMasterPosition[j] = tempFit;
                        for (int l = 0; l < aex.childrenPopulation[k].Length; l++)
                        {
                            newPopulation[j][l] = aex.childrenPopulation[k][l];
                            newPopulationWeight[j][l] = aex.childrenPopulationWeight[k][l];
                        }
                        fc.fitness[k] = 3000;
                    }
                }
            }

            for (int i = 0; i < pg.Populacja.Length; i++)
            {
                for (int j = 0; j < pg.Populacja[i].Length; j++)
                {
                    pg.Populacja[i][j] = newPopulation[i][j];
                    pg.PopulacjaForWeight[i][j] = newPopulationWeight[i][j];
                }
            }
            t++;
        }
    }
}