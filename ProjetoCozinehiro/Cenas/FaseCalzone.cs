using ProjetoCozinheiro.Componentes;

namespace ProjetoCozinheiro.Cenas;

public class FaseCalzone : FaseBase
{
    public FaseCalzone(int reputacaoExigida, int pontuacaoVitoria) : base(reputacaoExigida, pontuacaoVitoria)
    {
        Descricao = $"Zezinho calzone (Itália) [Reputação necessária: {reputacaoExigida}]";
    }
    
    public override void Executar()
    {
        Introducao();
        (Pontuacao, var reacao) = Pergunta1();
        Pontuacao += Pergunta2(reacao);

        if (Pontuacao < 50)
        {
            if (Pergunta3())
            {
                reacao = "Ufa! Parece que você conseguiu reverter a situaçao.";
            }
            else
            {
                Derrota();
                Pontuacao = 0;
                return;
            }
        }
        else
        {
            reacao = "Excelente! Você está indo muito bem.";
        }
        
        Pontuacao += Pergunta4(reacao);

        if (Pontuacao > 80)
        {
            Vitoria();
        }
        else
        {
            Derrota();
            Pontuacao = 0;
        }
    }

    private void Introducao()
    {
        var menu = new Menu<string>("Zezinho Calzone (Itália)",
                        "Você está prestes a enfrentar Zezinho Cozinheiro, um renomado chef de " +
                        "cozinha italiano, 7 vezes ganhador do Rei da Cozinha com seu inigualável calzone " +
                        "tradicional! Zezinho Cozinheiro perguntou se você está preparado para a derrota?",
                        new Dictionary<string, string>
                        {
                            {"Continuar", "continuar"}
                        }
        );

        _ = menu.Mostrar();
    }

    (int, string) Pergunta1()
    {
        var menu = new Menu<(int, string)>("Zezinho Calzone (Itália)",
                        "O Calzone serviu de inspiração para a Pizza tradicional e sua origem tem " + 
                        "início na região italiana da Apúlia, na zona de Salento. Sua receita correta " + 
                        "é feita com a massa da pizza tradicional.\n" + 
                        "Sua missão é derrotar Zezinho Cozinheiro, para isso precisará fazer um" + 
                        "tradicional calzone! Escolha com muito cuidado os engredientes base de sua receita, uma escolha" + 
                        "errada poderá leva-lo a derrota!",
                        new Dictionary<string, (int, string)>
                        {
                                        {"Presunto, mussarela e Catupiry", (30, "Muito Bem! Excelente escolha.")},
                                        {"Calabresa e mussarela", (20, "Não é excelente, mas inda é uma boa escolha!")},
                                        {"Calabresa e Catupiry", (10, "No limite do tradicional.")},
                                        {"Frango e Catupiry", (0, "Tome cuidao para não fugir da receita tradicional!")},
                        }
        );

        return menu.Mostrar();
    }

    int Pergunta2(string reacao)
    {
        var menu = new Menu<int>("Zezinho Calzone (Itália)",
                        $"{reacao} Vamos lá, você está batento a farinha, o sal e o fermento e está jogando água. O que fará agora?",
                        new Dictionary<string, int>
                        {
                                        {"Aumenta a velocidade da batedeira e joga água aos poucos", 20},
                                        {"Diminui a velocidade da batedeira e joga toda a água", 0},
                                        {"Diminui a velocidade da batedeira e joga a água gradualmente", 30},
                        }
        );

        return menu.Mostrar();
    }
    
    bool Pergunta3()
    {
        var menu = new Menu<bool>("Zezinho Calzone (Itália)",
                        "Parece que sua massa não está chegando no ponto o que você fará?",
                        new Dictionary<string, bool>
                        {
                                        {"Diminuir a velocidade da batedeira e jogar a água gradualmente", true},
                                        {"Jogar mais água" , false},
                        }
        );

        return menu.Mostrar();
    }
    
    int Pergunta4(string reacao)
    {
        var menu = new Menu<int>("Zezinho Calzone (Itália)",
                        $"{reacao} Sua massa está pronta, é hora de?",
                        new Dictionary<string, int>
                        {
                                        {"Deixar descansar, depois colocar o recheio e por fim levar ao forno.", 40},
                                        {"Colocar o recheio e levar ao forno.", 20},
                        }
        );

        return menu.Mostrar();
    }

    
}