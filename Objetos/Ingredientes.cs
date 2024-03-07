namespace Objetos
{
    public class Ingredientes
    {
        public string Nome { get; protected set; }
        public int Quantidade { get; protected set; }
        public bool Correto { get; protected set; }

        public Ingredientes(string nome, int quantidade, bool correto) 
        {
            Quantidade = quantidade;
            Nome = nome;
            Correto = correto;
        }
    }
}
