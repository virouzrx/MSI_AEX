﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MSI_AEX
{
    class ChildrenFitnessCalculation
    {
        public double[] fitnessChildren = new double[100];
        public double massiveFitChild = 0;
        PopulationGenerating pg = new PopulationGenerating();
        KeysWeight kw = new KeysWeight();
        AEXCrossing aex = new AEXCrossing();

        /* for (int i = 0; i<Populacja.Length; i++)
                     {
                         fitnessChildren[i] = 5 * childrePopulationWeight[i][5] + 5 * childrePopulationWeight[i][24] +
                         4 * childrePopulationWeight[i][0] + 4 * childrePopulationWeight[i][4] + 4 * childrePopulationWeight[i][9] + 4 * childrePopulationWeight[i][20] + 4 * childrePopulationWeight[i][21] + 4 * childrePopulationWeight[i][28] + 4 * childrePopulationWeight[i][29]
                         + 3 * childrePopulationWeight[i][3] + 3 * childrePopulationWeight[i][6] + 3 * childrePopulationWeight[i][14] + 3 * childrePopulationWeight[i][15] + 3 * childrePopulationWeight[i][22] + 3 * childrePopulationWeight[i][25] + 3 * childrePopulationWeight[i][27]
                         + 2 * childrePopulationWeight[i][1] + 2 * childrePopulationWeight[i][2] + 2 * childrePopulationWeight[i][7] + 2 * childrePopulationWeight[i][8] + 2 * childrePopulationWeight[i][23] + 2 * childrePopulationWeight[i][26]
                         + 1.5 * childrePopulationWeight[i][10] + 1.5 * childrePopulationWeight[i][19]
                         + childrePopulationWeight[i][11] + childrePopulationWeight[i][12] + childrePopulationWeight[i][13] + childrePopulationWeight[i][16] + childrePopulationWeight[i][17] + childrePopulationWeight[i][18];
                         massiveFitChild += fitnessChildren[i];
                     }
         */
        public void CalculateFitnessForChildren()
        {
            for (int i = 0; i < aex.childrenPopulationWeight.Length; i++)
            {
                for (int j = 0; j < kw.keyWeight.Length; j++)
                {
                    fitnessChildren[i] = aex.childrenPopulationWeight[i][j] * kw.keyWeight[j];
                }
                massiveFitChild += fitnessChildren[i];

            }
        }
    }
}
