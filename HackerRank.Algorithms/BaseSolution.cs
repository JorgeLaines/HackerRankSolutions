namespace HackerRank.Algorithms
{
    public abstract class BaseSolution
    {
        private readonly string _problemURL;

        private bool _debugMode;

        public BaseSolution(string problemURL)
        {
            _problemURL = problemURL;
            _debugMode = true;
        }

        public string ReturnProblemURL() => _problemURL;

        public bool DebugMode { get; set; }
    }
}
