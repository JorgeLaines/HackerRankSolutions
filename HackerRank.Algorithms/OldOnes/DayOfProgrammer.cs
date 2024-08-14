using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms.OldOnes
{
    public class DayOfProgrammer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <seealso cref="https://www.hackerrank.com/challenges/day-of-the-programmer/problem"/>
        public static string DayOfProgrammer_v1(int year)
        {
            if (year < 1700 && year > 2700) throw new ArgumentException("year parameter must be a value between 1700 and 2700");
            var dayOfProgrammer = new DateTime(year, 1, 1).AddDays(255);
            if (year == 1918) dayOfProgrammer = dayOfProgrammer.AddDays(13);
            if (year < 1918 && year % 100 == 0) dayOfProgrammer = dayOfProgrammer.AddDays(-1);
            return dayOfProgrammer.ToString("dd.MM.yyyy");
        }
    }
}
