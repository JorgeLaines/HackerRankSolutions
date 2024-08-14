namespace HackerRank.Algorithms
{
    public abstract class BaseSolution
    {
        private readonly string _problemURL;
           
        public BaseSolution(string problemURL)
        {
            _problemURL = problemURL;
        }

        public string ReturnProblemURL() => _problemURL;
    }
}
