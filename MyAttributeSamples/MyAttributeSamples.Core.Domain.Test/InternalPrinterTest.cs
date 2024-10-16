using MyAttributeSamples.Domain;
using Xunit;

namespace MyAttributeSamples.Core.Domain.Test
{
    public class InternalPrinterTest
    {
        [Fact]
        public void TestPrint()
        {
            InternalPrinter internalPrinter = new InternalPrinter();
        }
    }
}