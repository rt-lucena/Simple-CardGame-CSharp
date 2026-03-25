using CardGame.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Core.Models
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

        public override string ToString() => $"{Valor} de {Naipe}";
    }
}
