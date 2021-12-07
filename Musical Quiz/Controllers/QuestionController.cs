using Microsoft.AspNetCore.Mvc;
using Musical_Quiz.Models;
using Musical_Quiz.Services;

namespace Musical_Quiz.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : APIBaseController
    {
        IQuestionService _service;

        public QuestionController(IQuestionService service)
        {
            _service = service;
        }


        /// <summary>
        /// Returns a list of all quiz questions.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index() => ApiOk(_service.All());


        /// <summary>
        /// Returns a quiz question fetched by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Index(int? id)
        {
            if (id <= 0 || id > _service.QuestionList())
                return ApiNotFound("Não encontramos esta pergunta em nosso banco de dados.");
            else return ApiOk(_service.Get(id));
        }


        /// <summary>
        /// Creates a quiz question.
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] Question question)
        {
            return _service.Create(question) ?
                ApiOk(question, "Pergunta cadastrado com sucesso.") :
                ApiNotFound("Erro ao tentar cadastrar pergunta.");
        }


        /// <summary>
        /// Updates a quiz question.
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update([FromBody] Question question)
        {
            return _service.Update(question) ?
                ApiOk(question, "Pergunta atualizada com sucesso.") :
                ApiNotFound("Erro ao tentar atualizar pergunta.");
        }


        /// <summary>
        /// Delete a quiz question.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int? id) =>
            _service.Delete(id) ?
            ApiOk("Pergunta excluída com sucesso.") :
            ApiNotFound("Erro ao excluir pergunta.");
    }
}
