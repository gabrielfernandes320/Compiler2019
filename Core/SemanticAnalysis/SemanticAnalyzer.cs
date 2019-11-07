using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.SemanticAnalysis
{
    public class SemanticAnalyzer
    {


        public List<Identifier> identifiersList = new List<Identifier>();

        public SemanticAnalyzer(){}

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

        private Identifier CreateIdentifier(Token token)
        {
            return new Identifier
            {
               // Criar logica para criar Identifier
            };
        }

        public void CheckToken(Stack<Token> tokensStack)
        {
            while (tokensStack.Count > 0)
            {
                var id = IdentifierEnum.Identifier;
                Token currentToken = tokensStack.Pop();
                Token nextToken = tokensStack.Peek();
                if (nextToken.Code == 38)
                {
                    if (currentToken.Code == 25)
                    {
                        Console.WriteLine("AQUI");
                    }
                }
               
            }
        }
    }
}
