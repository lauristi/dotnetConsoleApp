using NSubstitute;
using TesteUnidas.Business.StringShuffle;
using TesteUnidas.Business.StringShuffle.Interface;

namespace TestUnidasTest.Tests.Unitario
{
    [TestClass]
    public class ShuffleString_NSubistituteTest
    {
        public TestContext TestContext { get; set; }
        
        private IShuffleString _shuffleString;
        private IReverseString _reverseString;

        [TestInitialize]
        public void TestInitialize()
        {
            //--------------------------------------------------------------------------------------
            // Este exemplo usa a Lib NSubistitute para carregar as classes com injeção de dependencia
            // E simular classes injetadas na rotina principal
            //--------------------------------------------------------------------------------------
            //Conceito:
            //  O teste unitário deve ter uma unica preocupação:
            //  O funcionamento do código  isolado. No caso ShuffleString injeta uma outra
            //  classe iReverseString, que não é o objeto de teste em questão, por isso ela
            //  não é chamada diretamente e apenas a sua saída esperada é que é simulada.
            //
            //  Isso garante que a lógica do código é testada independente de outros
            //  componentes  do sistema, que por sua vez devem ter seus próprios testes unitarios.
            //--------------------------------------------------------------------------------------

            //Uma simulação de iReverseString Injetada é criada
            _reverseString = Substitute.For<IReverseString>();
            _shuffleString = new ShuffleString(_reverseString);
        }

        [TestMethod]
        [Owner("Hal")]
        [Description("Teste usando NSubstitute")]
        public void Shuffle_WhenCalled_ReturnsExpectedString()
        {
            // Arrange
            var originalText = "HELLOWORLD";
            var expectedText = "D HEL WOL ORL";
            var chunkSize = 3;

            //O retorno esperado da Injeção original de iReverseString é simulado aqui.
            _reverseString.Reverse(Arg.Any<string>())
                                      .Returns(x => new string(x.Arg<string>()
                                                                .Reverse()
                                                                .ToArray()));
            // Act

            //A Rotina que será efetivamente testada é chamada aqui e utilizará a versão simulada
            // de IReserveString de forma transparente
            var result = _shuffleString.Shuffle(originalText, chunkSize);

            // Assert
            Assert.AreEqual(expectedText, result);
            TestContext.WriteLine($"Input: {originalText} |  Expected: {expectedText} | Result: {result} ");
        }
    }
}