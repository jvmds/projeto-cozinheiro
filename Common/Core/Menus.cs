using System.Text;
using System.Text.RegularExpressions;
using Common.DTOs;

namespace Common.Core;

public class Menu
{
    public static int TAMANH_MIN_MENU = 50;
    
    private ConfiguracaoMenu _configuracoes;
    public Menu(ConfiguracaoMenu configuracoes)
    {
        _configuracoes = configuracoes;
    }
    
    public int PopUpLista(string entrada, Dictionary<int, string> opcoes)
    {
        var caracteresPorLinha = ObterTamanhoMaxCaracteresPorLinha(true);
        var textoForm = QuebrarTextoEmPalavras(RemoverQuebrasLinhas(entrada));
        var posicao = 0;
        
        Console.WriteLine(ObterMolduraHorizontal());
        var textoImpresso = new StringBuilder();
        while (posicao < textoForm.Length)
        {
            var palavra = textoForm[posicao];
            if (textoImpresso.Length + palavra.Length > caracteresPorLinha)
            {
                ImprimirLinha(textoImpresso.ToString());
                textoImpresso.Clear();
                textoImpresso.Append(palavra);
            }
            else
            {
                if (textoImpresso.Length == 0)
                {
                    textoImpresso.Append(palavra);
                }
                else
                {
                    textoImpresso.Append($" {palavra}");
                }
            }
            
            posicao++;
        }

        if (textoImpresso.Length != 0)
        {
            ImprimirLinha(textoImpresso.ToString());
        }
        Console.WriteLine(ObterMolduraHorizontal());
        ImprimirOpcoes(opcoes);
        
        return ExecultarPrompt(1, opcoes.Count);
    }
    public int PopUpLista(string entrada, string imagem, Dictionary<int, string> opcoes)
    {
        Console.WriteLine(ObterMolduraHorizontal());
        foreach (var linha in DividirImagem(imagem))
        {
            ImprimirLinha(linha);
        }

        return PopUpLista(entrada, opcoes);
    }
    
    
    private int ObterTamanhoMaxCaracteresPorLinha(bool incluirMargemInterna = false)
    {
        int tamanho;
        if (incluirMargemInterna)
        {
            tamanho = Console.WindowWidth - (_configuracoes.TamanhoMargemExterna * 2) - (_configuracoes.TamanhoMargemInterna * 2) - 2;
        }
        else
        {
            tamanho = Console.WindowWidth - _configuracoes.TamanhoMargemExterna * 2;
        }
        
        return tamanho < 50 ? 50 : tamanho;
    }
    private string ObterMolduraHorizontal()
    {
        return new string(' ', _configuracoes.TamanhoMargemExterna) +
               new string(_configuracoes.Margem, ObterTamanhoMaxCaracteresPorLinha()) +
               new string(' ', _configuracoes.TamanhoMargemExterna);
    }
    private string ObterMargem() => new(' ', _configuracoes.TamanhoMargemExterna);
    private static string RemoverQuebrasLinhas(string entrada) => Regex.Replace(entrada, @"(\n|\r)", " ");
    private string[] QuebrarTextoEmPalavras(string entrada) => entrada.Split(' ');
    private void ImprimirLinha(string texto)
    {
        var caracteresPorLinha = ObterTamanhoMaxCaracteresPorLinha(true);
        var margemInterna = caracteresPorLinha - texto.Length;
        var margem1 = (int)margemInterna / 2;
        var margem2 = margemInterna - margem1;
        
        Console.WriteLine($"{ObterMargem()}" +
                          $"{_configuracoes.Margem}" +
                          $"{new string(' ', _configuracoes.TamanhoMargemInterna)}" +
                          $"{new string(' ', margem1)}" +
                          $"{texto}" +
                          $"{new string(' ', margem2)}" +
                          $"{new string(' ', _configuracoes.TamanhoMargemInterna)}" +
                          $"{_configuracoes.Margem}" +
                          $"{ObterMargem()}");
    }
    private void ImprimirOpcoes(IReadOnlyDictionary<int, string> opcoes)
    {
        Console.WriteLine();
        foreach (var chave in opcoes)
        {
            Console.WriteLine($"{new string(' ', _configuracoes.TamanhoMargemExterna + 1)}{chave.Key}) {chave.Value}");
        }
    }
    private int ExecultarPrompt(int inicio, int fim, string texto = "Digite o número da opção escolhida: ")
    {
        Console.WriteLine();
        var linhaAtual = Console.CursorTop;
        Console.Write($"{ObterMargem()} {texto}");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out var opcao) && opcao >= inicio && opcao <= fim)
            {
                Console.Clear();
                return opcao;
            }
            Console.SetCursorPosition(0, linhaAtual);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write($"{ObterMargem()} Opção incorreta, {texto}");
        }
    }
    private IEnumerable<string> DividirImagem(string imagem) => imagem.Split('\n');
}