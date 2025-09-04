using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Digite uma palavra: ");
        string palavra = Console.ReadLine();

        if (EhPalindromo(palavra))
        {
            Console.WriteLine($"A palavra \"{palavra}\" é um palíndromo!");
        }
        else
        {
            Console.WriteLine($"A palavra \"{palavra}\" NÃO é um palíndromo!");
        }
    }

    static bool EhPalindromo(string palavra)
    {
        // Normaliza: tudo minúsculo e sem espaços
        palavra = palavra.ToLower().Replace(" ", "");

        Stack<char> pilha = new Stack<char>();

        // Empilha todos os caracteres
        foreach (char c in palavra)
        {
            pilha.Push(c);
        }

        // Compara removendo da pilha (ordem inversa)
        foreach (char c in palavra)
        {
            if (c != pilha.Pop())
                return false;
        }

        return true;
    }
}