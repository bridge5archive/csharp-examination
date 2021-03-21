using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrixtest
{
    public class CJmatch
    {
        /// <summary>
        /// j0: 保留
        /// j1: c3 c4 c2 c1
        /// j2: c2 c3 c1 c4
        /// j3: c4 c2 c3 c1
        /// j4: c4 c3 c1 c2
        /// </summary>
        public string[][] Jobs { get; set; }

        /// <summary>
        /// c0: 保留
        /// c1: j4 j1 j2 j3
        /// c2: j1 j2 j4 j3
        /// c3: j1 j3 j4 j2
        /// c4: j1 j3 j4 j2
        /// </summary>
        public string[][] Interviewers { get; set; }

        /// <summary>
        ///    j1 j2 j3 j4
        /// c1
        /// c2
        /// c3
        /// c4
        /// </summary>
        public int[][] Points { get; set; }

        public void Init(int n)
        {
            Jobs = new string[n + 1][];
            Interviewers = new string[n + 1][];
            Points = new int[n + 1][];
        }

        public void InputJobsMatch()
        {
            for (int i = 1; i < Jobs.Length; i++)
            {
                do
                {
                    try
                    {
                        Console.Write($"j{i}: ");
                        var str = Console.ReadLine();
                        Jobs[i] = str.Split(' ');
                    }
                    catch (Exception)
                    {
                        Jobs[i] = null;
                    }
                } while (Jobs[i] == null || Jobs[i].Length != Jobs.Length - 1);
            }

            Console.WriteLine(" ");

        }

        public void InputJobsMatchMOCK()
        {
            Jobs[1] = new[] { "c3", "c4", "c2", "c1" };
            Jobs[2] = new[] { "c2", "c3", "c1", "c4" };
            Jobs[3] = new[] { "c4", "c2", "c3", "c1" };
            Jobs[4] = new[] { "c4", "c3", "c1", "c2" };

        }

        public void InputInterviewsMatch()
        {
            for (int i = 1; i < Jobs.Length; i++)
            {
                do
                {
                    try
                    {
                        Console.Write($"c{i}: ");
                        var str = Console.ReadLine();
                        Interviewers[i] = str.Split(' ');
                    }
                    catch (Exception)
                    {
                        Interviewers[i] = null;
                    }
                } while (Interviewers[i] == null || Interviewers[i].Length != Interviewers.Length - 1);
            }

            Console.WriteLine(" ");

        }

        public void InputInterviewsMatchMOCK()
        {
            Interviewers[1] = new[] { "j4", "j1", "j2", "j3" };
            Interviewers[2] = new[] { "j1", "j2", "j4", "j3" };
            Interviewers[3] = new[] { "j1", "j3", "j4", "j2" };
            Interviewers[4] = new[] { "j1", "j3", "j4", "j2" };
        }

        public int[] Culc()
        {
            List<int> matchs = new List<int>(Interviewers.Length) { 0 };
            int maxPoint = Jobs.Length + Interviewers.Length;//最匹配分
            for (int interPosition = 1; interPosition < Interviewers.Length; interPosition++)
            {
                Points[interPosition] = new int[Jobs.Length];

                for (int k = 0; k < Interviewers[interPosition].Length; k++)
                {
                    var tmpJobPositioin = int.Parse(Interviewers[interPosition][k][1].ToString());
                    Points[interPosition][tmpJobPositioin] += (Interviewers[interPosition].Length - k);
                }
            }

            for (int jobPosition = 1; jobPosition < Jobs.Length; jobPosition++)
            {
                for (int k = 0; k < Jobs[jobPosition].Length; k++)
                {
                    var tmpInterPositioin = int.Parse(Jobs[jobPosition][k][1].ToString());
                    Points[tmpInterPositioin][jobPosition] += (Jobs[jobPosition].Length - k);
                }
            }

            for (int i = 1; i < Points.Length; i++)
            {
                matchs.Add(0);
                var tmpMaxpointPosition = 0;
                for (int j = tmpMaxpointPosition + 1; j < Points[i].Length; j++)
                {
                    if (Points[i][j] > Points[i][tmpMaxpointPosition])
                    {
                        //优先选择权使得maxPoint标记不再必要
                        if (matchs.IndexOf(j) < 0)
                            tmpMaxpointPosition = j;
                    }
                }
                matchs[i] = tmpMaxpointPosition;
            }

            return matchs.ToArray();
        }
    }
}
