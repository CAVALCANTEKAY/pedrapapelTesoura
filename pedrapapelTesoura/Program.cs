using System;

class Program
{
    static int rodadas;

    public static void Main(string[] args)
    {
        start();
    }
    public static void start()
    {
        DesenhaCabecalho(3);
        Console.WriteLine("digite \"1\" para começar");

        int iniciar;
        iniciar = Int32.Parse(Console.ReadLine());

        while (iniciar != 1)
        {
            DesenhaCabecalho(3);
            Console.WriteLine("opção invalida! digite 1 para começar");
            iniciar = Int32.Parse(Console.ReadLine());
        }
        DefineRodadas();
    }
    public static void DesenhaCabecalho(int linhasExtras)
    {
        Console.Clear();
        Console.WriteLine("*******************************");
        Console.WriteLine("*   pedra, papel ou tesoura   *");
        Console.WriteLine("*******************************");
        for (int i = 0; i < linhasExtras; i++)
        {
            Console.WriteLine("\n");
        }

    }

    public static void DefineRodadas()
    {
        DesenhaCabecalho(3);
        Console.WriteLine("quantas rodadas voce quer jogar? 3, 5 ou 7? ");
        rodadas = Int32.Parse(Console.ReadLine());

        while (rodadas != 3 && rodadas != 5 && rodadas != 7)
        {
            DesenhaCabecalho(3);

            Console.WriteLine("voce digitou um valor invalido! escolha entre os numeros 3,5 ou 7:");
            rodadas = Int32.Parse(Console.ReadLine());
        }

        ControlaRodadas();
    }

    public static void ControlaRodadas()
    {
        int rodadaAtual = 1;
        int pontosUsuario = 0;
        int pontosComputador = 0;
        bool fimDejogo = false;

        while (fimDejogo != true)
        {
            DesenhaCabecalho(0);
            Console.WriteLine("             rodada  " + rodadaAtual.ToString() + "/" + rodadas.ToString() + "          ");
            Console.WriteLine();
            Console.WriteLine("user: " + pontosUsuario.ToString() + " pontos  |  CPU: " + pontosComputador.ToString() + " pontos");

            switch (ExibeRodada())
            {
                case 0:
                    break;
                case 1:
                    pontosUsuario++;
                    rodadaAtual++;
                    if (pontosUsuario > rodadas / 2)
                    {
                        Console.WriteLine("usuario venceu");
                        fimDejogo = true;
                    }
                    break;
                case 2:
                    pontosComputador++;
                    rodadaAtual++;
                    if (pontosComputador > rodadas / 2)
                    {
                        Console.WriteLine("computador venceu");
                        fimDejogo = true;
                    }
                    break;
            }
            if (fimDejogo)
            {
                DesenhaCabecalho(3);
                if (pontosUsuario > pontosComputador)
                {
                    Console.WriteLine("parabens!!! voce ganhou");

                }
                else
                {
                    Console.WriteLine("nao foi dessa vez!");
                }
                Console.WriteLine("\n\n");
                Console.WriteLine("digite qualquer numero para continuar");
                Console.ReadLine();
                start();

            }
            else
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("digite 1 para continuar e 0 para sair");
                if (Int32.Parse(Console.ReadLine()) == 0)
                {

                    start();

                }
            }

        }
    }

    public static int ExibeRodada()
    {
        string escolhaDoUsuario;
        string escolhaDoPrograma;
        string[] opcoes =  {
      "PEDRA",
      "PAPEL",
      "TESOURA"
    };
        Console.WriteLine("Escolha uma das opções: Pedra, Papel ou Tesoura?");
        escolhaDoUsuario = Console.ReadLine().ToUpper();
        while (escolhaDoUsuario != "PEDRA" && escolhaDoUsuario != "PAPEL" && escolhaDoUsuario != "TESOURA")
        {
            Console.WriteLine("Você fez uma escolha inválida. Digite novamente: Pedra, Papel ou Tesoura?");
            escolhaDoUsuario = Console.ReadLine().ToUpper();
        }
        Random rand = new Random();
        int sorteio = rand.Next(opcoes.Length);
        escolhaDoPrograma = opcoes[sorteio];

        Console.WriteLine("A escolha do computador foi: " + escolhaDoPrograma);

        if (escolhaDoUsuario == escolhaDoPrograma)
        {
            Console.WriteLine("Deu empate");
            return 0;
        }
        else if (escolhaDoUsuario == "PEDRA" && escolhaDoPrograma == "TESOURA")
        {
            Console.WriteLine("Parabéns! Você ganhou!");
            return 1;
        }
        else if (escolhaDoUsuario == "TESOURA" && escolhaDoPrograma == "PAPEL")
        {
            Console.WriteLine("Parabéns! Você ganhou!");
            return 1;
        }
        else if (escolhaDoUsuario == "PAPEL" && escolhaDoPrograma == "PEDRA")
        {
            Console.WriteLine("Parabéns! Você ganhou!");
            return 1;
        }
        else
        {
            Console.WriteLine("Que pena! Quem venceu foi o computador!");
            return 2;
        }
    }

}
