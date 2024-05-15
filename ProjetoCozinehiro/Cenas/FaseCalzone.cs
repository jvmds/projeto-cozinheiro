using Common.Core;
using ProjetoCozinheiro.Common;

namespace ProjetoCozinheiro.Cenas;

public class FaseCalzone : FaseBase
{
    public FaseCalzone(Menu menu, int nivelReputacaoExigido)
                    : base(menu, nivelReputacaoExigido)
    {
        Descricao = $"Zezinho Cazone (Itália) [Reputação exigida: {nivelReputacaoExigido}]";
    }
    public override int Executar()
    {
        Introducao();
        int pontos = 0;
        var reacao = "";
        var opcao = _menu.PopUpLista("""
                                            O Calzone serviu de inspiração para a Pizza tradicional e sua origem tem 
                                            início na região italiana da Apúlia, na zona de Salento. Sua receita correta
                                            é feita com a massa da pizza tradicional.
                                            Sua missão é derrotar Zezinho Cozinheiro, para isso precisará fazer um 
                                            tradicional calzone!
                                            Escolha com muito cuidado os engredientes base de sua receita, uma escolha 
                                            errada poderá leva-lo a derrota!
                                            """,
        [
                        "Presunto, mussarela e Catupiry", "Calabresa e mussarela", "Calabresa e Catupiry",
                        "Frango e Catupiry"
        ]);
        
        switch (opcao)
        {
            case 1:
                pontos += 30;
                reacao = "Muito Bem! Excelente escolha.";
                break;
            case 2:
                pontos += 20;
                reacao = "Não é excelente, mas inda é uma boa escolha!";
                break;
            case 3:
                pontos += 10;
                reacao = "No limite do tradicional.";
                break;
            default:
                reacao = "Tome cuidao para não fugir da receita tradicional!";
                break;
        }

        opcao = _menu.PopUpLista($"{reacao} Vamos lá, você está batento a farinha, o sal e o " +
                                 $"fermento e está jogando água. O que fará agora?",
        [
                        "Aumenta a velocidade da batedeira e joga água aos poucos",
                        "Diminui a velocidade da batedeira e joga toda a água", 
                        "Diminui a velocidade da batedeira e joga a água gradualmente"
        ]);
        
        if (opcao is 1 or 2)
        {
            pontos += opcao switch
            {
                            1 => 20,
                            _ => 0,
            };
            opcao = _menu.PopUpLista("Parece que sua massa não está chegando no ponto o que você fará?",
                            [
                                            "Diminuir a velocidade da batedeira e jogar a água gradualmente",
                                            "Jogar mais água"
                            ]);

            if (opcao == 1)
            {
                return 0;
            }

            reacao = "Ufa! Parece que você conseguiu reverter a situaçao.";
        }
        else
        {
            reacao = "Excelente! Você está indo muito bem.";
            pontos += 30;
        }
        
        opcao = _menu.PopUpLista($"{reacao} Sua massa está pronta, é hora de?", 
                        [
                                        "Deixar descansar, depois colocar o recheio e por fim levar ao forno.", 
                                        "Colocar o recheio e levar ao forno."
                        ]);
        pontos += opcao switch
        {
                        1 => 40,
                        _ => 20
        };
        
        return pontos;
    }

    public override void Introducao()
    {
        var _ = _menu.PopUpLista("Você está prestes a enfrentar Zezinho Cozinheiro, um renomado chef de " +
                                 "cozinha italiano, 7 vezes ganhador do Rei da Cozinha com seu inigualável calzone " +
                                 "tradicional! Zezinho Cozinheiro perguntou se você está preparado para a derrota?", 
                        Imagens.AVIAO, 
                        ["Continuar"]);
    }
}