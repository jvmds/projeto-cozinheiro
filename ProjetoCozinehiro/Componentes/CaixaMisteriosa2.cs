using CozinheiroRpg.Componentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCozinheiro.Componentes;

public class CaixaMisteriosa2
{
    private int _pontos = 0;

    public int Execultar()
    {
        var txtIngrediente = new CaixaTexto();
        var reacao = "";
        var opcaoEscolhida = txtIngrediente.Executar(
                        """
                        Hmmmm, já senti o cheiro daqui, já imaginou onde para onde nós estamos indo ?!
                        Em Frankefurt alemanha, o famoso cachorro-quente alemão.
                        Sua missão é criar um tradicional cachorro-quente alemão, para isso escolha os ingredientes base.
                        """, "Pão, salsicha, molho de tomate e ketchup", "Pão de batata, feijoada e laranjada", "Salsicha,molho de tomate e batata-palha", "Frango assado e refrigerante diet,", "Pedir para algum parente cozinhar, já que não temos todos ingredientes", "Salsicha alemã, pão de cachorro de quente,molho de tomate e alho e sal");

        switch (opcaoEscolhida)
        {
            case 0:
                _pontos++;
                reacao = "Boa escolha, mas poderia ser melhor";
                break;
            case 1:
                reacao = "Ih rapaz, terá que voltar para faculdade de gastronomia";
                break;
            case 2:
                _pontos += 2;
                reacao = "Está fugindo da receita tradicional, mas podemos continuar";
                break;
            case 3:
                _pontos = -1;
                reacao = "https://www.youtube.com/watch?v=qwK9o9-Hk14";
                break;
            case 5:
                _pontos += 3;
                reacao = "Descobrimos uma novo ratatouille";
                break;
            default:
                _pontos = 0;
                reacao = "https://www.youtube.com/watch?v=pnlWzrZ1iOA";
                break;


        }
        if (_pontos == 0)
        {
            txtIngrediente.Executar($"Clique no link, {reacao} ", "Sair da tela");
            return _pontos;
        }
        if (_pontos == -1)
        {
            txtIngrediente.Executar($"Clique no link, {reacao} ", "Sair da tela");
            return _pontos;
        }

        opcaoEscolhida = txtIngrediente.Executar($"{reacao} Vamos lá, vamos cozinhar com nossos ingredientes, como devemos começar ?",
                        "Adicionar tudo na panela e aguarda a comida ficar pronto",
                        "Adicionar o alho com sal na panela, até ficar dourado e logo em seguida colocar a salsicha",
                        "Começar adorando o alho e cebola, aguardar 5 minutos, acrescentar o molho de tomate e logo depois acrescentar a salsicha",
                        "Imaginar tal preparação e aguardar");

        if (opcaoEscolhida is 0 or 1)
        {
            _pontos += opcaoEscolhida switch
            {
                0 => 0,
                1 => 2,
            };
            opcaoEscolhida = txtIngrediente.Executar(
                            "Parece que sua comida não está cozinhado corretamente?",
                            "Jogar mais água e aumentar a intensidade do fogo",
                            "Averiguar se o fogão está ligado, diminuir a intensidade do fogo e aguardar mais 10 minutos e repetir o processo todo novamente até cozinhar",
                            "Desisti de ser gastrônomo e vira NPC de rede socias");

            if (opcaoEscolhida == 2)
            {
                return 0;
            }

            reacao = "Ufa! Parece que você conseguiu reverter a situaçao.";
        }
        if (opcaoEscolhida == 3)
        {
            return 0;
        }

        opcaoEscolhida = txtIngrediente.Executar($"{reacao} Seu cachorro-quente está pronto, é hora de?",
                        "Preparar e comer ",
                        "Agradacer por não colocar fogo na cozinha");

        _pontos += opcaoEscolhida switch
        {
            0 => 2,
            _ => 1
        };
        return _pontos;
    }
}