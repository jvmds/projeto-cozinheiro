using ProjetoCozinheiro.Componentes;

namespace ProjetoCozinheiro.Cenas;

public abstract class FaseBase
{
    public int PontuacaoVitoria { get; set; }
    public int ReputacaoExigida { get; set; }
    public int Pontuacao { get; protected set; }

    public string Descricao { get; protected set; } = "";

    public FaseBase(int reputacaoExigida, int pontuacaoVitoria)
    {
        ReputacaoExigida = reputacaoExigida;
        PontuacaoVitoria = pontuacaoVitoria;
        Descricao = "";
    }

    public abstract void Executar();
    
    protected virtual void Derrota()
    {
        var menu = new Menu<string>("DERROTADO!",
                        "Você nem chegou perto! kkkkkk",
                        new Dictionary<string, string>
                        {
                                        {"Ir para casa chorar", "continuar"}
                        }
        );

        _ = menu.Mostrar();
    }
    
    protected virtual void Vitoria()
    {
        var menu = new Menu<string>("Julgamento!",
                        $"Sua nota foi {Pontuacao}! Você mostrou seu valor, parabéns!",
                        new Dictionary<string, string>
                        {
                                        {"Continuar porque sou foda!", "continuar"}
                        }
        );

        _ = menu.Mostrar();
    }
}