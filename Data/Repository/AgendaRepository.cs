using Fiap.Api.Entrega.Data.Contexts;
using Fiap.Api.Entrega.Model;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Entrega.Data.Repository
{
    public class AgendaRepository : IAgendaRepository
    {

        private readonly DatabaseContext _context;

        public AgendaRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(AgendaModel agenda)
        {
            _context.Agendamentos.Add(agenda);
            _context.SaveChanges();
        }
        public IEnumerable<AgendaModel> GetAll() => _context.Agendamentos.ToList();


        public IEnumerable<AgendaModel> GetAll(int page, int size)
        {
            return _context.Agendamentos.Where(c => c.AgendaId > page)
                            .OrderBy(c => c.AgendaId).Skip((page - 1) * page)
                            .Take(size)
                            .AsNoTracking()
                            .ToList();
        }

        public AgendaModel GetById(int id) => _context.Agendamentos.Find(id);

        public void Update(AgendaModel agenda)
        {
            _context.Update(agenda);
            _context.SaveChanges();
        }

        public void Delete(AgendaModel agenda)
        {
            _context.Agendamentos.Remove(agenda);
            _context.SaveChanges();
        }

    }
}
