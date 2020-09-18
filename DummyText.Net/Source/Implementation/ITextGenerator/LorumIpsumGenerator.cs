using System;
using System.Collections.Generic;
using System.Text;

namespace DummyText
{
    /// <summary>
    /// A <see cref="ITextGenerator"/> that generates lorum-ipsum-like text.
    /// </summary>
    public class LorumIpsumGenerator : GiberishGenerator
    {

        private const string wordsResourceName = "LorumIpsum-words-utf8";              

        public LorumIpsumGenerator()
            : base()
        {
            Utils.EmbeddedResourceLoader loader = new Utils.EmbeddedResourceLoader(
                        typeof(LorumIpsumGenerator).Assembly,
                        "DummyText.Resources.");
            WordList = loader.GetResourceString(wordsResourceName).Split(',');
        } 
    }
}
