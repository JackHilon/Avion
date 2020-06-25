using System;
using System.Collections.Generic;

namespace Avion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Avion
            // https://open.kattis.com/problems/avion
            // str.Contains("ABC") == true

            int myCount = 5;

            var myBlimps = Enter5Blimps(myCount);

            var answers = BlimpsProcessing(myBlimps);

            PrintList(answers);
        }
        private static void PrintList(List<int> list)
        {
            if(list.Count==0)
                Console.WriteLine("HE GOT AWAY!");
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Console.Write($"{list[i]} ");
                }
                Console.WriteLine(" ");
            }
        }
        private static List<int> BlimpsProcessing(List<string> blimps)
        {
            var result = new List<int>();
            for (int i = 0; i < blimps.Count; i++)
            {
                if (blimps[i].Contains("FBI") == true)
                    result.Add(i + 1);
            }
            return result;
        }

        private static List<string> Enter5Blimps(int count)
        {
            var result = new List<string>();
            for (int i = 0; i < count; i++)
            {
                result.Add(EnterBlimp());
            }
            return result;
        }

        private static string EnterBlimp()
        {
            // at most 11 uppercase letters of the English alphabet, digits ‘0’ to ‘9’, or dashes ‘-’.

            string str = "";
            try
            {
                str = Console.ReadLine();
                if (BlimpConditions(str) == false)
                    throw new FormatException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterBlimp();
            }
            return str;
        }
        private static bool BlimpConditions(string blimp)
        {
            if (blimp.Length > 11)
                return false;
            char flag;
            for (int i = 0; i < blimp.Length; i++)
            {
                flag = blimp[i];
                if (char.IsUpper(flag) == false && char.IsDigit(flag) == false && flag != '-')
                    return false;
            }
            return true;
        }
    }
}
