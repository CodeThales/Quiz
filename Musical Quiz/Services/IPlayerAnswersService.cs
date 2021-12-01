using Musical_Quiz.Models;
using System.Collections.Generic;

namespace Musical_Quiz.Services
{
    public interface IPlayerAnswersService
    {
        List<PlayerAnswers> All();
        PlayerAnswers Get(int? id);
        bool Create(PlayerAnswers playerAnswers);
        bool Update(PlayerAnswers playerAnswers);
        bool Delete(int? id);

    }
}
