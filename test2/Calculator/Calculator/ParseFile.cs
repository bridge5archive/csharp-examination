using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Calculator
{
    public class ParseFile
    {
        public static (string ,List<string> ) Parse(string fileName)
        {
            try
            {
                string[] data = File.ReadAllLines(fileName);
                if (data == null || data.Length < 2) 
                {
                    throw new Exception($"{fileName}文件的内容格式错误！");
                }
                string expression = data[0];
                List<string> dataList = data.Skip(1).Take(data.Length-1).ToList();
                try
                {
                    dataList.Select(d => decimal.Parse(d.Split('=')[1])).ToList();
                }
                catch (Exception ex)
                { 
                    throw new Exception($"{fileName}文件的数据格式错误！\n{ex.Message}");
                }
                
                return (expression, dataList);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
