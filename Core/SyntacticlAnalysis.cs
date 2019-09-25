using Core.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    class SyntacticlAnalysis
    {

        private int test()
        {
            ParsingTable pta = new ParsingTable();

            OperatorsDictionary operatorsDictionaty = new OperatorsDictionary();

            pta.ParsingTableDictionary.ContainsKey((1,1));
            List<string> a = new List<string>();

            Console.WriteLine(pta.ParsingTableDictionary.TryGetValue((1,1)), out a);


            return 1;
        }
            


    }
}
