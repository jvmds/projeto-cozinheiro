using Objetos.Enums;

namespace Objetos
{
    public class Jogador
    {
        private readonly MiniGames _miniGame;
        public decimal ValorCarteira { get; protected set; }
        public Nivel Nivel { get; protected set; }
        public string Nome { get; protected set; }

        public Jogador(string nome, decimal valorCarteira = 0, Nivel nivel = Nivel.SemEstrela) 
        {
            Nome = nome;
            ValorCarteira = valorCarteira;
            Nivel = nivel;
            _miniGame = new MiniGames();
        }


        public void FazerComida()
        {
            var sair = false;

            do
            {
                Console.Clear();
                var resposta = _miniGame.MontarPrato();

                if (resposta)
                {
                    Console.WriteLine("Você acertou!");
                }
                else
                {
                    Console.WriteLine("Você errou!");
                }

                Console.WriteLine("Coloque [S] para tentar novamente ou qualquer outra coisa para sair");
                var op = Console.ReadLine();

                if (op == "S")
                {
                    sair = true;
                }
                else
                {
                    sair = false;
                }
            } while (sair);
        }
    }
}