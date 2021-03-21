using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrixtest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("which u like to test, 1 or 2?");

            if (Console.ReadLine() == "1")
            {
                test1();
            }
            else
            {
                test2();
            }

            Console.Read();
        }

        public static void test1()
        {
            Console.WriteLine("still writing");
        }

        public static void test2()
        {
            CJmatch match = new CJmatch();

            Console.WriteLine("do u wish to simulater on 4 jobs y or n?");
            var answer = Console.ReadLine();
            if (answer.ToLower() == "y")
            {
                match.Init(4);
                match.InputJobsMatchMOCK();
                match.InputInterviewsMatchMOCK();
            }
            else
            {
                Console.WriteLine("input N :");
                int count;
                do
                {
                    int.TryParse(Console.ReadLine(), out count);
                } while (count < 1);

                match.Init(count);
                match.InputJobsMatch();
                match.InputInterviewsMatch();
            }

            var matchs = match.Culc();
            for(int i = 1; i < matchs.Length; i++)
            {
                Console.WriteLine($"j{i}: c{matchs[i]}");
            }

            Console.WriteLine("end");
        }
    }
}
