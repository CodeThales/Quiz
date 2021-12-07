using Microsoft.AspNetCore.Mvc;
using Musical_Quiz.Models;
using Musical_Quiz.Services;

namespace Musical_Quiz.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerAnswersController : APIBaseController
    {
        IPlayerAnswersService _service;

        public PlayerAnswersController(IPlayerAnswersService service)
        {
            _service = service;
        }


        /// <summary>
        /// Returns a list of all player response.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index() => ApiOk(_service.All());


        /// <summary>
        /// Ruturns a player response fetched by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Index(int? id)
        {
            if (id <= 0 || id > _service.PlayerAnswersList())
                return ApiNotFound("Não encontramos esta resposta em nosso banco de dados.");
            else return ApiOk(_service.Get(id));
        }


        /// <summary>
        /// Creates a new player response.
        /// </summary>
        /// <param name="playerAnswers"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] PlayerAnswers playerAnswers)
        {
            return _service.Create(playerAnswers) ?
                ApiOk(playerAnswers, "Resposta do jogador cadastrada com sucesso.") :
                ApiNotFound("Erro ao tentar cadastrar resposta do jogador.");
        }


        /// <summary>
        /// Updates a player response.
        /// </summary>
        /// <param name="playerAnswers"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update([FromBody] PlayerAnswers playerAnswers)
        {
            return _service.Update(playerAnswers) ?
                ApiOk(playerAnswers, "Resposta do jogador atualizada com sucesso.") :
                ApiNotFound("Erro ao tentar atualizar resposta do jogador.");
        }


        /// <summary>
        /// Delete a player response.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int? id) =>
            _service.Delete(id) ?
            ApiOk("Resposta do jogador excluída com sucesso.") :
            ApiNotFound("Erro ao excluir resposta do jogador.");
    }
}
