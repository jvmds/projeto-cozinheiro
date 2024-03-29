namespace CozinheiroRpg.Componentes;

public class CaixaMisteriosa1
{
    private int _pontos = 0;
    
    public int Execultar()
    {
        var txtIngrediente = new CaixaTexto();
        var reacao = "";
        var opcaoEscolhida = txtIngrediente.Execultar(
                        """
                         Olha, Olha, Olha! Sua primeira missão inicia na Itália! Com um prato que serviu de inspiração
                        para a Pizza tradicional, conseguiu adivinhar qual é? Não? Não se preocupe que eu te conto.
                        Estamos falando do CALZONE, essa delicia tem origem na região italiana da Apúlia, na zona de
                        Salento. Sua receita correta é feita com a massa da pizza tradicional.

                        Sua missão é criar um tradicional calzone, para isso escolha os ingredientes base.
                        """, "Presunto, mussarela e Catupiry", "Calabresa e mussarela", "Calabresa e Catupiry", "Frango e Catupiry");

        switch (opcaoEscolhida)
        {
            case 0:
                _pontos += 3;
                reacao = "Muito Bem! Excelente escolha.";
                break;
            case 1:
                _pontos += 2;
                reacao = "Não é excelente, mas inda é uma boa escolha!";
                break;
            case 2:
                _pontos++;
                reacao = "No limite do tradicional.";
                break;
            default:
                reacao = "Tome cuidao para não fujir da receita tradicional!";
                break;
        }
        
        opcaoEscolhida = txtIngrediente.Execultar($"{reacao} Vamos lá, você está batento a farinha, o sal e o fermento e está jogando água. O que fará agora?", 
                        "Aumenta a velocidade da batedeira e joga água aos poucos", 
                        "Diminui a velocidade da batedeira e joga toda a água", 
                        "Diminui a velocidade da batedeira e joga a água gradualmente");

        if (opcaoEscolhida is 0 or 1)
        {
            _pontos += opcaoEscolhida switch
            {
                            0 => 2,
                            _ => 0,
            };
            opcaoEscolhida = txtIngrediente.Execultar(
                            "Parece que sua massa não está chegando no ponto o que você fará?",
                            "Diminuir a velocidade da batedeira e jogar a água gradualmente",
                            "Jogar mais água");

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
        
        opcaoEscolhida = txtIngrediente.Execultar($"{reacao} Sua massa está pronta, é hora de?", 
                        "Deixar descansar, depois colocar o recheio e por fim levar ao forno.", 
                        "Colocar o recheio e levar ao forno.");

        _pontos += opcaoEscolhida switch
        {
                        0 => 4,
                        _ => 2
        };

        return _pontos;
    }
}