using System.Security.Cryptography;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Exibircabecalho();

            string? palavraAleatoria = EscolherPalavraAlatoria();

            char[] letrasAcertadas = PreencherLetrasAcertadas(palavraAleatoria);

            ExecutarTenativas(letrasAcertadas, palavraAleatoria);

            Saida();

            
        }

        static string EscolherPalavraAlatoria()
        {

            
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

    static void Exibircabecalho()
    {
        Console.Clear();
        Console.WriteLine("---------------------------");
        Console.WriteLine("Bem-Vindo ao Jogo Da Forca");
        Console.WriteLine("---------------------------");
    }

    static char[] PreencherLetrasAcertadas(string palavraAleatoria)
    {
        char[] letrasAcertadas = new char[palavraAleatoria.Length];

        for (int caractere = 0; caractere < letrasAcertadas.Length; caractere++)
        {
            letrasAcertadas[caractere] = '_';
        }

        return letrasAcertadas;
    }

    static void ExecutarTenativas(char[] letrasAcertadas, string palavraAleatoria)
    {

        bool jogadorAcertouPalavra = false;
        bool jogadorPerdeu = false;

        int quantidadeErros = 0;

        while (!jogadorAcertouPalavra && !jogadorPerdeu)
        {
            Desenhar(quantidadeErros);

            Console.WriteLine("Letras Acertadas: " + string.Join("", letrasAcertadas));
            Console.WriteLine("Erros Cometidos: " + quantidadeErros);

            Console.WriteLine("\nDigite uma letra: ");
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

            for (int contador = 0; contador < palavraAleatoria.Length; contador++)
            {
                char letraAtual = palavraAleatoria[contador];

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

            jogadorAcertouPalavra = palavraAleatoria == string.Join("", letrasAcertadas);

            jogadorPerdeu = quantidadeErros > 5;

            if (jogadorAcertouPalavra)
            {

                Console.WriteLine("---------------------------");
                Console.WriteLine($"Você acertou, parabéns você fez o mínimo, a palavra era {palavraAleatoria}");
                Console.WriteLine("---------------------------");
            }
            else if (jogadorPerdeu)
            {

                Console.WriteLine("---------------------------");
                Console.WriteLine("Não consegue nem fazer o mínimo, não acertou...");
                Console.WriteLine("---------------------------");
            }

            Console.ReadLine();

        }
    }

    static void Desenhar(int quantidadeErros)
    {
        if (quantidadeErros == 0)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (quantidadeErros == 1)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (quantidadeErros == 2)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |         |        ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (quantidadeErros == 3)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |        /|        ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (quantidadeErros == 4)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |        /|\       ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (quantidadeErros == 5)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |        /|\       ");
            Console.WriteLine(@" |         |        ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (quantidadeErros == 6)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |        /|\       ");
            Console.WriteLine(@" |         |        ");
            Console.WriteLine(@" |        / \       ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }

    }

    static bool Saida()
    {
        Console.WriteLine("Deseja continuar o jogo? S para continuar e N para sair");
        string? opcaoDeSaida = Console.ReadLine()?.ToUpper();

        if (opcaoDeSaida != "S")
        {
            Console.WriteLine("Você finalizou seu programa, tenha um bom dia!!");
            return false;
        }
        return true;
    }
}