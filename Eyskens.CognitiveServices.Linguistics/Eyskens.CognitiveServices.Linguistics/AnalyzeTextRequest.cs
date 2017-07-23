using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eyskens.CognitiveServices.Linguistics
{
    public class AnalyzeTextRequest : AnalyzeRequest
    {
        public AnalyzeTextRequest(string text, Guid[] analyzers, string language = "en")
        {
            if (string.IsNullOrEmpty(text) || analyzers == null)
            {
                throw new ArgumentException(Constants.InvalidTextOrAnalyzers);
            }
            base.Text = text;
            base.AnalyzerIds = analyzers;
            base.Language = language;
        }

    }
}
