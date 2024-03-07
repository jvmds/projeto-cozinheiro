namespace Objetos
{
    public class MiniGames
    {
        private readonly Random _rand = new();
        private readonly List<Prato> _listaPratos = new() 
        {
            new Prato("Pizza", new List<Ingredientes> { 
                new Ingredientes("Fermento", 2, true), new Ingredientes("Farinha", 2, true), new Ingredientes("Café", 2, false), new Ingredientes("Arroz", 2, false)})
        };


        public bool MontarPrato()
        {
            var prato = _listaPratos[_rand.Next(0, _listaPratos.Count - 1)];
            var opcoes = new Dictionary<int, Ingredientes>();

            Console.WriteLine($"Quais dos ingredientes abaixo são necessários para fazer um(a) {prato.Nome}?");
            
            for (int i = 0; i < prato.Ingredientes.Count; i++)
            {
                Console.WriteLine($"{i}) {prato.Ingredientes[i].Nome}");
                opcoes[i] = prato.Ingredientes[i];
            }

            Console.WriteLine("Indique os números que corresponde as opções corretas (use espaço para separar as opções)");

            var resposta = Console.ReadLine();
            var opcoesSelecionadas = resposta.Split(" ");

            var resultado = 0;
            foreach (var o in opcoesSelecionadas)
            {
                if (opcoes[int.Parse(o)].Correto)
                {
                    resultado++;
                }
                else
                {
                    return false;
                }
            }

            return resultado == opcoes.Values.Where(f => f.Correto == true).Count();
        }

        public bool ShowDoMilhao()
        {
            throw new NotImplementedException();
        }
    }
}
