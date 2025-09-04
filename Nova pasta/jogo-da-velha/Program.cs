using System;

class Program
{
    static char[,] tabuleiro = {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };

    static char jogadorAtual = 'X';

    static void Main()
    {
        int jogadas = 0;
        bool fim = false;

        while (!fim)
        {
            Console.Clear();
            DesenharTabuleiro();

            Console.WriteLine($"\nJogador {jogadorAtual}, escolha uma posição (1-9): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int escolha) && escolha >= 1 && escolha <= 9)
            {
                int linha = (escolha - 1) / 3;
                int coluna = (escolha - 1) % 3;

                if (tabuleiro[linha, coluna] != 'X' && tabuleiro[linha, coluna] != 'O')
                {
                    tabuleiro[linha, coluna] = jogadorAtual;
                    jogadas++;

                    if (VerificarVitoria())
                    {
                        Console.Clear();
                        DesenharTabuleiro();
                        Console.WriteLine($"\n Jogador {jogadorAtual} venceu!");
                        fim = true;
                    }
                    else if (jogadas == 9)
                    {
                        Console.Clear();
                        DesenharTabuleiro();
                        Console.WriteLine("\n Deu velha!");
                        fim = true;
                    }
                    else
                    {
                        jogadorAtual = (jogadorAtual == 'X') ? 'O' : 'X';
                    }
                }
                else
                {
                    Console.WriteLine("\nPosição já ocupada! Aperte ENTER para tentar novamente...");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("\nEntrada inválida! Aperte ENTER para tentar novamente...");
                Console.ReadLine();
            }
        }
    }

    static void DesenharTabuleiro()
    {
        Console.WriteLine(" Jogo da Velha \n");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(" ");
            for (int j = 0; j < 3; j++)
            {
                ImprimirComCor(tabuleiro[i, j]);

                if (j < 2) Console.Write(" | ");
            }
            if (i < 2) Console.WriteLine("\n---+---+---");
        }
        Console.WriteLine();
    }

    static void ImprimirComCor(char c)
    {
        if (c == 'X')
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("X");
            Console.ResetColor();
        }
        else if (c == 'O')
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("O");
            Console.ResetColor();
        }
        else
        {
            Console.Write(c);
        }
    }


    static bool VerificarVitoria()
    {
        // Linhas e colunas
        for (int i = 0; i < 3; i++)
        {
            if (tabuleiro[i, 0] == jogadorAtual && tabuleiro[i, 1] == jogadorAtual && tabuleiro[i, 2] == jogadorAtual)
                return true;
            if (tabuleiro[0, i] == jogadorAtual && tabuleiro[1, i] == jogadorAtual && tabuleiro[2, i] == jogadorAtual)
                return true;
        }

        // Diagonais
        if (tabuleiro[0, 0] == jogadorAtual && tabuleiro[1, 1] == jogadorAtual && tabuleiro[2, 2] == jogadorAtual)
            return true;
        if (tabuleiro[0, 2] == jogadorAtual && tabuleiro[1, 1] == jogadorAtual && tabuleiro[2, 0] == jogadorAtual)
            return true;

        return false;
    }
}