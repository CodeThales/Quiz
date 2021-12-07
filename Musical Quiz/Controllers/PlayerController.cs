using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Musical_Quiz.Models;
using Musical_Quiz.Services;
using System.Net.Mime;

namespace Musical_Quiz.Controllers
{
    /// <summary>
    /// PlayerController inherits pattern responses from APIBaSeController.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class PlayerController : APIBaseController
    {
        IPlayerService _service;

        /// <summary>
        /// PlayerController builder instantiating the service responsible for player methods.
        /// </summary>
        /// <param name="service"></param>
        public PlayerController(IPlayerService service)
        {
            _service = service;
        }


        /// <summary>
        /// Returns a list of all players.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Index() => ApiOk(_service.All());


        /// <summary>
        /// Returns a player fetched by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status201Created)]        
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int? id) =>
            _service.Delete(id) ?
            ApiOk("Jogador excluído com sucesso.") :
            ApiNotFound("Erro ao excluir jogador.");
    }
}
