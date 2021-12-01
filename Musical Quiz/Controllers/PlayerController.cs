using Microsoft.AspNetCore.Mvc;
using Musical_Quiz.Models;
using Musical_Quiz.Services;

namespace Musical_Quiz.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : APIBaseController
    {
        IPlayerService _service;

        public PlayerController(IPlayerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index() => ApiOk(_service.All());

        [HttpGet]
        [Route("{id}")]
        public IActionResult Index(int? id)
        {
            if (id <= 0 || id > _service.PlayerList())
                return ApiNotFound("Não encontramos este jogador em nosso banco de dados.");
            else return ApiOk(_service.Get(id));
        }



        [HttpPost]
        public IActionResult Create([FromBody] Player player)
        {
            return _service.Create(player) ?
                ApiOk(player, "Jogador cadastrado com sucesso.") :
                ApiNotFound("Erro ao tentar cadastrar jogador.");
        }

        [HttpPut]
        public IActionResult Update([FromBody] Player player)
        {
            return _service.Update(player) ?
                ApiOk(player, "Jogador atualizado com sucesso.") :
                ApiNotFound("Erro ao tentar atualizar jogador.");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int? id) =>
            _service.Delete(id) ?
            ApiOk("Jogador excluído com sucesso.") :
            ApiNotFound("Erro ao excluir jogador.");
    }
}
