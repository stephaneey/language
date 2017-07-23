using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eyskens.CognitiveServices.Linguistics
{
    public class AnalyzeTagResult : AnalyzeResult
    {
        public List<TokenAndTag> TokensAndTags
        {
            get; internal set;
        }
        public string RawTokens { get; internal set; }

        public AnalyzeTagResult() { }
    }
}
