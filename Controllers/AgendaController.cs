using AutoMapper;
using Fiap.Api.Entrega.Model;
using Fiap.Api.Entrega.Services;
using Fiap.Api.Entrega.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Fiap.Api.Entrega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaService _agendaService;
        private readonly IMapper _mapper;

        public AgendaController(IAgendaService agendaService, IMapper mapper)
        {
            _agendaService = agendaService;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<AgendaPaginacaoViewModel>> Get([FromQuery] int pagina = 1, [FromQuery] int tamanho = 5)
        {
            var listaPag = _agendaService.ListarAgenda(pagina, tamanho);
            var viewModelList = _mapper.Map<IEnumerable<AgendaViewModel>>(listaPag);

            var viewModel = new AgendaPaginacaoViewModel
            {
                Agendamentos = viewModelList,
                CurrentPage = pagina,
                PageSize = tamanho
            };


            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        public ActionResult<AgendaViewModel> Get(int id)
        {
            var modelId = _agendaService.BuscarAgendaPorId(id);

            if (modelId == null)
            {
                return NotFound();
            }
            else
            {
                var viewModel = _mapper.Map<AgendaViewModel>(modelId);
                return Ok(viewModel);
            }
        }



        [HttpPost]
        public ActionResult Post([FromBody] AgendaCreateViewModel agendaCreateViewModel)
        {
            var model = _mapper.Map<AgendaModel>(agendaCreateViewModel);
            _agendaService.CriarAgenda(model);
            //return Ok();
            return CreatedAtAction(nameof(Get), new { model.AgendaId }, model);
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] int id, [FromBody] AgendaViewModel viewModel)
        {
                 var model = _mapper.Map<AgendaModel>(viewModel);
                _agendaService.AtualizarAgenda(model);
                return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _agendaService.ApagaAgenda(id);    
            return NoContent(); 

        }

    }
}
