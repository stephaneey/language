using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eyskens.CognitiveServices.Linguistics
{
    public class AnalyzeTokenResult : AnalyzeResult
    {
        public string RawTokens { get; internal set; }

        public AnalyzeTokenResult() { }
    }
}
