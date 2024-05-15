namespace ProjetoCozinheiro.Componentes;

public class Jogador
{
    public int Reputacao { get; private set; }
    
    public void AdicionarReputacao(int reputacao)
    {
        if (Reputacao + reputacao > 100)
        {
            Reputacao = 100;
        }
        else
        {
            Reputacao += reputacao;
        }
    }
    
    public void RemoverReputacao(int reputacao)
    {
        if (Reputacao - reputacao < 0)
        {
            Reputacao = 0;
        }
        else
        {
            Reputacao -= reputacao;
        }
    }
}