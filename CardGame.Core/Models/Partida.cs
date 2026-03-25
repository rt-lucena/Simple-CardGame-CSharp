using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardGame.Core.Enums;

namespace CardGame.Core.Models
{
    public class Partida
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime DataInicio { get; } = DateTime.Now;

        public IReadOnlyList<Jogador> Jogadores { get; }
        public Resultado? Resultado { get; private set; }
        public Jogador? Vencedor { get; private set; }

        public bool Finalizada => Resultado.HasValue;

        public Partida(IEnumerable<Jogador> jogadores)
        {
            var lista = jogadores.ToList();
            if (lista.Count < 2)
                throw new ArgumentException("Uma partida exige ao menos 2 jogadores.");

            Jogadores = lista.AsReadOnly();
        }

        public void Finalizar(Resultado resultado, Jogador? vencedor = null)
        {
            if (Finalizada)
                throw new InvalidOperationException("Partida já foi finalizada.");

            if (resultado != Enums.Resultado.Empate && vencedor == null)
                throw new ArgumentException("Informe o vencedor quando o resultado não é empate.");

            if (vencedor != null && !Jogadores.Contains(vencedor))
                throw new ArgumentException("Vencedor não pertence a esta partida.");

            Resultado = resultado;
            Vencedor = vencedor;
        }

        public override string ToString()
        {
            string res = !Finalizada ? "Em andamento"
                       : Vencedor != null ? $"Vencedor: {Vencedor.Nome}"
                                            : "Empate";

            return $"Partida {Id} | {DataInicio:dd/MM/yyyy HH:mm} | " +
                   $"Jogadores: {string.Join(", ", Jogadores.Select(j => j.Nome))} | {res}";
        }
    }
}
