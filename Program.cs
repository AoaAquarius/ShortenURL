using ShortenUrl.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ShortenUrl
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataAccess dataAccess = new DataAccess();
            int[] retryCounts = new int[100];
            for (int i = 0; i < 10000000; i++)
            {
                int tryC = 0;
                while (!dataAccess.Save(RandomShortURL(), "asdhadhsdhaskdhsakj"))
                {
                    tryC++;
                }
                retryCounts[tryC]++;
            }
            for (int i = 0; i < retryCounts.Length; i++)
            {
                Console.WriteLine($"Retry {i}: {retryCounts[i]}");
            }
        }

        private static string RandomShortURL()
        {
            StringBuilder stringBuilder = new StringBuilder();
            string s = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] chars = s.ToCharArray();
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                int index = random.Next(0, 62);
                stringBuilder.Append(chars[index]);
            }
            return stringBuilder.ToString();
        }

        private static string Basic62ShortURL(string longURL, IDataAccess dataAccess)
        {
            int next = dataAccess.LastID();
            StringBuilder stringBuilder = new StringBuilder();
            string s = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] chars = s.ToCharArray();
            while (next > 0)
            {
                int cur = next % 62;
                stringBuilder.Append(chars[cur]);
                next /= 62;
            }
            while (stringBuilder.Length < 6)
            {
                stringBuilder.Append(0);
            }
            dataAccess.Save(stringBuilder.ToString(), longURL);
            return stringBuilder.ToString();
        }
    }
}
