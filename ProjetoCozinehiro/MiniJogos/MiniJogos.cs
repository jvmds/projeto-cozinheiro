using ProjetoCozinheiro.Componentes;

namespace ProjetoCozinheiro.MiniJogos;

public abstract class MiniJogos
{
    public int MargemExterna { get; set; } = 5;
    public int MargemInterna { get; set; } = 2;
    public char Moldura { get; set; } = '*';
    
    public abstract int Executar(int pontuacaoAtual);
    
    protected string FormatarSeparadores()
    {
        var tamanho = Console.WindowWidth - MargemExterna * 2;
        
        return $"{new string(' ', MargemExterna)}{new string(Moldura, tamanho)}{new string(' ', MargemExterna)}";
    }
    protected string FormatarTexto(string texto)
    {
        var tamanho = Console.WindowWidth - (MargemExterna * 2 + MargemInterna * 2 + 2);
        var txtCentralizado = CentralizarTexto(texto, tamanho);
        
        return $"{new string(' ', MargemExterna)}{Moldura}{new string(' ', MargemInterna)}{txtCentralizado}{new string(' ', MargemInterna)}{Moldura}{new string(' ', MargemExterna)}";
    }
    
    protected string CentralizarTexto(string texto, int larguraTotal)
    {
        if (texto.Length >= larguraTotal)
        {
            return texto;
        }

        var espacosTotal = larguraTotal - texto.Length - 2;
        var espacosEsquerda = espacosTotal / 2;
        var espacosDireita = espacosTotal - espacosEsquerda;

        var espacos = new string(' ', espacosEsquerda);

        return $"{Moldura}{espacos}{texto}{new string(' ', espacosDireita)}{Moldura}";
    }
    
    protected virtual OpcoesMenu Derrota()
    {
        Console.Clear();
        var menu = new Menu<OpcoesMenu>("NÃO FOI DESSA VEZ!",
                        "Nao deu. O quer fazer?",
                        new Dictionary<string, OpcoesMenu>
                        {
                                        {"Mais uma vez, agora vai!", OpcoesMenu.Sim},
                                        {"Voltar para casa", OpcoesMenu.Sair}
                        }
        );

        return menu.Mostrar();
    }
    
    protected virtual OpcoesMenu Vitoria(int pontuacao)
    {
        Console.Clear();
        var menu = new Menu<OpcoesMenu>("DEU BOM!",
                        $"Acaba de subir {pontuacao} pontos em sua reputação, o quer fazer?",
                        new Dictionary<string, OpcoesMenu>
                        {
                                        {"Ir novamente", OpcoesMenu.Sim},
                                        {"Voltar para casa", OpcoesMenu.Sair}
                        }
        );

        return menu.Mostrar();
    }
}