using Microsoft.AspNetCore.Mvc;
using Musical_Quiz.API;

namespace Musical_Quiz.Controllers
{
    public abstract class APIBaseController : ControllerBase
    {
        #region PrivateMethods
        APIResponse<T> CustomResponse<T>(T Results, bool Succeed = true, string Message = "") =>
            new APIResponse<T>()
            {
                Results = Results,
                Succeed = Succeed,
                Message = Message
            };

        APIResponse<string> CustomResponse(bool Succeed = true, string Message = "") =>
            new APIResponse<string>()
            {
                Succeed = Succeed,
                Message = Message
            };
        #endregion PrivateMethods

        protected OkObjectResult ApiOk<T>(T Results, string Message = "") =>
          Ok(CustomResponse(Results, true, Message));

        protected OkObjectResult ApiOk(string Message = "") =>
            Ok(CustomResponse(true, Message));

        protected NotFoundObjectResult ApiNotFound(string Message) =>
            NotFound(CustomResponse(false, Message));

        protected BadRequestObjectResult ApiBadRequest<T>(T Results, string Message = "") =>
            BadRequest(CustomResponse(Results, false, Message));
    }
}
