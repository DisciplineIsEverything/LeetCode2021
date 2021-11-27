using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    class LongestCommonString
    {
        public void Test()
        {
            Console.WriteLine(Solusion(new string[] { "abc", "abc" }));
            Console.WriteLine(Solusion(new string[] { "abcasdfqwertfq2  rwer" }));

            Console.WriteLine(Solusion(new string[] { "absasdfwefec", "absdfasdfc" }));
            Console.WriteLine(Solusion(new string[] { "absasdfwefec", "absdfasdfc", "ab" }));
            Console.WriteLine(Solusion(new string[] { "absasdfwefec", "absdfasdfc", "c" }));
        }

        // Coding time: 14'27''
        public string Solusion(string[] strs)
        {
            string result = "";
            if (strs.Length == 1)
            {
                result = strs[0];
            }

            bool done = false;
            int resultLen = 0;
            for (int i = 0; i <= strs[0].Length - 1; i++)
            {
                char temp = strs[0][i];
                for (int j = 1; j <= strs.Length - 1; j++)
                {
                    string cur = strs[j];

                    if (i >= cur.Length || temp != cur[i])
                    {
                        done = true;
                        break;
                    }
                }

                if (done)
                {
                    break;
                }
                else
                {
                    resultLen = i + 1;
                }
            }

            result = strs[0].Substring(0, resultLen);
            return result;
        }



        // Multiple dimentional array
        // string copy

    }
}
