using ProjetoCozinheiro.Cenas;
using ProjetoCozinheiro.MiniJogos;

namespace ProjetoCozinheiro.Componentes;

public class Inicio
{
    private Jogador _jogador = new();

    private List<FaseBase> _fases = new()
    {
        new FaseCalzone(50, 80),
        new FaseCachorroQuente(100, 90),
        new FaseSair()
    };
    
    private List<MiniJogos.MiniJogos> _miniJogos = new()
    {
                    new MiniJogoTempo()
    };

    public void Iniciar()
    {
        var introducao = TelaApresentacao();
        var escolha = introducao();

        if (escolha == OpcoesMenu.Sim)
        {
            while (true)
            {
                escolha = MenuPrincipal();

                if (escolha == OpcoesMenu.Sair)
                {
                    break;
                }
                
                _jogador.Reputacao += escolha switch
                {
                                OpcoesMenu.MiniJogos => MiniJogos(),
                                OpcoesMenu.Fases => Fases(),
                                _ => throw new Exception("Opção não implementada")
                };
            }
        }
        else
        {
            Sair();
        }
    }

    private Func<OpcoesMenu> TelaApresentacao()
    {
        var tela = new Menu<Func<OpcoesMenu>>("Versão: 1.0.0", Imagens.LOGO, new Dictionary<string, Func<OpcoesMenu>>
        {
                        { "Iniciar", Introducao }
        });

        return tela.Mostrar()!;
    }

    private OpcoesMenu Introducao()
    {
        var tela = new Menu<OpcoesMenu>($"Reputação: {_jogador.Reputacao}",
                        $"{Imagens.CHEF} \n" + 
                            "Você é um chefe de cozinha em crescimento que pretende viajar o mundo e enfrentar os " + 
                            "melhores cozinheiros e assim se tornar o maior cozinheiro do mundo!", 
                        new Dictionary<string, OpcoesMenu>
        {
                        { "Vamos nessa!", OpcoesMenu.Sim },
                        { "Vou voltar a dormir", OpcoesMenu.Nao }
        });

        return tela.Mostrar();
    }
    
    private OpcoesMenu MenuPrincipal()
    {
        var tela = new Menu<OpcoesMenu>($"REPUTAÇÃO ATUAL: {_jogador.Reputacao}", 
                        "Escolha o que você quer fazer agora. ", 
                        new Dictionary<string, OpcoesMenu>
        {
                        { "Aumentar reputação (Mini jogos)", OpcoesMenu.MiniJogos },
                        { "Meter o doido e ir para cima do adversários!", OpcoesMenu.Fases },
                        { "Desistir de tudo e ir dormir", OpcoesMenu.Sair }
                        
        });
        
        return tela.Mostrar();
    }

    private int MiniJogos()
    {
        var rand = new Random();
        var miniJogo = _miniJogos[rand.Next(0, _miniJogos.Count)];
        
        return miniJogo.Executar(_jogador.Reputacao);
    }
    
    private int Fases()
    {
        var fases = new Dictionary<string, FaseBase>();
        foreach (var f in _fases)
        {
            fases[f.Descricao] = f;
        }
        
        var tela = new Menu<FaseBase>($"REPUTAÇÃO ATUAL: {_jogador.Reputacao}", 
                        "Escolha seu adversário!", 
                        fases);

        var faseSelecionada = tela.Mostrar();

        if (faseSelecionada.ReputacaoExigida > _jogador.Reputacao)
        {
            return TelaBloqueado();
        }
        
        faseSelecionada.Executar();
        
        return faseSelecionada.Pontuacao;
    }
    
    private void Sair()
    {
        var tela = new Menu<OpcoesMenu>("Você é um bebê chorão!", 
                        Imagens.BEBE, 
                        new Dictionary<string, OpcoesMenu>
                        {
                                        { "Chorar!", OpcoesMenu.Sair },
                        });

        _ = tela.Mostrar();
    }
    
    private int TelaBloqueado()
    {
        var tela = new Menu<int>($"REPUTAÇÃO ATUAL: {_jogador.Reputacao}", 
                        "Cresça antes de querer me enfrentar!", 
                        new Dictionary<string, int>
                        {
                                        { "Voltar!", 0 },
                        });

        return tela.Mostrar();
    }

}