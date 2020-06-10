using System;
using System.Collections.Generic;
using System.Text;

namespace MSI_AEX
{
    public class Mutation
    {
        public int tempint;
        public int tempint2;
        double tempdouble;
        public int numberOfMutation;
        PopulationGenerating pg = new PopulationGenerating();
        AEXCrossing aex = new AEXCrossing();
        public void Mutate()
        {
            tempint2 = pg.rnd.Next(10, 15);
            for (int i = 0; i < tempint2; i++)
            {
                aex.number = pg.rnd.Next(0, 100);
                tempint = pg.rnd.Next(3, 8);
                for (int j = 0; j < tempint; j++)
                {
                    pg.rndNumber = pg.rnd.Next(0, 30);
                    if (pg.rndNumber < 29)
                    {
                        pg.rndsign = pg.Populacja[aex.number][pg.rndNumber + 1];
                        pg.Populacja[aex.number][pg.rndNumber + 1] = pg.Populacja[aex.number][pg.rndNumber];
                        pg.Populacja[aex.number][pg.rndNumber] = pg.rndsign;
                        tempdouble = pg.PopulacjaForWeight[aex.number][pg.rndNumber + 1];
                        pg.PopulacjaForWeight[aex.number][pg.rndNumber + 1] = pg.PopulacjaForWeight[aex.number][pg.rndNumber];
                        pg.PopulacjaForWeight[aex.number][pg.rndNumber] = tempdouble;
                    }
                    else
                    {
                        pg.rndsign = pg.Populacja[aex.number][0];
                        pg.Populacja[aex.number][0] = pg.Populacja[aex.number][pg.rndNumber];
                        pg.Populacja[aex.number][pg.rndNumber] = pg.rndsign;
                        tempdouble = pg.PopulacjaForWeight[aex.number][0];
                        pg.PopulacjaForWeight[aex.number][0] = pg.PopulacjaForWeight[aex.number][pg.rndNumber];
                        pg.PopulacjaForWeight[aex.number][pg.rndNumber] = tempdouble;
                    }
                }

            }
            numberOfMutation++;
        }
    }
}