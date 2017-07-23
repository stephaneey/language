# language
This library helps consuming the Azure Cognitive Services API. Today, this API performs 3 kind of analyzis:
- Tokenization
- Tags
- Linguistic tree

However, in Today's implementation, there is no single response combining both tokens & tags together. That's why I built this library, 
to ease the tag extraction.

Examples of use:

- Clone or download this rep, or install the corresponding NuGet package Eyskens.CognitiveServices.Linguistics
- Grab a key for the linguistic API

From there on, you can call the service in three different ways:

  LinguisticsClient cli = new LinguisticsClient("<your key>");
  AnalyzeTextResult res = await cli.AnalyzeTextAsync(new AnalyzeTextRequest(
                "I live in Brussels", new Guid[] {
                  new Guid("4fa79af1-f22c-408d-98bb-b7d7aeef7f04"),
                  new Guid("22a6b758-420f-4745-8a3c-46835a67c0d2"),
                  new Guid("08ea174b-bfdb-4e64-987e-602f85da7f72")})) as AnalyzeTextResult
                 
You pass the analyzers of your choice. This call is almost similar to calling the API directly. I put it there so that you could still 
use this package should the underlying MS API's answer body change.

An alternative to get directly the extracted tokens & tags is to use this construct:

AnalyzeTagResult res = await cli.AnalyzeTextAsync(new TagTextRequest("I live in Brussels. My name is Stephane Eyskens")) 
   as AnalyzeTagResult;
//res.TokensAndTags contains a list of tokens & tags together.
//On top of it, you can start extracting verbs, nouns or adjectives directly using this kind of constructs:
 foreach (var verb in cli.GetVerbs(res.TokensAndTags))
 {
   Console.WriteLine(verb.token + ":" + verb.tag);
 }
 
 The above code allows you to easily extract the relevant information from a piece of text.
