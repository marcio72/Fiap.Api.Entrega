using Fiap.Api.Entrega.Model;

namespace Fiap.Api.Entrega.Services
{
    public interface IAgendaService
    {
        void CriarAgenda(AgendaModel agenda);

        IEnumerable<AgendaModel> ListarAgenda();
        IEnumerable<AgendaModel> ListarAgenda(int pagina = 0, int tamanho = 5);

        AgendaModel BuscarAgendaPorId(int id);
     
        void AtualizarAgenda(AgendaModel agenda);

        void ApagaAgenda(int id);


    }
}
