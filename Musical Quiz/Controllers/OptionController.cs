using Microsoft.AspNetCore.Mvc;
using Musical_Quiz.Models;
using Musical_Quiz.Services;

namespace Musical_Quiz.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OptionController : APIBaseController
    {
        IOptionService _service;

        public OptionController(IOptionService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index() => ApiOk(_service.All());

        [HttpGet]
        [Route("{id}")]        
        public IActionResult Index(int? id)
        {
            if (id <= 0 || id > _service.OptionList())
                return ApiNotFound("Não encontramos esta alternativa em nosso banco de dados.");
            else return ApiOk(_service.Get(id));
        }



        [HttpPost]
        public IActionResult Create([FromBody] Option option)
        {
            return _service.Create(option) ?
                ApiOk(option, "Alternativa cadastrada com sucesso.") :
                ApiNotFound("Erro ao tentar cadastrar alternativa.");
        }

        [HttpPut]
        public IActionResult Update([FromBody] Option option)
        {
            return _service.Update(option) ?
                ApiOk(option, "Alternativa atualizada com sucesso.") :
                ApiNotFound("Erro ao tentar atualizar alternativa.");
        }

        [HttpDelete]        
        [Route("{id}")]
        public IActionResult Delete(int? id) =>
            _service.Delete(id) ?
            ApiOk("Alternativa excluída com sucesso.") :
            ApiNotFound("Erro ao excluir alternativa.");

    }
}
