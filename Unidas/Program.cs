using TesteUnidas.Business.StringShuffle;
using TesteUnidas.Business.StringShuffle.Interface;
using Microsoft.Extensions.DependencyInjection;

//------------------------------------------------------------------------------------
// ESCOPO
// RECEBA UMA STRING E UM VALOR PARA DIVIDIR ESSA STRING EM PARTES IGUAIS
// A STRING DEVE SER DIVIDIDA E REMONTADA PELA SEGUINTE REGRA:
// STRING COM DIVISAO DE PARTES EXATAS:
//        MANTER PARTES PARES E INVERTER PARTES IMPARES
// STRING COM DIVISAO DE PARTES NAO EXATAS:
//        INICIAR A STRING COM A SOBRA FINAL DA STRING INVERTIDA E SEGUIR A MESMA REGRA
//        ANTERIOR DE INVERSAO
//        COLOCAR UM ESPAÇO EM BRANCO ENTRE AS PARTES PARA FACILITAR A LEITURA DO RESULTADO FINAL
// EXEMPLO:
//      TEXT: "HELLOWORLD"
//     SPLIT: 3
//
//    RESULT: "D HEL WOL ORL"
//------------------------------------------------------------------------------------
internal class Program
{
    //Adicionando os serviço que serão injetados
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IReverseString, ReverseString>()
                .AddScoped<IShuffleString, ShuffleString>();
    }

    private static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        //var reverseService = serviceProvider.GetService<IReverse>();
        var suffleService = serviceProvider.GetService<IShuffleString>();

        Console.WriteLine("Enter text to shuffle:");
        string originalText = Console.ReadLine();

        Console.WriteLine("Enter chunk size:");
        int chunkSize = Convert.ToInt32(Console.ReadLine());

        //Se for menor ou vazio dispara uma exception
        if (string.IsNullOrEmpty(originalText) || originalText.Length < chunkSize)
        {
            Console.Error.WriteLine("String ou tamanho inválidos");
        }

        try
        {
            var result = suffleService.Shuffle(originalText, chunkSize);

            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.ToString());
        }
    }
}