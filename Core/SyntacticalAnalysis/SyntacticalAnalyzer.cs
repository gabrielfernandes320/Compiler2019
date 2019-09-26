using Core.Enum;
using Core.SyntacticalAnalysis;
using System;
using System.Collections.Generic;

namespace Core.SyntacticalAnalyzer
{
    public class SyntacticalAnalyzer
    {
        private readonly IDictionary<NonTerminalEnum, IDictionary<System.Enum, IList<System.Enum>>> parsingMatrix;

        public SyntacticalAnalyzer(IList<Token> tokens)
        {
            parsingMatrix = ParsingMatrixDictionary.Get();

            // TODO: Criar a pilha não terminais (X)
            // TODO: Apartir da lista de Tokens criar a pilha de tokens (a)
        }

        public void Start()
        {
            // TODO: A partir do não terminal 53, iniciar análise conforme algoritimo
        }
    }
}
