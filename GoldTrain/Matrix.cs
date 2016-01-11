using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTrain
{
    internal class Matrix
    {
        /// <summary>
        /// sequence of sequence of integers--this is the actual matrix.
        /// </summary>
        private IEnumerable<IEnumerable<int>> A { get; set; }

        /// <summary>
        /// This is the number passed in in the beginning
        /// </summary>
        private int N { get; set; } //t

        /// <summary>
        /// List of Ei values, correspoining to the rows in A.
        /// </summary>
        private List<double> Ei { get; set; }

        /// <summary>
        /// This is the constructor, and called when a new instance of Matrix is instanciated.
        /// </summary>
        /// <param name="n"></param>
        public Matrix(int n)
        {
            this.N = n;

            int marbles = n * 2;
            //Populate A:
            A = CombinationBuiler.GetCombinations(marbles).Where(c => c.Count() == n);

            //Populate Ei:
            Ei = new List<double>();
            A.ForEach(row =>
            {
                Ei.Add(
                    row.Select(col => Math.Pow(col, 2))
                    .Sum() / marbles);
            });

        }

        //private List<int> GetNewList(int count)
        //{
        //    return Enumerable.Repeat(1, count).ToList();            
        //}


        /// <summary>
        /// Defines the string implementation of an instance of this class.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            string space = "\t";    // |
            sb.AppendLine($"N={N}, R={A.ToList().Count}, E={Ei.Average()}");
            //sb.AppendLine($"col\t|{string.Join("\t|", Enumerable.Range(1, N))}");
            //A.ForEach((a, i) => sb.AppendLine($"{i}\t|{string.Join("\t|", a)}"));
            string OneThruN = string.Join(space, Enumerable.Range(1, N));
            sb.AppendLine($"col{space}{OneThruN}{space}Ei");
            A.ForEach((a, i) => sb.AppendLine($"{i + 1}{space}{string.Join("\t", a)}{space}{Ei[i]}"));
            //sb.AppendLine();

            return sb.ToString();
        }

    }
}