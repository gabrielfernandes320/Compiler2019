using System;
using System.Collections.Generic;
using System.Text;

namespace Core.SemanticAnalysis
{
    public class SemanticAnalyzer
    {
        public List<Identifier> identifiersList = new List<Identifier>();

        public bool Insert(Identifier identifier)
        {
            if (Search(identifier))
            {               
                return false;
            }
            identifiersList.Add(identifier);
            return false;
        }

        public bool Search(Identifier identifier)
        {
            foreach (var item in identifiersList)
            {
                if (identifier.Name == item.Name)
                {
                    if (identifier.Level == item.Level)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void ClearByLevel(int level)
        {
            identifiersList.RemoveAll(x => x.Level == level);
        }
    }
}
