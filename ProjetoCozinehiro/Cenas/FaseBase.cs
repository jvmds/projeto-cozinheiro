using Common.Core;

namespace ProjetoCozinheiro.Cenas;

public class FaseBase
{
    public string Descricao { get; protected set; }
    protected Menu _menu;
    public int NivelReputacaoExigido { get; private set; }
    public FaseBase(Menu menu, int nivelReputacaoExigido)
    {
        _menu = menu;
        NivelReputacaoExigido = nivelReputacaoExigido;
        Descricao = "Fase base";
    }

    public virtual int Executar()
    {
        return _menu.PopUpLista("Cena base", ["Uma opção"]);
    }

    public virtual void Introducao()
    {
        var t = _menu.PopUpLista("Introdução", ["sair"]);
    }
}