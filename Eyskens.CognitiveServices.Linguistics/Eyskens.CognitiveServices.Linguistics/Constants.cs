using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eyskens.CognitiveServices.Linguistics
{
    class Constants
    {
        internal const string DefaultLanguage = "en";
        internal static string InvalidTextOrAnalyzers ="Text and Analyzers cannot be null";
        internal static string TokenAnalyzer = "08ea174b-bfdb-4e64-987e-602f85da7f72";
        internal static string TagAnalyzer = "4fa79af1-f22c-408d-98bb-b7d7aeef7f04";
        internal static string InvalidText = "Text cannot be null or empty";
        internal static string InvalidKey = "Key cannot be null or empty";
        internal static string DefaultServiceUri = "https://westus.api.cognitive.microsoft.com/linguistics/v1.0/analyze";
        internal static string TokenArrayLabel = "Tokens";
        internal static string RawTokenLabel = "RawToken";
        internal static string IntermediateNode = "result";
        internal static string AuthorizationHeader = "Ocp-Apim-Subscription-Key";
    }
    class PennTags
    {
        internal static string vb = "VB";
        internal static string vbd = "VBD";
        internal static string vbg = "VBG";
        internal static string vbn = "VBN";
        internal static string vbp = "VBP";
        internal static string vbz = "VBZ";
        internal static string nn = "NN";
        internal static string nns = "NNS";
        internal static string nnp = "NNP";
        internal static string nnps = "NNPS";
        internal static string jj = "JJ";
        internal static string jjr = "JJR";
        internal static string jjs = "JJS";
    }
}
