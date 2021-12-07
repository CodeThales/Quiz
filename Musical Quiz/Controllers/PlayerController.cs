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


        /// <summary>
        /// Returns a list of all players.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index() => ApiOk(_service.All());


        /// <summary>
        /// Returns a player fetched by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Index(int? id)
        {
            if (id <= 0 || id > _service.PlayerList())
                return ApiNotFound("Não encontramos este jogador em nosso banco de dados.");
            else return ApiOk(_service.Get(id));
        }


        /// <summary>
        /// Creates a new player.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] Player player)
        {
            return _service.Create(player) ?
                ApiOk(player, "Jogador cadastrado com sucesso.") :
                ApiNotFound("Erro ao tentar cadastrar jogador.");
        }


        /// <summary>
        /// Updates a player.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update([FromBody] Player player)
        {
            return _service.Update(player) ?
                ApiOk(player, "Jogador atualizado com sucesso.") :
                ApiNotFound("Erro ao tentar atualizar jogador.");
        }


        /// <summary>
        /// Delete a player.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int? id) =>
            _service.Delete(id) ?
            ApiOk("Jogador excluído com sucesso.") :
            ApiNotFound("Erro ao excluir jogador.");
    }
}
