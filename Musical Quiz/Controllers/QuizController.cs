﻿using Microsoft.AspNetCore.Http;
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
    public class QuizController : APIBaseController
    {
        IQuizService _service;

        public QuizController(IQuizService service)
        {
            _service = service;
        }


        /// <summary>
        /// Ruturs a list of all quiz themes.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public IActionResult Index() => ApiOk(_service.All());


        /// <summary>
        /// Returns a quiz theme fetched by id.
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
            if (id <= 0 || id > _service.QuizList())
                return ApiNotFound("Não encontramos este tema em nosso banco de dados.");
            else return ApiOk(_service.Get(id));
        }


        /// <summary>
        /// Creates a new quiz theme.
        /// </summary>
        /// <param name="quiz"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]        
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] Quiz quiz)
        {
            return _service.Create(quiz) ?
                ApiOk(quiz, "Tema cadastrado com sucesso.") :
                ApiNotFound("Erro ao tentar cadastrar este tema.");
        }


        /// <summary>
        /// Updates a quiz theme.
        /// </summary>
        /// <param name="quiz"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] Quiz quiz)
        {
            return _service.Update(quiz) ?
                ApiOk(quiz, "Tema atualizado com sucesso.") :
                ApiNotFound("Erro ao tentar atualizar este tema.");
        }


        /// <summary>
        /// Delete a quiz theme.
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
            ApiOk("Tema excluído com sucesso.") :
            ApiNotFound("Erro ao tentar excluir este tema.");
    }
}
