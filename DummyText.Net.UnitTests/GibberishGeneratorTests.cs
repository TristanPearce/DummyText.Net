using System;
using System.Collections.Generic;
using System.Text;

namespace DummyText.UnitTests
{
    public class GibberishGeneratorTests : TextGeneratorTestBase
    {
        public GibberishGeneratorTests() 
            : base(new GiberishGenerator(new string[] { "these", "are", "some", "example", "words" }))
        { }
    }
}
