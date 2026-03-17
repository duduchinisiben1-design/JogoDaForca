using System.Reflection.Metadata;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Bem-Vindo ao Jogo Da Forca");
            Console.WriteLine("---------------------------");

            string? palavraAleatória = EscolherPalavraAlatoria();

            Console.WriteLine(palavraAleatória);

            char[] letrasAcertadas = new char[palavraAleatória.Length];

            for (int caractere = 0; caractere < letrasAcertadas.Length; caractere++)
            {
                letrasAcertadas[caractere] = '_';
            }

            bool jogadorAcertouPalavra = false;
            bool jogadorPerdeu = false;

            int quantidadeErros = 0;

            while (!jogadorAcertouPalavra && !jogadorPerdeu)
            {
                Console.WriteLine("Letras Acertadas: " + string.Join("", letrasAcertadas));
                Console.WriteLine("Erros Cometidos: " + quantidadeErros);

                Console.WriteLine("Digite uma letra: ");
                string? strLetra = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(strLetra))
                {
                    Console.WriteLine("Digite um caractér válido.");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Clique ENTER para prosseguir");
                    Console.ReadLine();
                    continue;
                }

                char letraChute = char.ToUpper(Convert.ToChar(strLetra));

                bool letraEncontrada = false;

                for (int contador = 0; contador < palavraAleatória.Length; contador++)
                {
                    char letraAtual = palavraAleatória[contador];

                    if (letraChute == letraAtual)
                    {
                        letrasAcertadas[contador] = letraAtual;
                        letraEncontrada = true;
                    }
                   
                }

                if (letraEncontrada == false)
                {
                    quantidadeErros++;
                }

                if (jogadorAcertouPalavra)
                {
            
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Você acertou, parabéns você fez o mínimo.");
            Console.WriteLine("---------------------------");
                } else if (jogadorPerdeu)
                {
                
            Console.WriteLine("---------------------------");
            Console.WriteLine("Não consegue nem fazer o mínimo, não acertou...");
            Console.WriteLine("---------------------------");
                }

                jogadorAcertouPalavra = palavraAleatória == string.Join("", letrasAcertadas);

                jogadorPerdeu = quantidadeErros > 5;

            }

            Console.WriteLine("Deseja continuar o jogo? S para continuar e N para sair");
            string? opcaoDeSaida = Console.ReadLine()?.ToUpper();

            if (opcaoDeSaida != "S")
            {
                Console.WriteLine("Você finalizou seu programa, tenha um bom dia!!");
                break;
            }
        }

        static string EscolherPalavraAlatoria()
        {

            Console.WriteLine("Escolhendo palavra...");
            string[] palavras = [
            "ABACATE",
            "ABACAXI",
            "ACEROLA",
            "AÇAÍ",
            "ARAÇÁ",
            "ABACATE",
            "BACABA",
            "BACURI",
            "BANANA",
            "CAJÁ",
            "CAJU",
            "CARAMBOLA",
            "CUPUAÇU",
            "GRAVIOLA",
            "GOIABA",
            "JABUTICABA",
            "JENIPAPO",
            "MAÇÃ",
            "MANGABA",
            "MANGA",
            "MARACUJÁ",
            "MURICI",
            "PEQUI",
            "PITANGA",
            "PITAYA",
            "SAPOTI",
            "TANGERINA",
            "UMBU",
            "UVA",
            "UVAIA"
    ];

            int indiceAleatorio = RandomNumberGenerator.GetInt32(palavras.Length);


            string palavraAleatoria = palavras[indiceAleatorio];
            return palavraAleatoria;
        }

    }
}