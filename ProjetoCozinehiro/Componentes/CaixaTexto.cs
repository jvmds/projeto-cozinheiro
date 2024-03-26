using System;

namespace CozinheiroRpg.Componentes;

public class CaixaTexto
{
    public int Margem { get; set; } = 10;
    public Char MolduraHorizontal { get; set; } = '#';
    public Char MolduraVertical { get; set; } = '#';
    
    public int Execultar(string texto, params string[] opcoes)
    {
        var tamanhoMolduraHorizontal = Console.WindowWidth - Margem * 2;
        Console.WriteLine($"{new string(' ', Margem)}{new string(MolduraHorizontal, tamanhoMolduraHorizontal)}{new string(' ', Margem)}");
        foreach (var linha in texto.Split('\n'))
        {
            var margemInterna = (Console.WindowWidth - linha.Length - 2 - Margem * 2) / 2;
            Console.WriteLine($"{new string(' ', Margem)}{MolduraVertical}{new string(' ', margemInterna)}{linha}{new string(' ', margemInterna)}{MolduraVertical}{new string(' ', Margem)}");
        }
        Console.WriteLine($"{new string(' ', Margem)}{new string(MolduraHorizontal, tamanhoMolduraHorizontal)}{new string(' ', Margem)}");
        Console.WriteLine();
        
        for (int i = 0; i < opcoes.Length; i++)
        {
            Console.WriteLine($"{new string(' ', Margem + 1)}{i}) {opcoes[i]}");
        }
        
        Console.WriteLine();
        var linhaAtual = Console.CursorTop;
        var txtComando = "Digite o número da opção escolhida: ";
        int comando;
        
        while (true)
        {
            Console.SetCursorPosition(Margem + 1, linhaAtual);
            Console.Write(txtComando);
            if (int.TryParse(Console.ReadLine(), out comando) && comando >= 0 && comando < opcoes.Length)
            {
                break;
            }
            Console.SetCursorPosition(0, linhaAtual);
            Console.Write(new string(' ', Console.WindowWidth));
            txtComando = "Opção incorreta, tente novamente: ";
        }
        
        Console.Clear();
        return comando;
    }
}