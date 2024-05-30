using ProjetoCozinheiro.Componentes;

namespace ProjetoCozinheiro.MiniJogos;

public class MiniJogoTempo : MiniJogos
{
    private TimeOnly _tempoRestante = TimeOnly.FromDateTime(DateTime.Now);
    public int MargemExterna { get; set; } = 5;
    public int MargemInterna { get; set; } = 2;
    public char Moldura { get; set; } = '*';
    
    public override int Executar(int pontuacaoAtual)
    {
        var resultadoTotal = 0;
        while (true)
        {
            var dificuldade = DefinirDificuldade(pontuacaoAtual + resultadoTotal);
            _tempoRestante = TimeOnly.FromDateTime(DateTime.Now).Add(dificuldade.TimeLimit.ToTimeSpan());
            var resultado = Imprimir(dificuldade);
            
            if (resultado <= 0)
            {
                if (Derrota() == OpcoesMenu.Sair)
                {
                    break;
                }
            }
            else
            {
                resultadoTotal += resultado;
                if (Vitoria(resultado) == OpcoesMenu.Sair)
                {
                    break;
                }
            }
        }

        return resultadoTotal;
    }

    static Dificuldade DefinirDificuldade(int pontuacaoAtual) 
    {
        return pontuacaoAtual switch
        {
                        < 40 => Dificuldade.Facil(),
                        < 90 => Dificuldade.Medio(),
                        _ => Dificuldade.Dificil()
        };
    }

    private int Imprimir(Dificuldade dificuldade)
    {
        var texto = "";  
        ImprimirCabecalho(dificuldade);
        ImprimirCorpo(dificuldade.Word, texto, Console.CursorTop);
        //var posCursor = Console.GetCursorPosition();
        while (true)
        {
            if (_tempoRestante < TimeOnly.FromDateTime(DateTime.Now))
            {
                return 0;
            }

            if (Console.KeyAvailable)
            {
                var tecla = Console.ReadKey(true);
                if (tecla.Key == ConsoleKey.Backspace)
                {
                    texto = texto[..^1];
                }

                texto += $"{tecla.KeyChar}".ToUpper();

                if (string.Equals(texto, dificuldade.Word, StringComparison.InvariantCultureIgnoreCase))
                {
                    return dificuldade.PointsAwarded;
                }
            }
            
            ImprimirCabecalho(dificuldade);
            ImprimirCorpo(dificuldade.Word, texto, Console.CursorTop);
            
            Thread.Sleep(10);
        }
    }

    private void ImprimirCabecalho(Dificuldade dificuldade)
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine(FormatarSeparadores());
        Console.WriteLine(FormatarTexto($"Dificuldade {dificuldade.Difficulty}"));
        Console.WriteLine(FormatarTexto($"{_tempoRestante - TimeOnly.FromDateTime(DateTime.Now)}"));
        Console.WriteLine(FormatarSeparadores());
    }

    private void ImprimirCorpo(string txtAlvo, string txtDigitado, int top)
    {
        Console.SetCursorPosition(0, top);
        Console.WriteLine(FormatarTexto("Digite as letras abaixo antes do tempo acabar"));
        Console.WriteLine(FormatarTexto(txtAlvo));
        Console.WriteLine(FormatarSeparadores());
        Console.WriteLine(FormatarTexto(txtDigitado));
        Console.WriteLine(FormatarSeparadores());
    }

    private string FormatarSeparadores()
    {
        var tamanho = Console.WindowWidth - MargemExterna * 2;
        
        return $"{new string(' ', MargemExterna)}{new string(Moldura, tamanho)}{new string(' ', MargemExterna)}";
    }
    private string FormatarTexto(string texto)
    {
        var tamanho = Console.WindowWidth - (MargemExterna * 2 + MargemInterna * 2 + 2);
        var txtCentralizado = CentralizarTexto(texto, tamanho);
        
        return $"{new string(' ', MargemExterna)}{Moldura}{new string(' ', MargemInterna)}{txtCentralizado}{new string(' ', MargemInterna)}{Moldura}{new string(' ', MargemExterna)}";
    }
    
    private string CentralizarTexto(string texto, int larguraTotal)
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
    
    protected OpcoesMenu Derrota()
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
    
    protected OpcoesMenu Vitoria(int pontuacao)
    {
        Console.Clear();
        var menu = new Menu<OpcoesMenu>("DEU BOM!",
                        $"Acaba de subir {pontuacao} em sua reputação, o quer fazer?",
                        new Dictionary<string, OpcoesMenu>
                        {
                                        {"Ir novamente", OpcoesMenu.Sim},
                                        {"Voltar para casa", OpcoesMenu.Sair}
                        }
        );

        return menu.Mostrar();
    }
}