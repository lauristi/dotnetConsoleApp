using TesteUnidas.Business.StringShuffle;
using TesteUnidas.Business.StringShuffle.Interface;
using Moq;

namespace TestUnidasTest.Tests.Unitario
{
    [TestClass]
    public class ShuffleString_MockTest
    {
        public TestContext TestContext { get; set; }
        
        private ShuffleString _shuffleString;
        private Mock<IReverseString> _mockReverseString;

        [TestInitialize]
        public void TestInitialize()
        {
            //--------------------------------------------------------------------------------------
            // Este exemplo usa a Lib Mock para carregar as classes com inje��o de dependencia
            // E simular classes injetadas na rotina principal
            //--------------------------------------------------------------------------------------
            //Conceito:
            //  O teste unit�rio deve ter uma unica preocupa��o:
            //  O funcionamento do c�digo  isolado. No caso ShuffleString injeta uma outra
            //  classe iReverseString, que n�o � o objeto de teste em quest�o, por isso ela
            //  n�o � chamada diretamente e apenas a sua sa�da esperada � que � simulada.
            //
            //  Isso garante que a l�gica do c�digo � testada independente de outros
            //  componentes  do sistema, que por sua vez devem ter seus pr�prios testes unitarios.
            //--------------------------------------------------------------------------------------

            //Uma simula��o de iReverseString Injetada � criada
            _mockReverseString = new Mock<IReverseString>();
            _shuffleString = new ShuffleString(_mockReverseString.Object);
        }

        [TestMethod]
        [Owner("Hal")]
        [Description("Teste usando Mock")]
        public void Shuffle_WhenCalled_ReturnsExpectedString()
        {
            // Arrange
            var originalText = "HELLOWORLD";
            var expectedText = "D HEL WOL ORL";
            var chunkSize = 3;

            //O retorno esperado da Inje��o original de iReverseString � simulado aqui.
            _mockReverseString.Setup(x => x.Reverse("HEL")).Returns("LEH");
            _mockReverseString.Setup(x => x.Reverse("LOW")).Returns("WOL");
            _mockReverseString.Setup(x => x.Reverse("ORD")).Returns("DRO");
            _mockReverseString.Setup(x => x.Reverse("D")).Returns("D");

            // Act

            //A Rotina que ser� efetivamente testada � chamada aqui e utilizar� a vers�o simulada
            // de IReserveString de forma transparente
            var result = _shuffleString.Shuffle(originalText, chunkSize);

            // Assert
            Assert.AreEqual(expectedText, result);
            TestContext.WriteLine($"Input: {originalText} |  Expected: {expectedText} | Result: {result} ");
        }
    }
}