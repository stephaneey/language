using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Eyskens.CognitiveServices.Linguistics
{
    public class LinguisticsClient
    {
        string _key = null;
        Uri _serviceUrl = null;
        public LinguisticsClient(string key, Uri serviceUrl = null)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException(Constants.InvalidKey);
            _key = key;
            _serviceUrl = (serviceUrl != null) ? serviceUrl :
                new Uri(Constants.DefaultServiceUri);
        }        
        List<TokenAndTag> AnalyzeAndTokenize(string tags, JArray tokens)
        {
            List<TokenAndTag> TokensAndTags = new List<TokenAndTag>();
            foreach (string token in tokens)
            {
                var t = string.Concat(" ", token);
                var TokenPosition = tags.IndexOf(t);
                var TokenContext = tags.Substring(0, TokenPosition);
                var TagContextPosition = TokenContext.LastIndexOf("(");
                var ExtractedTag = TokenContext.Substring(TagContextPosition + 1);
                TokensAndTags.Add(new TokenAndTag
                {
                    token = token,
                    tag = ExtractedTag
                });
                tags = tags.Substring(TokenPosition + t.Length);
            }
            return TokensAndTags;
        }
        List<TokenAndTag> Tokenize(JArray tags, JArray tokens)
        {
            List<TokenAndTag> TokensAndTags = new List<TokenAndTag>();
            int i = 0;
            int j = 0;
            foreach (var line in tokens)
            {
                JArray tokensinline = JArray.Parse(line[Constants.TokenArrayLabel].ToString());
                foreach (var token in tokensinline)
                {
                    TokensAndTags.Add(new TokenAndTag
                    {
                        token = token[Constants.RawTokenLabel].ToString(),
                        tag = tags[j][i].ToString()
                    });
                    i++;
                }
                j++;
                i = 0;
            }
            return TokensAndTags;
        }
        public IEnumerable<TokenAndTag> GetVerbs(List<TokenAndTag> input)
        {
            return input.Where(
                v => v.tag.Equals(PennTags.vb) ||
                v.tag.Equals(PennTags.vbd) ||
                v.tag.Equals(PennTags.vbg) ||
                v.tag.Equals(PennTags.vbn) ||
                v.tag.Equals(PennTags.vbp) ||
                v.tag.Equals(PennTags.vbz));
        }
        public IEnumerable<TokenAndTag> GetAdjectives(List<TokenAndTag> input)
        {
            return input.Where(
                v => v.tag.Equals(PennTags.jj) ||
                v.tag.Equals(PennTags.jjr) ||               
                v.tag.Equals(PennTags.jjs));
        }
        public IEnumerable<TokenAndTag> GetNouns(List<TokenAndTag> input)
        {
            return input.Where(
                v => v.tag.Equals(PennTags.nn) ||
                v.tag.Equals(PennTags.nns) ||
                v.tag.Equals(PennTags.nnp) ||
                v.tag.Equals(PennTags.nnps));
        }
        public async Task<AnalyzeResult> AnalyzeTextAsync(AnalyzeRequest req)
        {

            HttpClient cli = new HttpClient();
            cli.DefaultRequestHeaders.Add(Constants.AuthorizationHeader, _key);
            var response = await cli.PostAsJsonAsync(_serviceUrl.AbsoluteUri, req);
            var raw = await response.Content.ReadAsStringAsync();
            JArray results = JArray.Parse(raw);
            if (req is TagTextRequest)
            {
                var result = new AnalyzeTagResult();
                result.TokensAndTags =
                    Tokenize(JArray.Parse(results[0][Constants.IntermediateNode].ToString()), JArray.Parse(results[1][Constants.IntermediateNode].ToString()));
                result.RawTokens = raw;
                return result;
            }
            else if (req is TokenTextRequest)
            {
                var result = new AnalyzeTokenResult();
                result.RawTokens = results[0][Constants.IntermediateNode].ToString();
                result.RawResults = raw;
                return result;
            }
            else
            {
                var result = new AnalyzeTextResult();
                result.RawResults = raw;
                return result;
            }
        }
    }
    
}
