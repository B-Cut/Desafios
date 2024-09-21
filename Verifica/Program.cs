// Acredito que esse programa funciona melhor como uma ferramenta da CLI
// Mas pelo seu tamanho, não irei usar uma biblioteca especializada
namespace Verifica
{
    internal class Program
    {
        static string helpText = @"Usage: verifica <string 1> <string 2> ...

Essa ferramenta verifica quantos vezes o caractere 'a' aparece na string fornecida. Case insensitive";
        static void Main(string[] args)
        {
            Console.WriteLine("***** VERIFICA *****");
            if (args.Length == 0 || args[0].Equals("-h") || args[0].Equals("--help"))
            {
                Console.WriteLine(helpText);
                return;
            }

            foreach (string arg in args)
            {
                var numOfAs =
                    from c in arg
                    where (c == 'A' || c == 'a')
                    select c;

                var count = numOfAs.Count();
                if (count == 0)
                {
                    Console.WriteLine($"A string {arg} não contém a letra 'a'");
                }
                else
                {
                    Console.WriteLine($"A string {arg} contém {numOfAs.Count()} ocorrências da letra 'a'");
                }
            }

        }
    }
}

