namespace Fiap.Api.Entrega.ViewModel
{
    public class AgendaPaginacaoViewModel
    {
        public IEnumerable<AgendaViewModel> Agendamentos { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => Agendamentos.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/Agenda?pagina={CurrentPage - 1}&tamanho={PageSize}" : "";
        public string NextPageUrl => HasNextPage ? $"/Agenda?pagina={CurrentPage + 1}&tamanho={PageSize}" : "";

    }
}
