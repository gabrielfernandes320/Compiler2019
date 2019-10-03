using System.Collections.Generic;

namespace Core.SyntacticalAnalysis
{
    public class SyntacticalAnalysisProcessing
    {
        public Stack<DerivedItem> ExpansionStack { get; set; }

        public Token RemovedToken { get; set; }

        public int LineNumber { get; set; }
    }
}
