using System;
using System.Collections.Generic;
using System.Text;

namespace DummyText.UnitTests
{
    public class LorumIpsumGeneratorTests : TextGeneratorTestBase
    {
        public LorumIpsumGeneratorTests() :
            base(new LorumIpsumGenerator())
        { }
    }
}
