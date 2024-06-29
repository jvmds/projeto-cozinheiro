using System.Collections;
using System.Text;

namespace ProjetoCozinheiro.Componentes;

public class Menu<T>
{
    private static string QUEBRA_LINHA = "\n";
    protected static char ESPACO = ' ';
    private static string HIFEN = "-";
    public string Titulo { get; set; }
    public string Corpo { get; set; }
    public int MargemExterna { get; set; } = 10;
    public int MargemInterna { get; set; } = 2;
    public char Moldura { get; set; } = '*';
    public Dictionary<string, T> Opcoes { get; set; }
    
    public Menu(string titulo, string corpo, Dictionary<string, T> opcoes)
    {
        Titulo = titulo;
        Corpo = corpo;
        Opcoes = opcoes;
    }

    public virtual T? Mostrar()
    {
        ConfigurarImprimir(Titulo);
        ConfigurarImprimir(Corpo, false);
        var opcoes = ConfigurarImprimirOpcoes();
        var opcao = ExecultarPrompt(opcoes);
        Console.Clear();
        return opcao;
    }

    protected void ConfigurarImprimir(string src, bool molduraSuperior = true, bool molduraInferior = true)
    {
        var tamanhoMaxCaracteresPorLinha = ObterTamanhoMaxCaracteresPorLinha();
        if (molduraSuperior)
        {
            Imprimir(new string(Moldura, tamanhoMaxCaracteresPorLinha), false);
        }
        
        var caracteres = ConverterTabulacaoQuebrarTexto(src);
        var linhaAtual = new StringBuilder();
        foreach (var c in caracteres)
        {
            if (c == QUEBRA_LINHA)
            {
                var txt = linhaAtual.ToString().PadRight(tamanhoMaxCaracteresPorLinha);
                Imprimir(txt);
                linhaAtual.Clear();
                continue;
            }
            
            if (linhaAtual.Length + c.Length > tamanhoMaxCaracteresPorLinha)
            {
                var txt = linhaAtual.ToString();
                if (txt[^1] == ESPACO)
                {
                    Imprimir(txt);
                    linhaAtual.Clear();
                }
                else
                {
                    var pos = txt.LastIndexOf(ESPACO);
                    if (pos < 0)
                    {
                        var txtP1 = txt[..^1];
                        Imprimir(txtP1 + HIFEN);
                        linhaAtual.Clear();
                        linhaAtual.Append(txt[^1]);
                    }
                    else
                    {
                        var txtP1 = txt[..pos].PadRight(tamanhoMaxCaracteresPorLinha);
                        var txtP2 = txt[pos..];
                        Imprimir(txtP1);
                        linhaAtual.Clear();
                        linhaAtual.Append(txtP2);
                    }
                }
            }
            
            linhaAtual.Append(c);
        }

        if (linhaAtual.Length > 0)
        {
            var txt = linhaAtual.ToString().PadRight(tamanhoMaxCaracteresPorLinha);
            Imprimir(txt);
        }
        
        if (molduraInferior)
        {
            Imprimir(new string(Moldura, tamanhoMaxCaracteresPorLinha), false);
        }
    }

    private void Imprimir(string txt, bool margemInterna = true)
    {
        var molduraInterna = margemInterna ? ESPACO : Moldura;
        
        Console.Write($"{new string(' ', MargemExterna)}" +
                      $"{Moldura}" +
                      $"{new string(molduraInterna, MargemInterna)}" +
                      $"{txt}{new string (molduraInterna, MargemInterna)}" +
                      $"{Moldura}" +
                      $"{new string(' ', MargemExterna)}");
        
    }

    private static IEnumerable<string> ConverterTabulacaoQuebrarTexto(string txt)
    {
        return txt.Select(c => c == '\r' ? "    " : $"{c}").ToList();
    }
    private int ObterTamanhoMaxCaracteresPorLinha()
    {
        return Console.WindowWidth - MargemExterna * 2 - MargemInterna * 2 - 2;
    }
    
    protected List<T> ConfigurarImprimirOpcoes()
    {
        List<T> opcoes = new();
        foreach (var item in Opcoes)
        {
            opcoes.Add(item.Value);
            ConfigurarImprimir($"{opcoes.Count}) {item.Key}", false, false);
        }

        return opcoes;
    }
    
    protected T ExecultarPrompt(IList<T> opcoes)
    {
        Imprimir(new string(Moldura, ObterTamanhoMaxCaracteresPorLinha()), false);
        Console.Write($"{new string(' ', MargemExterna)}" +
                                    $"{Moldura}" +
                                    $"{new string(ESPACO, MargemInterna)}" +
                                    "Digite o número da opção escolhida: ");
        var linhaAtual = Console.CursorTop;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out var opcao) && opcao >= 0 && opcao <= opcoes.Count)
            {
                return opcoes[opcao - 1];
            }
            Console.SetCursorPosition(0, linhaAtual);
            Console.Write(new string(ESPACO, Console.WindowWidth));
            Console.SetCursorPosition(0, linhaAtual);
            Console.Write($"{new string(ESPACO, MargemExterna)}" +
                          $"{Moldura}" +
                          $"{new string(ESPACO, MargemInterna)}" +
                          "Opção incorreta, Digite o número da opção escolhida: ");
        }
    }
}