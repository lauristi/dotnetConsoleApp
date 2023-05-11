using TesteUnidas.Business.StringShuffle;
using TesteUnidas.Business.StringShuffle.Interface;

namespace TestUnidasTest.Tests.Integrado
{
    [TestClass]
    public class ShuffleString_IntegratedTest
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        [Owner("Hal")]
        [TestCategory("Teste integrado")]
        public void TestInitialize()
        {
            //Nothing todo here at this time.
        }

        [TestMethod]
        [Owner("Hal")]
        [Description("teste da reverse string")]
        public void ShuffleString_WhenCalled_ReturnsExpectedString()
        {
            // Arrange
            string originalText = "HELLOWORLD";
            var expectedText = "D HEL WOL ORL";
            int chunkSize = 3;

            // Act

            //Crio instancias fortemente acopladas, nesse caso para o teste é indiferente. 
            var reverseString = new ReverseString();
            var shuffleString = new ShuffleString(reverseString);

            string result = shuffleString.Shuffle(originalText, chunkSize);

            // Assert
            Assert.AreEqual(expectedText, result);
            TestContext.WriteLine($"Input:{originalText} |  Expected: {expectedText} | Result: {result} ");
        }
    }
}