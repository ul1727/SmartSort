using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SmartSort
{
    internal class RuleForSort1 : IComparer<string>
    {
        private string order = "_a_d_i_s_n_c";
        public int Compare(string x, string y)
        {
            int minLength = Math.Min(x.Length, y.Length);
            for (int i = 0; i < minLength; i++)
            {
                int xIndex = order.IndexOf(x[i]);
                int yIndex = order.IndexOf(y[i]);
                if (xIndex < yIndex)
                {
                    return -1;
                }
                else if (xIndex > yIndex)
                {
                    return 1;
                }
            }
            // если первые minLength символов равны, то сравниваем длины строк
            return x.Length.CompareTo(y.Length);
        }
    }
}

