using Musical_Quiz.Models;
using System.Collections.Generic;

namespace Musical_Quiz.Services
{
    public interface IQuestionService
    {
        List<Question> All();
        Question Get(int? id);
        bool Create(Question question);
        bool Update(Question question);
        bool Delete(int? id);

    }
}
