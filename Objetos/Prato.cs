namespace Objetos
{
    public class Prato
    {
        public string Nome { get; protected set; }
        public List<Ingredientes> Ingredientes { get; protected set; }

        public Prato(string nome, List<Ingredientes> ingredientes)
        {
            Nome = nome;
            Ingredientes= ingredientes;
        }
    }
}
