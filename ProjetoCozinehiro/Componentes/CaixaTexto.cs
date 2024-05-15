using System;
using System.Text;
using System.Text.RegularExpressions;

namespace CozinheiroRpg.Componentes;

public partial class CaixaTexto
{
    public int Margem { get; set; } = 10;
    public Char MolduraHorizontal { get; set; } = '#';
    public Char MolduraVertical { get; set; } = '#';
    
    public int Executar(string texto, params string[] opcoes)
    {
        var tamanhoMolduraHorizontal = Console.WindowWidth - Margem * 2;
        Console.WriteLine($"{new string(' ', Margem)}{new string(MolduraHorizontal, tamanhoMolduraHorizontal)}{new string(' ', Margem)}");
        var textoImpresso = new StringBuilder();
        
        var margemEsquerda = $"{new string(' ', Margem)}{MolduraVertical}";
        var margemDireita = $"{MolduraVertical}{new string(' ', Margem)}";
        var tamanhoMaxLinhas = Console.WindowWidth - margemEsquerda.Length - margemDireita.Length;
        var linhasFormatadas = Regex.Replace(texto, @"(\n|\r)", " ").Split(' ');
        var palavra = 0;

        do
        {
            var l = linhasFormatadas[palavra];
            palavra++;

            if (((textoImpresso.Length + l.Length) > tamanhoMaxLinhas)
                || (palavra >= linhasFormatadas.Length))
            {
                var margemInterna = new string(' ', (tamanhoMaxLinhas - textoImpresso.Length) / 2);
                Console.WriteLine($"{margemEsquerda}{margemInterna}{textoImpresso}{margemInterna}{margemDireita}");
                textoImpresso.Clear();
            }

            textoImpresso.Append($"{l} ");

        } while (palavra < linhasFormatadas.Length);

        Console.WriteLine($"{new string(' ', Margem)}{new string(MolduraHorizontal, tamanhoMolduraHorizontal)}{new string(' ', Margem)}");
        Console.WriteLine();
        
        for (var i = 0; i < opcoes.Length; i++)
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
    
    public int Executar(string texto, string imagem, params string[] opcoes)
    {
        var tamanhoMolduraHorizontal = Console.WindowWidth - Margem * 2;
        Console.WriteLine($"{new string(' ', Margem)}{new string(MolduraHorizontal, tamanhoMolduraHorizontal)}{new string(' ', Margem)}");
        foreach (var linha in imagem.Split('\n'))
        {
            var linhaSemEspacos = linha;
            var tamanho = tamanhoMolduraHorizontal - linhaSemEspacos.Length - 2;
            var margemInterna = tamanho / 2;
            Console.WriteLine($"{new string(' ', Margem)}{MolduraVertical}{new string(' ', margemInterna)}{linhaSemEspacos}{new string(' ', margemInterna)}{MolduraVertical}{new string(' ', Margem)}");
        }

        return Executar(texto, opcoes);
    }
}