using Microsoft.ML;

namespace RecommendationSystem
{
    internal class Program
    {
        private object mlContext;

        static void Main(string[] args)
        {
           
        }

        public void TrainModel()
        {
            var trainingDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "recommendation-ratings-train.csv");
            var testDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "recommendation-ratings-test.csv");

            IDataView trainingDataView = mlContext.Data.LoadFromTextFile<Review>(trainingDataPath, hasHeader: true, separatorChar: ',');
            IDataView testDataView = mlContext.Data.LoadFromTextFile<Review>(testDataPath, hasHeader: true, separatorChar: ',');

            return (trainingDataView, testDataView);
        }
    }
}