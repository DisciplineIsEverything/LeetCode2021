using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    class MultiplyString
    {
        // Coding Time: 100 minutes for Multiple
        // Coding Time: 20 minutes for Multiple2
        // https://leetcode.com/problems/multiply-strings/submissions/

        public void Test()
        {
            Console.WriteLine("123456".Substring(0, 3));
            Console.WriteLine(string.Concat("123", "456"));
            Console.WriteLine("================================================");
            Console.WriteLine(Add("0", "100"));
            Console.WriteLine(Add("789", "123"));
            Console.WriteLine(Add("9", "19"));
            Console.WriteLine(Add("99999", "2"));
            Console.WriteLine(Add("99999", "99999"));
            Console.WriteLine(Add("99999", "13"));
            Console.WriteLine("================================================");
            Console.WriteLine(new string('0', 0));
            Console.WriteLine(string.Concat("123", new string('0', 0)));
            Console.WriteLine(string.Concat("123", new string('0', 4)));
            Console.WriteLine("================================================");
            Console.WriteLine(Multiple("0", "0"));
            Console.WriteLine(Multiple2("0", "0"));
            Console.WriteLine(123 * 456);
            Console.WriteLine(Multiple2("123", "456"));

            Console.WriteLine(Multiple("999", "999"));
            Console.WriteLine(Multiple2("999", "999"));
            Console.WriteLine(99999 * 13);
            Console.WriteLine(Multiple("99999", "13"));
            Console.WriteLine(Multiple2("99999", "13"));
            Console.WriteLine(Multiple("99999", "10"));
            Console.WriteLine(Multiple2("99999", "10"));
            Console.WriteLine(Multiple("99999", "1"));
            Console.WriteLine(Multiple2("99999", "1"));
            Console.WriteLine(Multiple("99999", "9"));
            Console.WriteLine(Multiple2("99999", "9"));
        }
        public string Multiple2(string num1, string num2)
        {
            int length1 = num1.Length;
            int length2 = num2.Length;
            int[] arr = new int[length1 + length2];

            for (int i = 0; i <= length2 - 1; i++)
            {
                int numPosition2 = num2.Length - 1 - i;
                int fact2 = Char2Int(num2[numPosition2]);
                for (int j = 0; j <= length1 - 1; j++)
                {
                    int numPosition1 = num1.Length - 1 - j;
                    int fact1 = Char2Int(num1[numPosition1]);
                    arr[i + j] += fact1 * fact2;
                }
            }

            int carry = 0;
            for (int i = 0; i <= arr.Length - 1; i++)
            {
                int temp = carry + arr[i];
                carry = temp / 10;
                arr[i] = temp % 10;
            }

            StringBuilder sb = new StringBuilder();
            bool checkLeadingZero = true;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (checkLeadingZero && i != 0)
                {
                    if (arr[i] == 0)
                    {
                        continue;
                    }
                    else
                    {
                        checkLeadingZero = false;
                    }
                }
                sb.Append(arr[i].ToString());

                int temp = carry + arr[i];
                temp %= 10;
                carry = temp / 10;
            }


            return sb.ToString();

        }

        public string Multiple(string num1, string num2)
        {
            StringBuilder sb = new StringBuilder();
            int len1 = num1.Length;
            int len2 = num2.Length;
            if (len1 == 0)
            {
                return num2;
            }
            else if (len2 == 0)
            {
                return num1;
            }
            string core;
            string loop;
            if (len1 > len2)
            {
                core = num1;
                loop = num2;
            }
            else
            {
                core = num2;
                loop = num1;
            }
            string finalResult = "0";
            for (int i = 0; i <= loop.Length - 1; i++)
            {
                int numPosition1 = loop.Length - 1 - i;
                int currentLevel = Char2Int(loop[numPosition1]);
                string currentResult = "0";
                for (int j = 0; j <= currentLevel - 1; j++)
                {
                    currentResult = Add(currentResult, core);
                }

                currentResult = string.Concat(currentResult, new string('0', i));

                finalResult = Add(finalResult, currentResult);
            }

            return finalResult;
        }

        private string Add(string num1, string num2)
        {
            StringBuilder sb = new StringBuilder();
            int len1 = num1.Length;
            int len2 = num2.Length;

            if (len1 == 0)
            {
                return num2;
            }
            else if (len2 == 0)
            {
                return num1;
            }
            string longerPart = "";
            int loopLength;
            if (len1 == len2)
            {
                longerPart = "";
                loopLength = len1;
            }
            else if (len1 > len2)
            {
                longerPart = num1.Substring(0, len1 - len2);
                loopLength = len2;
            }
            else
            {
                longerPart = num2.Substring(0, len2 - len1);
                loopLength = len1;
            }

            int carryOver = 0;
            for (int i = 0; i <= loopLength - 1; i++)
            {
                int numPosition1 = num1.Length - 1 - i;
                int numPosition2 = num2.Length - 1 - i;
                int temp1 = Char2Int(num1[numPosition1]) + Char2Int(num2[numPosition2]) + carryOver;
                sb.Append((temp1 % 10).ToString());
                if (temp1 > 9)
                {
                    carryOver = 1;
                }
                else
                {
                    carryOver = 0;
                }
            }
            if (carryOver == 1)
            {
                longerPart = AddOne(longerPart);
            }
            return string.Concat(longerPart, new string(sb.ToString().Reverse().ToArray()));
        }

        private string AddOne(string num1)
        {
            if (string.IsNullOrEmpty(num1))
            {
                return "1";
            }
            int carryOver = 0;
            StringBuilder s1 = new StringBuilder();
            int i = 0;
            for (; i <= num1.Length - 1; i++)
            {
                int TempI = num1.Length - 1 - i;
                int temp1 = Char2Int(num1[TempI]) + carryOver;
                if (i == 0)
                {
                    temp1++;
                }
                s1.Append((temp1 % 10).ToString());
                if (temp1 > 9)
                {
                    carryOver = 1;
                }
                else
                {
                    carryOver = 0;
                }
            }
            if (carryOver == 1)
            {
                s1.Append("1");
            }
            return new string(s1.ToString().Reverse().ToArray());

        }


        private int Char2Int(char c1)
        {
            return Convert.ToInt32(c1.ToString());
        }

    }
}
