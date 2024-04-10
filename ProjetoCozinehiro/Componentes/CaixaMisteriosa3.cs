using CozinheiroRpg.Componentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCozinheiro.Componentes;

public class CaixaMisteriosa3
{
    public class CaixaMisteriosa3
    {
        private int _pontos = 0;
    private int seconds = 0;
    private int minutes = 0;
        public int Execultar()
        {
            var txtIngrediente = new CaixaTexto();
            var reacao = "";
        var opcaoEscolhida = txtIngrediente.Executar(
                            """
                         Konichiwaaaaaaaaaaaa, já pensou a onde estamos, isso mesmo em Osaka no JAPÂO, já imaginou o prato que irá preparar ?!
                         Uma dica, pode ser mortal, isso mesmo o nome do prato e FUGU, que uma comida típica e extratamente perigosa se não for preparada corretamente
                     """, "Salmão, arroz e molho shoyu", "Peixe-leão, limão e pimenta ,", "Polvo de aneis azuis, alho e sal ", "Peixe-Baiacu, alho, limão e sal ", "Contratar um chef em comidas perigosas", "Tubarão branco e brasas de carvão acessas", "`Escopião, limão e molho de tomate");

                        Sua missão é criar um tradicional cachorro-quente, para isso escolha os ingredientes base.
                        """, "batata frita e carne cozida", "Salsicha branca, Curry em pó e Pão de cachorro-quente", "Pimenta calabresa", "Pão de cachorro quente e Catchup");

            switch (opcaoEscolhida)
            {

            case 3:
                    _pontos += 3;
                reacao = "Já temos os ingredientes necessários";
                    break;
            case 4:
                _pontos = 0;
                reacao = "https://www.youtube.com/watch?v=qwK9o9-Hk14";
                    break;

                default:
                reacao = "Errou";
                    break;

            }
        if (_pontos == 0)
        {
            txtIngrediente.Executar($"Clique no link, {reacao} ", "Sair da tela");
            return _pontos;
        }

        opcaoEscolhida = txtIngrediente.Executar($"{reacao} Vamos lá, vamos começar a cortar o baiacu, se não for cortado corretamente você perde, qual o passo adiante que deve seguir ?",
                        "Pegar seus equipamentos como faca de corte preciso",
                        "Utilizar uma espada para cortar",
                        "Utilizar um bisturi",
                        "Faca tramontina");

        if (opcaoEscolhida == 0)
            {
            var cont = 0;
            txtIngrediente.Executar("Chegamos a etapa do corte, muito cuidado tem que acertar o corte no tempo limite e preciso, digite as teclas que vai aparecer na sua tela no tempo limite", "Começar agora");
            List<string> ListaDeComandos = new List<string>()
                {

                 "Corte a Esquerda", "Corte Abaixo", "Corte a Acima", "Corte a Direita"
                };
            Random random = new Random();
            var timer = new Stopwatch();
            timer.Start();
            int pnts = 0;
            while (cont <= 4)
            {
                var valoraleatorio = ListaDeComandos[random.Next(ListaDeComandos.Count())];
                var index = ListaDeComandos.IndexOf(valoraleatorio);
                int indexAnterior = (index - 1 + ListaDeComandos.Count) % ListaDeComandos.Count;
                int indexProximo = (index + 1) % ListaDeComandos.Count;
                int valorescolhido = txtIngrediente.Executar($" Escolha a palavra ({valoraleatorio}) \nSeu tempo limite e 15 segundos, tempo {timer.Elapsed.Seconds} segundos ", ListaDeComandos[indexAnterior], valoraleatorio, ListaDeComandos[indexProximo]);

                if (valorescolhido == 1)
                {
                    _pontos++;
                }
                if (valorescolhido != 1)
                {
                    _pontos -= 1;
                }
                cont++;


            };
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            seconds = timeTaken.Seconds;
            minutes = timeTaken.Minutes;
            if (seconds >= 15 || minutes >= 1)
            {
                return _pontos = 0;
            }
        }
        if (_pontos <= 4)
        {
            return _pontos;
            }
        if (_pontos >= 5 && seconds <= 15 && minutes == 0)
            {
            reacao = "Otimo, você cortou o baiacu corretamente, ";
            opcaoEscolhida = txtIngrediente.Executar($"{reacao} está pronto seu fugu, é hora de?",
                        "Apreciar com moderação ",
                        "Saborear com calma, caso não esteja cortado corretamente");
            }

            opcaoEscolhida = txtIngrediente.Execultar($"{reacao} Seu molho está pronta, é hora de?",
                            "Cortar os pão e colocar a salsicha com o molho.",
                            "Deixar esfriar um pouco e deixar o molho na panela.");

            _pontos += opcaoEscolhida switch
            {
            0 => 2,
            _ => 1
            };

            return _pontos;
        }

}
