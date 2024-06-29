using System.Text;

namespace ProjetoCozinheiro.Componentes;

public class DificuldadeDigitacao
{
    private static int A = 65;
    private static int Z = 91;
    public string Difficulty { get; private set; }
    public TimeOnly TimeLimit { get; private set; }
    public string Word { get; private set; }
    public int PointsAwarded { get; private set; }

    private DificuldadeDigitacao(string difficulty, TimeOnly timeLimit, string word, int pointsAwarded)
    {
        Difficulty = difficulty;
        TimeLimit = timeLimit;
        Word = word;
        PointsAwarded = pointsAwarded;
    }

    public static DificuldadeDigitacao Facil()
    {
        return new DificuldadeDigitacao("FÁCIL", new TimeOnly(0, 0, 30), GenerateRandomLetters(10), 5);
    }
    
    public static DificuldadeDigitacao Medio()
    {
        return new DificuldadeDigitacao("MÉDIA", new TimeOnly(0, 0, 20), GenerateRandomLetters(12), 10);
    }

    public static DificuldadeDigitacao Dificil()
    {
        return new DificuldadeDigitacao("DIFÍCIL", new TimeOnly(0, 0, 15), GenerateRandomLetters(15), 15);
    }

    private static string GenerateRandomLetters(int length)
    {
        var rand = new Random();
        var result = new StringBuilder(length);
        
        for (var i = 0; i < length; i++)
        {
            result.Append((char)rand.Next(A, Z));
        }
        
        return result.ToString();
    }
}