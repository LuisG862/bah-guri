using Bubble_Sort;

Console.WriteLine("Oredenação com Bubble Sort:\n");

int[] arrNumbers = new int[] { 99, 50, -24, 0, 1 };

foreach (var number in arrNumbers)
    Console.Write($"[{number}]\n");

var arrOrdered = BubbleSortOrder.Sort<int>(arrNumbers);


Console.WriteLine("\nVetor Ordenado:\n");

foreach (var number in arrOrdered)
    Console.Write($"[{number}]\n");

Console.WriteLine("\n***********************");
Console.WriteLine("\nOredenação com Bubble Sort com string:\n");

string[] arrString = new string[] { "K", "50", "-24", "H", "HG" };

foreach (var i in arrString)
    Console.Write($"[{i}] \n");

var arrOrdenedString = BubbleSortOrder.Sort<string>(arrString);


Console.WriteLine("\nVetor Ordenado:\n");

foreach (var i in arrOrdenedString)
    Console.Write($"[{i}]");

