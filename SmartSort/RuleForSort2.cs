using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmartSort
{
    internal class RuleForSort2 : IComparer<string>
    {
        private string order = "_a _d _i _s _n _c";
        public int Compare(string x, string y)
        {
            string[] firstPartX = x.Split('_', '.');
            string[] firstPartY = y.Split('_', '.');

            if (firstPartX[0] == firstPartY[0]) 
            {
                if (!x.Contains("lod") && y.Contains("lod"))
                {
                    return -1;
                }
                else if (x.Contains("lod") && !y.Contains("lod"))
                {
                    return 1;
                }
                else
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
                    return x.Length.CompareTo(y.Length);
                }
            }
            else 
            {
                return string.Compare(firstPartX[0], firstPartY[0], StringComparison.Ordinal);
            }
        }
    }
}
