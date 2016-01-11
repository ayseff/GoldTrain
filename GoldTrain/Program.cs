using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTrain
{
    class Program
    {

        /// <summary>
        /// Entry point into the application.  Command line arguments are passed in as a ar array of strings called args
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //CombinationBuiler.PrintCombinations(10);

            //Console.ReadLine();
            //return;

            //
            int start, count;
            string saveTo;

            //attempt the following block of code
            try
            {
                start = Convert.ToInt32(args[0]);   //first arg
                count = Convert.ToInt32(args[1]);   //second arg
                saveTo = args[2];
            }
            //catch the IndexOutOfRangeException exception (an exception is an error).  All other exceptions are ignored.
            //This exception is caused when there is no args[0] or 1, because no arguments were passed.  In that case, prompt the user for the values.
            catch (IndexOutOfRangeException ex) 
            {
                Console.Write("Start: ");
                start = Convert.ToInt32(Console.ReadLine());    //Read the users input and convert to integer
                Console.Write("Count: ");
                count = Convert.ToInt32(Console.ReadLine());
                Console.Write("Save To Folder: ");
                saveTo = Console.ReadLine();
            }
            

            var sb = new StringBuilder();  //StringBuilder is an optimized way of creating large strings in memory or strings that will keep changing

            Enumerable.Range(start, count)  //create a sequence of consecutive integers starting with start and going through start + count
                .Select(x => new Matrix(x)) //for each value, create a matrix, passing in the integral value
                .ToList()
                .ForEach(x => sb.AppendLine(x.ToString()));  //for each Matrix, convert it to its string form (see the ToString method for more details) and append it to sb


            File.WriteAllText(Path.Combine(saveTo, "1.txt"), sb.ToString());  //use the folder requested and create/overwite 1.txt with sb and save to disk.

            Console.WriteLine("Done.");
            Console.WriteLine("");
            Console.WriteLine("Press any key to exit...");
            Console.Read();     //wait for user to hit any key.
        }
    }
}
