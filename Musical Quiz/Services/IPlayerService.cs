using Musical_Quiz.Models;
using System.Collections.Generic;

namespace Musical_Quiz.Services
{
    public interface IPlayerService
    {
        List<Player> All();
        Player Get(int? id);
        bool Create(Player player);
        bool Update(Player player);
        bool Delete(int? id);
        int PlayerList();
    }
}
