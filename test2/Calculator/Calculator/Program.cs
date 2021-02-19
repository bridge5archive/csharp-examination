using System;
using System.Collections.Generic;
using System.IO;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args == null || args.Length < 1)
                {
                    Console.WriteLine("请输入文件！");
                    Console.ReadKey();
                    return;
                }
                foreach (var fileName in args)
                {
                    if (!File.Exists(fileName))
                    {
                        Console.WriteLine("文件不存在！");
                        continue;
                    }
                    (string expression, List<string> dataList) = ParseFile.Parse(fileName);
                    Console.WriteLine(Calc.CalcData(expression, dataList));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }

        }
    }
}
