using System;
using System.Linq;
using System.IO;

namespace MSI_AEX
{
    class Program
    {
        static void Main(string[] args)
        {
            AEXCrossing aex = new AEXCrossing();
            FitnessCalculation fc = new FitnessCalculation();
            AssignWeight aw = new AssignWeight();
            PopulationGenerating pg = new PopulationGenerating();
            ShowPopulationOnScreen spos = new ShowPopulationOnScreen();
            Selection s = new Selection();
            GenereteNewPopulation gnp = new GenereteNewPopulation();
            SaveGenerationsToTextFile save = new SaveGenerationsToTextFile();
            ChildrenFitnessCalculation cfc = new ChildrenFitnessCalculation();
            Mutation m = new Mutation();
            WritingResults wr = new WritingResults();
            
            do
            {
                do
                {
                    aw.WeightAssignment();
                    pg.GeneratePopulation();
                    save.SaveToFile();
                    fc.CalculateFitness();
                    spos.ShowOnScreen();
                    s.Selecting();
                    //aex.AEX();
                    cfc.CalculateFitnessForChildren();
                    //gnp.GenerateNewPopulation();
                } while 
                        ((fc.HistroyOfFit[gnp.t - 1] < fc.HistroyOfFit[gnp.t - 2]) || 
                        (fc.HistroyOfFit[gnp.t - 2] < fc.HistroyOfFit[gnp.t - 3]) || 
                        (fc.HistroyOfFit[gnp.t - 3] < fc.HistroyOfFit[gnp.t - 4]));
                m.Mutate();
            } while 
                    (fc.HistroyOfFit[gnp.t - 1] < fc.HistroyOfFit[gnp.t - 2] ||
                    fc.HistroyOfFit[gnp.t - 2] < fc.HistroyOfFit[gnp.t - 3] ||
                    fc.HistroyOfFit[gnp.t - 3] < fc.HistroyOfFit[gnp.t - 4] ||
                    fc.HistroyOfFit[gnp.t - 4] < fc.HistroyOfFit[gnp.t - 5]);
            fc.CalculateFitness();
            wr.WriteResults();

        }
    }
}