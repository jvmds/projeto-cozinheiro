using System;
using CozinheiroRpg.Componentes;
using ProjetoCozinheiro.Componentes;

var caixaTexto = new CaixaTexto();
var menuInicial = new MenuInicial();
menuInicial.Execultar();

var opcao = caixaTexto.Executar(Introducao.Texto, Introducao.Imagem, Introducao.Opcoes.ToArray());

if (opcao == 0)
{
    Console.Clear();
    Console.WriteLine("Seguir");
    
    
    opcao = caixaTexto.Executar(
                    """
                    Bem-vindo ao extraordinário evento de culinária REI DA COZINHA! Aqui, chefs renomados de todo o mundo se
                    reúnem para descobrir QUEM É O MELHOR! Prepare-se para uma jornada gastronômica emocionante, onde cada
                    prato conta uma história e cada sabor é uma aventura única!

                    Diante de você, três caixas misteriosas aguardam sua escolha. Que comece a aventura culinária!
                    """, "Caixa Misteriosa 1", "Caixa Misteriosa 2", "Caixa Misteriosa 3");
    
    if (opcao == 0)
    {
        var caixa1 = new CaixaMisteriosa1();
        opcao = caixa1.Execultar();

        if (opcao >= 6)
        {
            var telaVitoria = new TelaVitoria();
            telaVitoria.Execultar();
        }
    }
    else
    {
        throw new NotImplementedException();
    }
}
else
{
    Console.Clear();
    Console.WriteLine("Terminar o jogo");
}

