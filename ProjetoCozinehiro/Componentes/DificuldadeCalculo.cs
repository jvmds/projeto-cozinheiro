using System.Data;
using System.Text;

namespace ProjetoCozinheiro.Componentes;

public class DificuldadeCalculo
{
    private static string OPERADORES = "+-*";
    public string Dificuldade { get; private set; }
    public TimeOnly Tempo { get; private set; }
    public string Expressao { get; private set; }
    public int Resultado { get; private set; }
    public int Pontos { get; private set; }

    private DificuldadeCalculo(string dificuldade, TimeOnly tempo, string expressao, int resultado, int pontos)
    {
        Dificuldade = dificuldade;
        Tempo = tempo;
        Expressao = expressao;
        Resultado = resultado;
        Pontos = pontos;
    }

    public static DificuldadeCalculo Facil()
    {
        var rand = new Random();
        var tabela = new DataTable();
        var expressao = $"{rand.Next(0, 10)} {OPERADORES[rand.Next(0, OPERADORES.Length)]} {rand.Next(0, 10)}";
        var resultado = Convert.ToInt32(tabela.Compute(expressao, string.Empty));
        
        return new DificuldadeCalculo("FÁCIL", new TimeOnly(0, 0, 20), expressao, resultado, 5);
    }
    
    public static DificuldadeCalculo Medio()
    {
        var rand = new Random();
        var tabela = new DataTable();
        var expressao = $"{rand.Next(0, 10)} {OPERADORES[rand.Next(0, OPERADORES.Length)]} {rand.Next(0, 10)} {OPERADORES[rand.Next(0, OPERADORES.Length)]} {rand.Next(0, 10)}";
        var resultado = Convert.ToInt32(tabela.Compute(expressao, string.Empty));
        
        return new DificuldadeCalculo("MÉDIA", new TimeOnly(0, 0, 15), expressao, resultado, 10);
    }

    public static DificuldadeCalculo Dificil()
    {
        var rand = new Random();
        var tabela = new DataTable();
        var expressao = $"{rand.Next(0, 10)} {OPERADORES[rand.Next(0, OPERADORES.Length)]} {rand.Next(0, 10)} " +
                        $"{OPERADORES[rand.Next(0, OPERADORES.Length)]} {rand.Next(0, 10)} " +
                        $"{OPERADORES[rand.Next(0, OPERADORES.Length)]} {rand.Next(0, 10)}";
        var resultado = Convert.ToInt32(tabela.Compute(expressao, string.Empty));
        
        return new DificuldadeCalculo("DIFÍCIL", new TimeOnly(0, 0, 10), expressao, resultado, 15);
    }
}