using TesteUnidas.Business.StringShuffle;
using TesteUnidas.Business.StringShuffle.Interface;

namespace TestUnidasTest.Tests.Unitario
{
    [TestClass]
    public class ReverseStringTest
    {
        public TestContext TestContext { get; set; }
        
        private IReverseString _reverseString;

        [TestInitialize]
        public void TestInitialize()
        {
            _reverseString = new ReverseString();
        }

        [TestMethod]
        [Owner("Hal")]
        [Description("teste da reverse string")]
        public void Revese_String_WhenCalled_ReturnsExpectedString()
        {
            // Arrange
            var originalText = "HELLOWORLD";
            var expectedText = "DLROWOLLEH";

            // Act
            var result = _reverseString.Reverse(originalText);

            // Assert
            Assert.AreEqual(expectedText, result);
            TestContext.WriteLine($"Input: {originalText} |  Expected: {expectedText} | Result: {result} ");
        }
    }
}