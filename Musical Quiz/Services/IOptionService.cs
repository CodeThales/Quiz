using Musical_Quiz.Models;
using System.Collections.Generic;

namespace Musical_Quiz.Services
{
    public interface IOptionService
    {
        List<Option> All();
        Option Get(int? id);
        bool Create(Option option);
        bool Update(Option option);
        bool Delete(int? id);

    }
}
