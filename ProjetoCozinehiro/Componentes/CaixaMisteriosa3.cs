using CozinheiroRpg.Componentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCozinheiro.Componentes;

public class CaixaMisteriosa3
{
    public class CaixaMisteriosa3
    {
        private int _pontos = 0;

        public int Execultar()
        {
            var txtIngrediente = new CaixaTexto();
            var reacao = "";
            var opcaoEscolhida = txtIngrediente.Execultar(
                            """
                         Olha, Olha, Olha! Sua segunda missão e na Alemanha! Com um prato que serviu de inspiração
                        para a cachorro-quente tradicional, conseguiu adivinhar qual é? Não? Não se preocupe que eu te conto.
                        Estamos falando do Cachorro-Quente, essa delicia tem origem na região  da Alemanha, na zona de
                        FrankFurt. Sua receita correta é feita com a salsicha alemã.

                        Sua missão é criar um tradicional cachorro-quente, para isso escolha os ingredientes base.
                        """, "batata frita e carne cozida", "Salsicha branca, Curry em pó e Pão de cachorro-quente", "Pimenta calabresa", "Pão de cachorro quente e Catchup");

            switch (opcaoEscolhida)
            {
                case 1:
                    _pontos += 3;
                    reacao = "Muito Bem! Excelente escolha.";
                    break;
                case 2:
                    _pontos++;
                    reacao = "No limite do tradicional.";
                    break;
                case 3:
                    _pontos += 2;
                    reacao = "Não é excelente, mas inda é uma boa escolha!";
                    break;
                default:
                    reacao = "Tome cuidao para não fujir da receita tradicional!";
                    break;
            }

            opcaoEscolhida = txtIngrediente.Execultar($"{reacao} Vamos lá, você está fazendo o molho do cachorro-quente, o sal e o molho de tomate e está jogando água. O que fará agora?",
                            "Joga tudo na panela de uma vez",
                            "Começa adorando o alho e cebola e logo em seguida acrescenta molho de tomate e esperar 10 minutos até cozinhar",
                            "Diminui a velocidade  de produção do molho e espera fritar o alho e cebola e logo em seguida começa a cozinhar o molho pra acrescentar junto ao demais ingredientes");

            if (opcaoEscolhida is 0 or 2)
            {
                _pontos += opcaoEscolhida switch
                {
                    1 => 2,
                    _ => 0,
                };
                opcaoEscolhida = txtIngrediente.Execultar(
                                "Parece que seu molho está ficando ensopado, oque fará ?",
                                "Retire um pouco do molho e deixe fevervendo no fogo baixo",
                                "Aumente a velocidade de cozimento do molho (aumentando o fogo do fogão)"
                                );

                if (opcaoEscolhida == 1)
                {
                    return 0;
                }

                reacao = "Ufa! Parece que você conseguiu reverter a situaçao.";
            }
            else
            {
                reacao = "Excelente! Você está indo muito bem.";
                _pontos += 3;
            }

            opcaoEscolhida = txtIngrediente.Execultar($"{reacao} Seu molho está pronta, é hora de?",
                            "Cortar os pão e colocar a salsicha com o molho.",
                            "Deixar esfriar um pouco e deixar o molho na panela.");

            _pontos += opcaoEscolhida switch
            {
                0 => 4,
                _ => 2
            };

            return _pontos;
        }
    }
}
