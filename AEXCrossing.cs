using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSI_AEX
{
    public class AEXCrossing
    {
        public char[][] childrenPopulation = new char[100][];
        public double[][] childrenPopulationWeight = new double[100][];
        public string c = "";
        public string p1 = "";
        public string p2 = "";
        public int number;
        public Random rnd = new Random();

        PopulationGenerating pg = new PopulationGenerating();
        Selection s = new Selection();
        public void AEX()
        {
            for (int i = 0; i < childrenPopulation.Length; i++)
            {
                childrenPopulation[i] = new char[30];
                childrenPopulationWeight[i] = new double[30];
                childrenPopulation[i][0] = pg.Populacja[s.coupleOfParents[i][0]][0];
                childrenPopulationWeight[i][0] = pg.PopulacjaForWeight[s.coupleOfParents[i][0]][0];
                c += pg.Populacja[s.coupleOfParents[i][0]][0];
                for (int j = 0; j < 30; j++)
                {
                    p1 += pg.Populacja[s.coupleOfParents[i][0]][j];
                    p2 += pg.Populacja[s.coupleOfParents[i][1]][j];
                }
                for (int j = 1; j < childrenPopulation[i].Length; j++)
                {
                    if (j % 2 == 0)
                    {
                        number = Array.IndexOf(p2.ToArray(), childrenPopulation[i][j - 1]);
                        if (number == 29 && !c.Contains(pg.Populacja[s.coupleOfParents[i][1]][0]))
                        {
                            childrenPopulation[i][j] = pg.Populacja[s.coupleOfParents[i][1]][0];
                            childrenPopulationWeight[i][j] = pg.PopulacjaForWeight[s.coupleOfParents[i][1]][0];
                            c += childrenPopulation[i][j];
                        }
                        else if (number == 29 || c.Contains(pg.Populacja[s.coupleOfParents[i][1]][number + 1]))
                        {
                            do
                            {
                                number = rnd.Next(0, 30);
                            } while (c.Contains(pg.Populacja[s.coupleOfParents[i][1]][number]));
                            childrenPopulation[i][j] = pg.Populacja[s.coupleOfParents[i][1]][number];
                            childrenPopulationWeight[i][j] = pg.PopulacjaForWeight[s.coupleOfParents[i][1]][number];
                            c += childrenPopulation[i][j];
                        }
                        else
                        {
                            childrenPopulation[i][j] = pg.Populacja[s.coupleOfParents[i][1]][number + 1];
                            childrenPopulationWeight[i][j] = pg.PopulacjaForWeight[s.coupleOfParents[i][1]][number + 1];
                            c += childrenPopulation[i][j];
                        }
                    }
                    else if (j % 2 == 1)
                    {
                        number = Array.IndexOf(p1.ToArray(), childrenPopulation[i][j - 1]);
                        if (number == 29 && !c.Contains(pg.Populacja[s.coupleOfParents[i][0]][0]))  //0 i 1 element dziecka sa z matki???
                        {
                            childrenPopulation[i][j] = pg.Populacja[s.coupleOfParents[i][0]][0];
                            childrenPopulationWeight[i][j] = pg.PopulacjaForWeight[s.coupleOfParents[i][0]][0];
                            c += childrenPopulation[i][j];
                        }
                        else if (number == 29 || c.Contains(pg.Populacja[s.coupleOfParents[i][0]][number + 1]))
                        {
                            do
                            {
                                number = rnd.Next(0, 30);
                            } while (c.Contains(pg.Populacja[s.coupleOfParents[i][0]][number]));
                            childrenPopulation[i][j] = pg.Populacja[s.coupleOfParents[i][0]][number];
                            childrenPopulationWeight[i][j] = pg.PopulacjaForWeight[s.coupleOfParents[i][0]][number];
                            c += childrenPopulation[i][j];
                        }
                        else
                        {
                            childrenPopulation[i][j] = pg.Populacja[s.coupleOfParents[i][0]][number + 1];
                            childrenPopulationWeight[i][j] = pg.PopulacjaForWeight[s.coupleOfParents[i][0]][number + 1];
                            c += childrenPopulation[i][j];
                        }
                    }
                }
            }
        }
    }
}