using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    class IsomorphicStrings
    {

        public void Test()
        {
            Console.WriteLine(Solutions("add", "eag"));
            Console.WriteLine(Solutions("badc", "baba"));
            Console.WriteLine(MapFromOnetoTwo("badc", "baba"));
        }

        //https://leetcode.com/problems/isomorphic-strings/
        public bool Solutions(string s, string t)
        {

            return MapFromOnetoTwo(s, t) && MapFromOnetoTwo(t, s);
        }

        private bool MapFromOnetoTwo(string s, string t)
        {
            Dictionary<char, char> map1 = new Dictionary<char, char>();
            // constrain s.length == t.length
            for (int i = 0; i <= s.Length - 1; i++)
            {
                char sChar = s[i];
                char tChar = t[i];
                if (map1.ContainsKey(sChar))
                {
                    if (tChar != map1[sChar])
                    {
                        return false;
                    }
                }
                else
                {
                    map1.Add(sChar, tChar);
                }
            }

            return true;
        }
    }
}
