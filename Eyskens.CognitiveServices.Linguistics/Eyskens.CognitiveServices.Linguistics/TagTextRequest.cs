using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eyskens.CognitiveServices.Linguistics
{
    public class TagTextRequest : AnalyzeRequest
    {
        public TagTextRequest(string text, string language = "en")
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException(Constants.InvalidText);
            base.Text = text;
            base.Language = language;
            AnalyzerIds = new Guid[] {
                new Guid(Constants.TagAnalyzer),
                new Guid(Constants.TokenAnalyzer) };
        }
    }
}
