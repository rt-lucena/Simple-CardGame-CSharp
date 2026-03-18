using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Core.Models
{
    public class Jogador
    {
        public string Nome { get; }
        public Mao Mao { get; private set; }
        public int Fichas { get; private set; }
        public int ApostaAtual { get; private set; }

        public Jogador(string nome, int fichasIniciais = 1000)
        {
            Nome = nome;
            Fichas = fichasIniciais;
            Mao = new Mao();
        }

        public void Apostar(int valor)
        {
            if (valor <= 0)
                throw new ArgumentException("A aposta deve ser maior que zero.");
            if (valor > Fichas)
                throw new InvalidOperationException("Fichas insuficientes para essa aposta.");

            ApostaAtual = valor;
            Fichas -= valor;
        }

        public void ReceberGanhos(double multiplicador = 1.0)
        {
            int ganhos = (int)(ApostaAtual * (1 + multiplicador));
            Fichas += ganhos;
            ApostaAtual = 0;
        }

        public void DevolverAposta()
        {
            Fichas += ApostaAtual;
            ApostaAtual = 0;
        }

        public void ReiniciarMao()
        {
            Mao.Limpar();
            ApostaAtual = 0;
        }

        public override string ToString() =>
            $"{Nome} | Fichas: {Fichas} | Aposta: {ApostaAtual} | Mão: {Mao}";
    }
}