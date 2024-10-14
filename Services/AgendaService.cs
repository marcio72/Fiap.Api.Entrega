using Fiap.Api.Entrega.Data.Repository;
using Fiap.Api.Entrega.Model;
using static Fiap.Api.Entrega.Services.AgendaService;

namespace Fiap.Api.Entrega.Services
{
    
        public class AgendaService : IAgendaService
        {
            private readonly IAgendaRepository _repository;
            

            public AgendaService(IAgendaRepository repository)
            {
                _repository = repository;
            }

            public void CriarAgenda(AgendaModel agenda) => _repository.Add(agenda);

            public IEnumerable<AgendaModel> ListarAgenda() => _repository.GetAll();


        public IEnumerable<AgendaModel> ListarAgenda(int pagina = 1, int tamanho = 5)
        {
            return _repository.GetAll(pagina, tamanho);
        }



        public AgendaModel BuscarAgendaPorId(int id) => _repository.GetById(id);

            public void AtualizarAgenda(AgendaModel agenda) => _repository.Update(agenda);

            public void ApagaAgenda(int id)
            {
                var agenda = _repository.GetById(id);
                if (agenda != null)
                {
                    _repository.Delete(agenda);
                }
            }

        }

    }

