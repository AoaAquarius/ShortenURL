using System;
using System.Collections.Generic;
using System.Text;

namespace ShortenUrl.Models
{
    public interface IDataAccess
    {
        int LastID();
        bool Save(string key, string value);
    }
}
