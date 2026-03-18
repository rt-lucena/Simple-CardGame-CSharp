using BlackJack.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Core.Models
{
    public class Rodada
    {
        private readonly Baralho _baralho;

        public Jogador Jogador { get; }
        public Dealer Dealer { get; }
        public Resultado? ResultadoFinal { get; private set; }
        public bool Encerrada { get; private set; }

        public Rodada(Jogador jogador, Dealer dealer, Baralho baralho)
        {
            Jogador = jogador;
            Dealer = dealer;
            _baralho = baralho;
        }

        public void Distribuir()
        {
            Jogador.ReiniciarMao();
            Dealer.ReiniciarMao();

            Jogador.Mao.AdicionarCarta(_baralho.Distribuir());
            Dealer.Mao.AdicionarCarta(_baralho.Distribuir());
            Jogador.Mao.AdicionarCarta(_baralho.Distribuir());
            Dealer.Mao.AdicionarCarta(_baralho.Distribuir());

            if (Jogador.Mao.EhBlackjack())
            {
                ResultadoFinal = Resultado.Blackjack;
                Encerrada = true;
                Jogador.ReceberGanhos(1.5);
            }
        }

        public void PedirCarta()
        {
            if (Encerrada)
                throw new InvalidOperationException("Esta rodada já foi encerrada.");

            Jogador.Mao.AdicionarCarta(_baralho.Distribuir());

            if (Jogador.Mao.Estourou())
            {
                ResultadoFinal = Resultado.DealerVenceu;
                Encerrada = true;
            }
        }

        public void Parar()
        {
            if (Encerrada)
                throw new InvalidOperationException("Esta rodada já foi encerrada.");

            while (Dealer.DevePedirCarta())
                Dealer.Mao.AdicionarCarta(_baralho.Distribuir());

            ResultadoFinal = DeterminarResultado();
            Encerrada = true;
            AplicarResultado();
        }

        private Resultado DeterminarResultado()
        {
            int valorJogador = Jogador.Mao.ObterValor();
            int valorDealer = Dealer.Mao.ObterValor();

            if (Dealer.Mao.Estourou()) return Resultado.JogadorVenceu;
            if (valorJogador > valorDealer) return Resultado.JogadorVenceu;
            if (valorJogador < valorDealer) return Resultado.DealerVenceu;
            return Resultado.Empate;
        }

        private void AplicarResultado()
        {
            switch (ResultadoFinal)
            {
                case Resultado.JogadorVenceu:
                    Jogador.ReceberGanhos(1.0);
                    break;
                case Resultado.Empate:
                    Jogador.DevolverAposta();
                    break;
            }
        }
    }
}