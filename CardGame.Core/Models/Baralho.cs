using CardGame.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Core.Models
{

    public class Baralho
    {
        private readonly List<Carta> _cartas;
        private readonly Random _random;

        public int CartasRestantes => _cartas.Count;

        public Baralho()
        {
            _random = new Random();
            _cartas = new List<Carta>();
            Inicializar();
        }

        private void Inicializar()
        {
            foreach (Naipe naipe in Enum.GetValues<Naipe>())
                foreach (Valor valor in Enum.GetValues<Valor>())
                    _cartas.Add(new Carta(naipe, valor));
        }

        public void Embaralhar()
        {
            for (int i = _cartas.Count - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                (_cartas[i], _cartas[j]) = (_cartas[j], _cartas[i]);
            }
        }

        public Carta Distribuir()
        {
            if (_cartas.Count == 0)
                throw new InvalidOperationException("O baralho está vazio.");

            Carta topo = _cartas[0];
            _cartas.RemoveAt(0);
            return topo;
        }

        public void Reiniciar()
        {
            _cartas.Clear();
            Inicializar();
            Embaralhar();
        }
    }
}
