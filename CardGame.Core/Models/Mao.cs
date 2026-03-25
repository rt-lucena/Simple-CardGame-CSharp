using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Core.Models
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

        public int ObterPontuacao(Func<Carta, int> calcularPontuacao)
        {
            return _cartas.Sum(calcularPontuacao);
        }

        public void Limpar() => _cartas.Clear();

        public override string ToString() => string.Join(", ", _cartas);
    }
}
