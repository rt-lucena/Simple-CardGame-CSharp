using BlackJack.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Core.Models
{
    public class Carta
    {
        public Naipe Naipe { get; }
        public Valor Valor { get; }

        public Carta(Naipe naipe, Valor valor)
        {
            Naipe = naipe;
            Valor = valor;
        }

        public int ObterValorBlackJack()
        {
            return Valor switch
            {
                Valor.As => 11,
                Valor.Valete or Valor.Dama or Valor.Rei => 10,
                _ => (int)Valor
            };
        }

        public override string ToString() => $"{Valor} de {Naipe}";
    }
}