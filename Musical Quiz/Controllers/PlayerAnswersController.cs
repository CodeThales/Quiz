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

        [HttpGet]
        public IActionResult Index() => ApiOk(_service.All());

        [HttpGet]
        [Route("{id}")]
        public IActionResult Index(int? id)
        {
            if (id <= 0 || id > _service.PlayerAnswersList())
                return ApiNotFound("Não encontramos esta resposta em nosso banco de dados.");
            else return ApiOk(_service.Get(id));
        }



        [HttpPost]
        public IActionResult Create([FromBody] PlayerAnswers playerAnswers)
        {
            return _service.Create(playerAnswers) ?
                ApiOk(playerAnswers, "Resposta do jogador cadastrada com sucesso.") :
                ApiNotFound("Erro ao tentar cadastrar resposta do jogador.");
        }

        [HttpPut]
        public IActionResult Update([FromBody] PlayerAnswers playerAnswers)
        {
            return _service.Update(playerAnswers) ?
                ApiOk(playerAnswers, "Resposta do jogador atualizada com sucesso.") :
                ApiNotFound("Erro ao tentar atualizar resposta do jogador.");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int? id) =>
            _service.Delete(id) ?
            ApiOk("Resposta do jogador excluída com sucesso.") :
            ApiNotFound("Erro ao excluir resposta do jogador.");
    }
}
