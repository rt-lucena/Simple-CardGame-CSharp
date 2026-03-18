using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Core.Models
{
    public class Dealer : Jogador
    {
        private const int LimiteParar = 17;

        public Dealer() : base("Dealer", int.MaxValue) { }

        public bool DevePedirCarta() => Mao.ObterValor() < LimiteParar;

        public Carta? ObterCartaVisivel() =>
            Mao.QuantidadeCartas >= 2 ? Mao.Cartas[1] : null;

        public override string ToString() =>
            $"Dealer | Carta visível: {ObterCartaVisivel()} | Mão completa: {Mao}";
    }
}