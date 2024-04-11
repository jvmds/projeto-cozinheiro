using CozinheiroRpg.Componentes;

namespace ProjetoCozinheiro.Componentes;

public static class Introducao
{
    public static string Imagem = """
                                          .--,--.                   
                                          `.  ,.'                   
                                           |___|                    
                                           :o o:   O    OLÁ JOGADOR!
                                          _`~^~'_  |                
                                        /'   ^   `\=)               
                                      .'  _______ '~|               
                                      `(<=|     |= /'               
                                          |     |                   
                                          |_____|                   
                                   ~~~~~~~ ===== ~~~~~~~~           
                             """;

    public static string Texto = """
                                 Você é um recém-formado em gastronomia e tem o objetivo de se tornar o campeão do maior campeonato de culinária do mundo, o Rei da Cozinha. Para alcançar esse feito, será necessário dominar habilidades únicas no preparo de alimentos você está preparado?
                                 """;

    public static List<string> Opcoes = new() { "Seguir", "Não Seguir" };
}