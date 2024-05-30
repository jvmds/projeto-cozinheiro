using ProjetoCozinheiro.Componentes;

namespace ProjetoCozinheiro.Cenas;

public class FaseCachorroQuente : FaseBase
{
    public FaseCachorroQuente(int reputacaoExigida, int pontuacaoVitoria) : base(reputacaoExigida, pontuacaoVitoria)
    {
        Descricao = $"Alemão dos Cachorros (Alemanhã) [Reputação necessária: {reputacaoExigida}]";
    }

    public override void Executar()
    {
        Introducao();
        (var pontuacao, var reacao) = Pergunta1();

        if (pontuacao <= 0)
        {
            Pontuacao = Sair(reacao);
        }
        else
        {
            Pontuacao += Pergunta2(reacao);
            if (pontuacao is not (0 or 1))
            {
                Derrota();
            }
            else
            {
                Pontuacao += pontuacao;
                (pontuacao, reacao) = Pergunta3();

                if (pontuacao > 0)
                {
                    Pontuacao += Pergunta4(reacao);
                }
            }
        }

        if (Pontuacao > PontuacaoVitoria)
        {
            Vitoria();
        }
        else
        {
            Derrota();
        }
    }

    private void Introducao()
    {
        var menu = new Menu<OpcoesMenu>("Alemão dos Cachorros (Alemanhã)",
                        "Criar uma pequena introdução sobre o chefe que será enfrentado!",
                        new Dictionary<string, OpcoesMenu>
                        {
                                        {"Continuar", OpcoesMenu.Sair}
                        }
        );

        _ = menu.Mostrar();
    }
    
    (int, string) Pergunta1()
    {
        var menu = new Menu<(int, string)>("Zezinho Calzone (Itália)",
                        @"Hmmmm, já senti o cheiro daqui, já imaginou onde para onde nós estamos indo ?!
                        Em Frankefurt alemanha, o famoso cachorro-quente alemão.
                        Sua missão é criar um tradicional cachorro-quente alemão, para isso escolha os ingredientes base.",
                        new Dictionary<string, (int, string)>
                        {
                                        {"Pão, salsicha, molho de tomate e ketchup", (10, "Boa escolha, mas poderia ser melhor")},
                                        {"Pão de batata, feijoada e laranjada", (0, "Ih rapaz, terá que voltar para faculdade de gastronomia")},
                                        {"Salsicha,molho de tomate e batata-palha", (20, "Está fugindo da receita tradicional, mas podemos continuar")},
                                        {"Frango assado e refrigerante diet", (-1, "https://www.youtube.com/watch?v=qwK9o9-Hk14")},
                                        {"Pedir para algum parente cozinhar, já que não temos todos ingredientes", (0, "https://www.youtube.com/watch?v=pnlWzrZ1iOA")},
                                        {"Salsicha alemã, pão de cachorro de quente,molho de tomate e alho e sal", (30, "Descobrimos uma novo ratatouille")},
                        }
        );

        return menu.Mostrar();
    }
    
    int Pergunta2(string reacao)
    {
        var menu = new Menu<int>("Alemão dos Cachorros",
                        $"{reacao} Vamos lá, vamos cozinhar com nossos ingredientes, como devemos começar?",
                        new Dictionary<string, int>
                        {
                                        {"Adicionar tudo na panela e aguarda a comida ficar pronta", 0},
                                        {"Adicionar o alho com sal na panela, até ficar dourado e logo em seguida colocar a salsicha", 20},
                                        {"Começar dorando o alho e cebola, aguardar 5 minutos, acrescentar o molho de tomate e logo depois acrescentar a salsicha", 20},
                                        {"Imaginar tal preparação e aguardar", 0},
                        }
        );

        return menu.Mostrar();
    }
    
    (int, string) Pergunta3()
    {
        var menu = new Menu<(int, string)>("Alemão dos Cachorros",
                        "Parece que sua comida não está cozinhado corretamente?",
                        new Dictionary<string, (int, string)>
                        {
                                        {"Jogar mais água e aumentar a intensidade do fogo", (0, "")},
                                        {"Averiguar se o fogão está ligado, diminuir a intensidade do fogo e aguardar mais 10 minutos e repetir o processo todo novamente até cozinhar", (20, "Ufa! Parece que você conseguiu reverter a situaçao.")},
                                        {"Desisti de ser gastrônomo e vira NPC de rede socias", (0, "")},
                        }
        );

        return menu.Mostrar();
    }
    
    int Pergunta4(string reacao)
    {
        var menu = new Menu<int>("Alemão dos Cachorros",
                        $"{reacao} Seu cachorro-quente está pronto, é hora de?",
                        new Dictionary<string, int>
                        {
                                        {"Preparar e comer", 20},
                                        {"Agradacer por não colocar fogo na cozinh", 10},
                        }
        );

        return menu.Mostrar();
    }
    
    private int Sair(string reacao)
    {
        var menu = new Menu<int>("Alemão dos Cachorros (Alemanhã)",
                        $"Péssimo! Clique no link, {reacao}",
                        new Dictionary<string, int>
                        {
                                        {"Voltar perdedor!", 0}
                        }
        );

        return menu.Mostrar();
    }
}