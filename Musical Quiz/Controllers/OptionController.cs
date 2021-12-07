using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Musical_Quiz.Models;
using Musical_Quiz.Services;
using System.Net.Mime;

namespace Musical_Quiz.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class OptionController : APIBaseController
    {
        IOptionService _service;

        public OptionController(IOptionService service)
        {
            _service = service;
        }

        /// <summary>
        /// Returns a list of all quiz options
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Index() => ApiOk(_service.All());


        /// <summary>
        /// Returns an option fetched by id.
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
            if (id <= 0 || id > _service.OptionList())
                return ApiNotFound("Não encontramos esta alternativa em nosso banco de dados.");
            else return ApiOk(_service.Get(id));
        }


        /// <summary>
        /// Creates a new quiz option.
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] Option option)
        {
            return _service.Create(option) ?
                ApiOk(option, "Alternativa cadastrada com sucesso.") :
                ApiNotFound("Erro ao tentar cadastrar alternativa.");
        }


        /// <summary>
        /// Updates a quiz option.
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] Option option)
        {
            return _service.Update(option) ?
                ApiOk(option, "Alternativa atualizada com sucesso.") :
                ApiNotFound("Erro ao tentar atualizar alternativa.");
        }


        /// <summary>
        /// Delete a quiz option.
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
            ApiOk("Alternativa excluída com sucesso.") :
            ApiNotFound("Erro ao excluir alternativa.");

    }
}
