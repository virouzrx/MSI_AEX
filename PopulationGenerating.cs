﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MSI_AEX
{

    public class PopulationGenerating
    {
        public char[][] Populacja = new char[100][]; //100 losowych klawiatur
        public double[][] PopulacjaForWeight = new double[100][]; //opis wag tych 100 klawiatur
        public string alphabet = "";
        public int rndNumber;
        public char rndsign;
        public Random rnd = new Random();

        public AssignWeight aw = new AssignWeight();

        public void GeneratePopulation()
        {
            for (int i = 0, j = 0; i < Populacja.Length; i++, j = 0, alphabet = "")
            {
                Populacja[i] = new char[30]; //klawiatura
                PopulacjaForWeight[i] = new double[30];
                do
                {
                    rndNumber = rnd.Next(0, 30);
                    rndsign = aw.sign[rndNumber];
                    if (!alphabet.Contains(rndsign))
                    {
                        alphabet += rndsign;
                        Populacja[i][j] = rndsign;
                        PopulacjaForWeight[i][j] = aw.signsWeight[rndNumber];
                        j++;

                    }
                } while (alphabet.Length <= 29);
            }
        }
    }
}