using Fiap.Api.Entrega.Model;

namespace Fiap.Api.Entrega.Data.Repository
{
    public interface IAgendaRepository
    {
        void Add(AgendaModel agenda);

        IEnumerable<AgendaModel> GetAll();

        IEnumerable<AgendaModel> GetAll(int page, int size);

        AgendaModel GetById(int id);
        
        void Update(AgendaModel agenda);

        void Delete(AgendaModel agenda);

    }
}
