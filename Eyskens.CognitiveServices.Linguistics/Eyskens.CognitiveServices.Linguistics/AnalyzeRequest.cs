using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eyskens.CognitiveServices.Linguistics
{
    public abstract class AnalyzeRequest
    {
        public string Text { get; set; }
        public string Language { get; set; }
        public Guid[] AnalyzerIds { get; set; }
    }
}
