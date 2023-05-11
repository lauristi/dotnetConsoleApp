using TesteUnidas.Business.StringShuffle.Interface;
using System.Text;

namespace TesteUnidas.Business.StringShuffle
{
    public class ShuffleString : IShuffleString
    {
        private readonly IReverseString _reverseString;

        public ShuffleString(IReverseString reverseString)
        {
            _reverseString = reverseString;
        }

        public string Shuffle(string originalText, int chunkSize)
        {
            StringBuilder finalString = new StringBuilder();

            int mod = (originalText.Length % chunkSize);

            //Divido usando Range....
            IEnumerable<string> splited = Enumerable.Range(0, originalText.Length / chunkSize)
                                .Select(i => originalText.Substring(i * chunkSize, chunkSize));

            //Caso especial
            //Escopo:
            //  Se a divisao nao foi exata preciso pegar o resto da string
            //  O pedaco da string deve ser o inicio da string final revertida.

            if (mod > 0)
            {
                int pos = (splited.Count() * chunkSize);
                string modString = originalText.Substring(pos, originalText.Length - pos);
                //--------------------------------
                finalString.Append(_reverseString.Reverse(modString)).Append(" ");
            }

            //Faço o shuffle
            int itemCount = 0;
            foreach (var item in splited)
            {
                if (itemCount % 2 == 0)
                {
                    finalString.Append(item).Append(" ");
                }
                else
                {
                    finalString.Append(_reverseString.Reverse(item)).Append(" ");
                }
                itemCount++;
            }

            return finalString.ToString().Trim();
        }
    }
}