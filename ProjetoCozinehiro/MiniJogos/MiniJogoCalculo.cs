using ProjetoCozinheiro.Componentes;

namespace ProjetoCozinheiro.MiniJogos;

public class MiniJogoCalculo : MiniJogos
{
    private TimeOnly _tempoRestante = TimeOnly.FromDateTime(DateTime.Now);
    private readonly List<char> _caracteresValidos = new() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    public override int Executar(int pontuacaoAtual, bool retentativa = true)
    {
        var resultadoTotal = 0;
        while (true)
        {
            var dificuldade = DefinirDificuldade(pontuacaoAtual + resultadoTotal);
            _tempoRestante = TimeOnly.FromDateTime(DateTime.Now).Add(dificuldade.Tempo.ToTimeSpan());
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

    static DificuldadeCalculo DefinirDificuldade(int pontuacaoAtual) 
    {
        return pontuacaoAtual switch
        {
                        < 40 => DificuldadeCalculo.Facil(),
                        < 90 => DificuldadeCalculo.Medio(),
                        _ => DificuldadeCalculo.Dificil()
        };
    }

    private int Imprimir(DificuldadeCalculo dificuldadeDigitacao)
    {
        var texto = "";  
        ImprimirCabecalho(dificuldadeDigitacao);
        ImprimirCorpo(dificuldadeDigitacao.Expressao, texto, Console.CursorTop);
        
        while (true)
        {
            if (_tempoRestante < TimeOnly.FromDateTime(DateTime.Now))
            {
                return 0;
            }

            if (Console.KeyAvailable)
            {
                var tecla = Console.ReadKey(true);
                if (tecla.Key == ConsoleKey.Backspace && texto.Length > 0)
                {
                    texto = texto[..^1];
                }
                else if (tecla.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else
                {
                    var caracter = tecla.KeyChar;
                    if (_caracteresValidos.Contains(caracter) || (texto.Length == 0 && caracter == '-'))
                    {
                        texto += $"{caracter}";
                    }
                }
            }
            
            ImprimirCabecalho(dificuldadeDigitacao);
            ImprimirCorpo(dificuldadeDigitacao.Expressao, texto, Console.CursorTop);
            
            Thread.Sleep(10);
        }
        
        if (int.TryParse(texto, out var resultado) && resultado == dificuldadeDigitacao.Resultado)
        {
            return dificuldadeDigitacao.Pontos;
        }

        return 0;
    }

    private void ImprimirCabecalho(DificuldadeCalculo dificuldadeDigitacao)
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine(FormatarSeparadores());
        Console.WriteLine(FormatarTexto($"Dificuldade {dificuldadeDigitacao.Dificuldade}"));
        Console.WriteLine(FormatarTexto($"{_tempoRestante - TimeOnly.FromDateTime(DateTime.Now)}"));
        Console.WriteLine(FormatarSeparadores());
    }

    private void ImprimirCorpo(string txtAlvo, string txtDigitado, int top)
    {
        Console.SetCursorPosition(0, top);
        Console.WriteLine(FormatarTexto("Resolva a expressão abaixo antes do tempo acabar"));
        Console.WriteLine(FormatarTexto(txtAlvo));
        Console.WriteLine(FormatarSeparadores());
        Console.WriteLine(FormatarTexto(txtDigitado));
        Console.WriteLine(FormatarSeparadores());
    }
}