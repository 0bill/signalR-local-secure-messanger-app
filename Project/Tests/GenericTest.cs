using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Tests
{
    public class GenericTest
    {
        public readonly ITestOutputHelper Output;

        public GenericTest(ITestOutputHelper output)
        {
            this.Output = output;
        }
    }
}
