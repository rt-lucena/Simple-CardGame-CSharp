using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Core.Models
{
    public class Mao
    {
        private readonly List<Carta> _cartas;

        public IReadOnlyList<Carta> Cartas => _cartas.AsReadOnly();
        public int QuantidadeCartas => _cartas.Count;

        public Mao()
        {
            _cartas = new List<Carta>();
        }

        public void AdicionarCarta(Carta carta)
        {
            _cartas.Add(carta);
        }

        public int ObterValor()
        {
            int total = 0;
            int contadorAs = 0;

            foreach (var carta in _cartas)
            {
                total += carta.ObterValorBlackJack();
                if (carta.ObterValorBlackJack() == 11)
                    contadorAs++;
            }

            while (total > 21 && contadorAs > 0)
            {
                total -= 10;
                contadorAs--;
            }

            return total;
        }

        public bool Estourou() => ObterValor() > 21;

        public bool EhBlackjack() => QuantidadeCartas == 2 && ObterValor() == 21;

        public void Limpar() => _cartas.Clear();

        public override string ToString() =>
            string.Join(", ", _cartas) + $" (Total: {ObterValor()})";
    }
}