using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Calculator
{
    public class Calc
    {
        public static string CalcData(string expression, List<string> dataList)
        {
            try
            {
                
                return CalcCore(expression, dataList);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        private static string CalcCore(string expression, List<string> dataList)
        {
            //string result = string.Empty;
            DataTable table = new DataTable();
            DataRow row = table.Rows.Add();
            try
            {
                foreach (var data in dataList)
                {
                    string[] kv = data.Split('=');
                    string key = kv[0];
                    decimal value = decimal.Parse(kv[1]);
                    table.Columns.Add(key, typeof(decimal));
                    row[key] = value;

                }
                table.Columns.Add(expression, typeof(decimal));
                table.Columns[expression].Expression = expression;
                table.BeginLoadData();
                table.EndLoadData();

                //for (int i = 0; i < table.Columns.Count; i++)
                //{
                //    result += table.Columns[i].ColumnName + "\t";
                //}
                //result += "\n";
                //for (int i = 0; i < table.Columns.Count; i++)
                //{
                //    result += row[i].ToString() + "\t";
                //}

                return row[expression].ToString(); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
