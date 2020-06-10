using System;
using System.Collections.Generic;
using System.Text;

namespace MSI_AEX
{
    class Selection
    {
        public int[][] coupleOfParents = new int[100][];
        public int nrOfParent1;
        public int nrOfParent2;
        public int nrOfParent3;
        public int nrOfParent4;
        public int nrOfParent5;
        public Random rnd = new Random();

        GenereteNewPopulation gnp = new GenereteNewPopulation();
        FitnessCalculation fc = new FitnessCalculation();
        public void Selecting()
        {
            for (int i = 0; i < coupleOfParents.Length; i++)
            {
                coupleOfParents[i] = new int[2];
                for (int j = 0; j < 2; j++)
                {
                    nrOfParent1 = rnd.Next(0, 100);
                    nrOfParent2 = rnd.Next(0, 100);
                    if (gnp.t < 15) //coraz ciezej znalezc cos innego, zaczyna sie powtarzac
                    {
                        if (fc.fitness[nrOfParent1] > fc.fitness[nrOfParent2])
                            coupleOfParents[i][j] = nrOfParent2;
                        else
                            coupleOfParents[i][j] = nrOfParent1;
                    }
                    else if (gnp.t >= 15 && gnp.t < 25) //urozmaicenie
                    {
                        nrOfParent3 = rnd.Next(0, 100);
                        if (fc.fitness[nrOfParent1] > fc.fitness[nrOfParent2] && fc.fitness[nrOfParent3] > fc.fitness[nrOfParent2])
                            coupleOfParents[i][j] = nrOfParent2; //szukanie najmniejszego fitnessu
                        else if (fc.fitness[nrOfParent1] > fc.fitness[nrOfParent3] && fc.fitness[nrOfParent2] > fc.fitness[nrOfParent3])
                            coupleOfParents[i][j] = nrOfParent3;
                        else
                            coupleOfParents[i][j] = nrOfParent1;
                    }
                    else if ((gnp.t >= 25 && (gnp.t < 45))) //urozmaicenie
                    {
                        nrOfParent3 = rnd.Next(0, 100);
                        nrOfParent4 = rnd.Next(0, 100);
                        if (fc.fitness[nrOfParent1] > fc.fitness[nrOfParent2] && fc.fitness[nrOfParent3] > fc.fitness[nrOfParent2] && fc.fitness[nrOfParent4] > fc.fitness[nrOfParent2])
                            coupleOfParents[i][j] = nrOfParent2;
                        else if (fc.fitness[nrOfParent1] > fc.fitness[nrOfParent3] && fc.fitness[nrOfParent2] > fc.fitness[nrOfParent3] && fc.fitness[nrOfParent4] > fc.fitness[nrOfParent3])
                            coupleOfParents[i][j] = nrOfParent3;
                        else if (fc.fitness[nrOfParent2] > fc.fitness[nrOfParent1] && fc.fitness[nrOfParent3] > fc.fitness[nrOfParent1] && fc.fitness[nrOfParent4] > fc.fitness[nrOfParent1])
                            coupleOfParents[i][j] = nrOfParent1;
                        else
                            coupleOfParents[i][j] = nrOfParent4;
                    }
                    else if ((gnp.t >= 45))
                    {
                        nrOfParent3 = rnd.Next(0, 100);
                        nrOfParent4 = rnd.Next(0, 100);
                        nrOfParent5 = rnd.Next(0, 100);
                        if (fc.fitness[nrOfParent1] > fc.fitness[nrOfParent2] && fc.fitness[nrOfParent3] > fc.fitness[nrOfParent2] && fc.fitness[nrOfParent4] > fc.fitness[nrOfParent2] && fc.fitness[nrOfParent5] > fc.fitness[nrOfParent2])
                            coupleOfParents[i][j] = nrOfParent2;
                        else if (fc.fitness[nrOfParent1] > fc.fitness[nrOfParent3] && fc.fitness[nrOfParent2] > fc.fitness[nrOfParent3] && fc.fitness[nrOfParent4] > fc.fitness[nrOfParent3] && fc.fitness[nrOfParent5] > fc.fitness[nrOfParent3])
                            coupleOfParents[i][j] = nrOfParent3;
                        else if (fc.fitness[nrOfParent2] > fc.fitness[nrOfParent1] && fc.fitness[nrOfParent3] > fc.fitness[nrOfParent1] && fc.fitness[nrOfParent4] > fc.fitness[nrOfParent1] && fc.fitness[nrOfParent5] > fc.fitness[nrOfParent1])
                            coupleOfParents[i][j] = nrOfParent1;
                        else if (fc.fitness[nrOfParent2] > fc.fitness[nrOfParent4] && fc.fitness[nrOfParent3] > fc.fitness[nrOfParent4] && fc.fitness[nrOfParent1] > fc.fitness[nrOfParent4] && fc.fitness[nrOfParent5] > fc.fitness[nrOfParent4])
                            coupleOfParents[i][j] = nrOfParent4;
                        else
                            coupleOfParents[i][j] = nrOfParent5;
                    }
                }
            }
        }
    }
}