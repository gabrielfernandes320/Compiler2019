using Core.Enums;
using Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.SemanticAnalysis
{
    public class SemanticAnalyzer
    {


        public List<Identifier> identifiersList = new List<Identifier>();

        public SemanticAnalyzer() { }

        public bool Insert(Identifier identifier)
        {
            if (Search(identifier))
            {
                return false;
            }
            identifiersList.Add(identifier);
            return true;
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

        public bool SearchWithoutLevel(Identifier identifier)
        {
            foreach (var item in identifiersList)
            {
                if (identifier.Name == item.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public void ClearByLevel(int level)
        {
            identifiersList.RemoveAll(x => x.Level == level);
        }

        public Identifier CreateIdentifier(String name, string category, string type, int level)
        {
            return new Identifier
            {
                Name = name,
                Category = category,
                Level = level,
                Type = type
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

        public void VariableDeclaration(Stack<Token> tokensStack, int currentLevel)
        {
            List<Token> tokensList = new List<Token>();
            List<Identifier> internalIdentifiersList = new List<Identifier>();

            while (tokensStack.Count > 0)
            {
                Token currentToken = tokensStack.Pop();
                if (currentToken.Code == (int)SpecialSymbolEnum.SemiColon)
                {
                    break;
                }
                tokensList.Add(currentToken);
            }

            Enum type = tokensList.Last<Token>().Type;

            foreach (var item in tokensList)
            {
                switch (item.Code)
                {
                    case 25:
                        internalIdentifiersList.Add(CreateIdentifier(item.Value, "VAR", "", currentLevel));
                        break;
                    default:
                        break;
                }
            }


            foreach (var item in internalIdentifiersList)
            {
                item.Type = type.ToString();
                if (!Insert(item))
                {
                    throw new SemanticException((1) + "Variavel declarada em duplicidade", 1);
                }
            }
        }

        public void ConstDeclaration(Stack<Token> tokensStack, int currentLevel)
        {
            List<Token> tokensList = new List<Token>();
            List<Identifier> internalIdentifiersList = new List<Identifier>();

            while (tokensStack.Count > 0)
            {
                Token currentToken = tokensStack.Pop();
                if (currentToken.Code == (int)ReservedWordEnum.Var)
                {
                    break;
                }
                tokensList.Add(currentToken);
            }

            Enum type = tokensList.Last<Token>().Type;

            foreach (var item in tokensList)
            {
                switch (item.Code)
                {
                    case 25:
                        internalIdentifiersList.Add(CreateIdentifier(item.Value, "VAR", "", currentLevel));
                        break;
                    default:
                        break;
                }
            }


            foreach (var item in internalIdentifiersList)
            {
                item.Type = type.ToString();
                if (!Insert(item))
                {
                    throw new SemanticException((1) + "Constante declarada em duplicidade", 1);
                }
            }
        }

        public void ProcedureParameterDeclaration(Stack<Token> tokensStack, int currentLevel)
        {
            List<Token> tokensList = new List<Token>();
            List<Identifier> internalIdentifiersList = new List<Identifier>();

            while (tokensStack.Count > 0)
            {
                Token currentToken = tokensStack.Pop();
                if (currentToken.Code == (int)IdentifierEnum.Identifier)
                {
                    Insert(CreateIdentifier(currentToken.Value, "PARAMETER", "INTEGER", 0));
                }
            }

        }


        public void LabelDeclaration(Stack<Token> tokensStack, int currentLevel)
        {
            List<Token> tokensList = new List<Token>();
            List<Identifier> internalIdentifiersList = new List<Identifier>();

            while (tokensStack.Count > 0)
            {
                Token currentToken = tokensStack.Pop();
                if (currentToken.Code == (int)SpecialSymbolEnum.SemiColon)
                {
                    break;
                }
                tokensList.Add(currentToken);
            }

            Enum type = tokensList.Last<Token>().Type;

            foreach (var item in tokensList)
            {
                switch (item.Code)
                {
                    case 25:
                        internalIdentifiersList.Add(CreateIdentifier(item.Value, "LABEL", "", currentLevel));
                        break;
                    default:
                        break;
                }
            }

            foreach (var item in internalIdentifiersList)
            {
                item.Type = type.ToString();
                if (!Insert(item))
                {
                    throw new SemanticException((1) + "Rotulo declarado em duplicidade", 1);
                }
            }
        }

        public void ProcedureDeclaration(Token token, int currentLevel)
        {
            if (!Insert(CreateIdentifier(token.Value, "PROCEDURE", "", 0)))
            {
                throw new SemanticException((1) + "Procedure declarada em duplicidade!", 1);
            }
           
        }
        
    }
}
