using Musical_Quiz.Models;
using System.Collections.Generic;

namespace Musical_Quiz.Services
{
    public interface IQuizService
    {
        List<Quiz> All();
        Quiz Get(int? id);
        bool Create(Quiz quiz);
        bool Update(Quiz quiz);
        bool Delete(int? id);

    }
}
