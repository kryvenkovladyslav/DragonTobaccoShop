namespace MatrixFactorizationTrainer
{
    internal class Options
    {
        public string MatrixColumnIndexColumnName { get; set; }
        public string MatrixRowIndexColumnName { get; set; }
        public string LabelColumnName { get; set; }
        public int NumberOfIterations { get; set; }
        public int ApproximationRank { get; set; }
    }
}