using ProjetoCozinheiro.Componentes;

namespace ProjetoCozinheiro.MiniJogos;

public class MiniJogoDigitacao : MiniJogos
{
    private TimeOnly _tempoRestante = TimeOnly.FromDateTime(DateTime.Now);
    private readonly List<string> _caracteresValidos = new()
    {
                    "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
                    "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
                    "U", "V", "X", "Y", "W", "Z",
    };
    
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

    static DificuldadeDigitacao DefinirDificuldade(int pontuacaoAtual) 
    {
        return pontuacaoAtual switch
        {
                        < 40 => DificuldadeDigitacao.Facil(),
                        < 90 => DificuldadeDigitacao.Medio(),
                        _ => DificuldadeDigitacao.Dificil()
        };
    }

    private int Imprimir(DificuldadeDigitacao dificuldadeDigitacao)
    {
        var texto = "";  
        ImprimirCabecalho(dificuldadeDigitacao);
        ImprimirCorpo(dificuldadeDigitacao.Word, texto, Console.CursorTop);
        //var posCursor = Console.GetCursorPosition();
        while (true)
        {
            if (_tempoRestante < TimeOnly.FromDateTime(DateTime.Now))
            {
                return 0;
            }

            if (Console.KeyAvailable)
            {
                var letra = Console.ReadKey(true);
                
                if (letra.Key == ConsoleKey.Backspace && texto.Length > 0)
                {
                    texto = texto[..^1];
                }
                else
                {
                    var t = $"{letra.KeyChar}".ToUpper();
                    if (_caracteresValidos.Contains(t))
                    {
                        texto += t;
                    }
                }

                if (string.Equals(texto, dificuldadeDigitacao.Word, StringComparison.InvariantCultureIgnoreCase))
                {
                    return dificuldadeDigitacao.PointsAwarded;
                }
            }
            
            ImprimirCabecalho(dificuldadeDigitacao);
            ImprimirCorpo(dificuldadeDigitacao.Word, texto, Console.CursorTop);
            
            Thread.Sleep(10);
        }
    }

    private void ImprimirCabecalho(DificuldadeDigitacao dificuldadeDigitacao)
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine(FormatarSeparadores());
        Console.WriteLine(FormatarTexto($"Dificuldade {dificuldadeDigitacao.Difficulty}"));
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
}