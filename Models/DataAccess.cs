using System;
using System.Collections.Generic;
using System.Text;

namespace ShortenUrl.Models
{
    public class DataAccess : IDataAccess
    {
        private int id = 0;
        private Dictionary<string, string> data = new Dictionary<string, string>();
        public int LastID()
        {
            id++;
            return id;
        }

        public bool Save(string key, string value)
        {
            if (data.ContainsKey(key))
            {
                Console.WriteLine($"Key:{key} already exists!");
                return false;
            }
            data.Add(key, value);
            //Console.WriteLine($"Key:{key} is saved!");
            return true;
        }
    }
}
