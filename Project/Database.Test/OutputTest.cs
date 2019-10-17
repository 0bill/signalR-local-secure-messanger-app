using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Database.Test
{
    public class OutputTest
    {
        public readonly ITestOutputHelper Output;

        public OutputTest(ITestOutputHelper output)
        {
            this.Output = output;
        }
    }
}
