using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Core.Models
{
    public class Historico
    {
        private readonly List<Partida> _partidas = new();

        public IReadOnlyList<Partida> Partidas => _partidas.AsReadOnly();

        public void Registrar(Partida partida)
        {
            if (!partida.Finalizada)
                throw new InvalidOperationException("Só é possível registrar partidas finalizadas.");

            if (_partidas.Any(p => p.Id == partida.Id))
                throw new InvalidOperationException("Partida já registrada.");

            _partidas.Add(partida);
        }

        public IReadOnlyList<Partida> ObterPartidasDoJogador(string nome) =>
            _partidas
                .Where(p => p.Jogadores.Any(j => j.Nome == nome))
                .ToList()
                .AsReadOnly();

        public IReadOnlyList<Partida> ObterVitoriasDoJogador(string nome) =>
            _partidas
                .Where(p => p.Vencedor?.Nome == nome)
                .ToList()
                .AsReadOnly();

        public override string ToString()
        {
            if (_partidas.Count == 0)
                return "Nenhuma partida registrada.";

            return string.Join(Environment.NewLine, _partidas);
        }
    }
}
