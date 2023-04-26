// https://www.hackerrank.com/challenges/counting-valleys/problem

namespace HackerRank.Algorithms
{
    public static  class Hikes
    {
        public static int CountingValleys(int steps, string path)
        {
            // meters above sea level
            var masl = 0;
            var valleys = 0;
            var valley = false;
            for (int step = 0; step < steps; step++)
            {
                masl += path[step] == 'U' ? 1 : -1;
                if(valley && masl == 0) 
                { 
                    // If we were in a valley and we reach sea level, we have exited the valley
                    valleys++; 
                    valley = false;
                } 
                else if (masl < 0)
                {
                    // If we under sea level, we have entered a valley
                    valley = true;
                }
            }
            return valleys;
        }
    }
}
