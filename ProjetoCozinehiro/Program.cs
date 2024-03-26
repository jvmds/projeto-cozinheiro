using CozinheiroRpg.Componentes;

var menuInicial = new MenuInicial();
menuInicial.Execultar();
var caixaTexto = new CaixaTexto();
var opcao = caixaTexto.Execultar(
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