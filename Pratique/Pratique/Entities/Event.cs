using System.Collections.Specialized;

namespace Pratique.Entities
{
    public class Event
    {
        public Event()
        {
            Inscritos = new List<EventInscrito>();
            Ativo = false;
        }
        public Guid Id { get; set; }

        public string NomeEvento { get; set; }

        public string DescricaoEvento { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public List<EventInscrito> Inscritos { get; set; }

        public bool Ativo { get; set; }

        public void Update(string nomeEvento, string descricaoEvento, DateTime dataInicio, DateTime dataFim)
        {
            NomeEvento = nomeEvento;
            DescricaoEvento = descricaoEvento;
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        public void Delete()
        {
            Ativo = true;
        }
    }
}
