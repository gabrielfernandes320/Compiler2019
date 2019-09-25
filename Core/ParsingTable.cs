using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class ParsingTable
    {
        public IDictionary<(int, int), string> ParsingTable = new Dictionary<(int, int), string>
        {
            { (1,1), new List<string>(){ "a","b"} },
        };

        }

}
