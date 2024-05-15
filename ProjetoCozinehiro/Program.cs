using Common.Core;
using Common.DTOs;
using ProjetoCozinheiro.Cenas;
using ProjetoCozinheiro.Common;
using ProjetoCozinheiro.Componentes;

Start.Iniciar();
var jogador = new Jogador();
var menu = new Menu(new ConfiguracaoMenu());
var fases = new List<FaseBase>
{
                new FaseCalzone(menu, 50),
};

// Introdução
var escolha = menu.PopUpLista("Você é um chefe de cozinha em crescimento que pretende viajar o mundo e " +
                                 "enfrentar os melhores cozinheiros e assim se tornar o maior cozinheiro do mundo!",
                Imagens.CHEF,
                [
                                "Continuar",
                                "Desistir"
                ]);

if (escolha == 1)
{
    var sair = false;
    while (!sair)
    {
        escolha = menu.PopUpLista($"Sua reputação atual é {jogador.Reputacao}. O que pretende fazer?",
        [
                        "Aumentar reputação",
                        "Meter o doido e ir para cima do adversários",
                        "Desistir de tudo"
        ]);

        switch (escolha)
        {
            case 1:
                // perguntas e respostas
                break;
            case 2:
            {
                var sairSubMenu = false;
                while (!sairSubMenu)
                {
                    var fasesF = fases.Select(f => f.Descricao).ToList();
                    fasesF.Add("Voltar");
                    escolha = menu.PopUpLista("Qual você vai enfrentar?", fasesF.ToArray());

                    if (escolha == fasesF.Count)
                    {
                        sairSubMenu = true;
                    }
                    else
                    {
                        var chef = fases[escolha - 1];
                        var pontuacao = chef.Executar();
                        if (pontuacao > chef.NivelReputacaoExigido)
                        {
                            jogador.AdicionarReputacao(100);
                            fases.Remove(chef);
                            var _ = menu.PopUpLista("Show!", ["Continuar"]);
                        }
                        else
                        {
                            var _ =menu.PopUpLista("Tente aumentar sua reputação", ["Continuar"]);
                        }

                        if (jogador.Reputacao >= 100)
                        {
                            sairSubMenu = false;
                            sair = false;
                            var _ = menu.PopUpLista("Vitória", ["Continuar"]);
                        }
                    }
                }
                break;
            }
            default:
            {
                var _ = menu.PopUpLista("Você é um bebê chorão!", Imagens.BEBE, ["Chorar"]);
                sair = true;
                break;
            }
        }
    }
}
else
{
    var _ = menu.PopUpLista("Durma bem. Amanhã é um novo dia para tentar", Imagens.CAMA, ["Voltar a dormir"]);
}




