using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Helper : ConnectionManager
    {
        public int AmountOfColumns()
        {
            Console.WriteLine("How many columns you want to select?");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");

            return n;
        }

        public List<string> NamesOfColumns(int n)
        {
            List<string> columns = new List<string>();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Name of column " + (i + 1).ToString() + ": ");
                string snew = Console.ReadLine();
                columns.Add(snew.ToUpper());
            }

            return columns;
        }

        public string StringFromList(int n, List<string> columns)
        {
            string col = columns[0];
            for (int i = 1; i < n; i++)
            {
                col += "," + columns[i];
            }

            return col;
        }

        public static string ToMyString(string s)
        {
            return s.Replace(',', '.');
        }
    }
}
