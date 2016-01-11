using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTrain
{
    /// <summary>
    /// http://stackoverflow.com/a/15048737/1378356
    /// </summary>
    internal class CombinationBuiler
    {
        internal class Combination
        {
            internal int Num;
            internal IEnumerable<Combination> Combinations;
        }

        internal static IEnumerable<Combination> GetCombinationTrees(int num, int max)
        {
            return Enumerable.Range(1, num)
                             .Where(n => n <= max)
                             .Select(n =>
                                 new Combination
                                 {
                                     Num = n,
                                     Combinations = GetCombinationTrees(num - n, n)
                                 });
        }

        internal static IEnumerable<IEnumerable<int>> BuildCombinations(IEnumerable<Combination> combinations)
        {
            if (combinations.Count() == 0)
            {
                return new[] { new int[0] };
            }
            else
            {
                return combinations.SelectMany(c =>
                                      BuildCombinations(c.Combinations)
                                           .Select(l => new[] { c.Num }.Concat(l))
                                    );
            }
        }

        public static IEnumerable<IEnumerable<int>> GetCombinations(int num)
        {
            var combinationsList = GetCombinationTrees(num, num);
            return BuildCombinations(combinationsList);
        }

        //public static void PrintCombinations(int num)
        //{
        //    IEnumerable<IEnumerable<int>> allCombinations = GetCombinations(num * 2);

        //    allCombinations.Where(c => c.Count() == num).ForEach(c => Console.WriteLine(string.Join(", ", c)));
        //}

    }
}