using Musical_Quiz.Data;
using Musical_Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Musical_Quiz.Services
{
    public class PlayerService : IPlayerService
    {
        Context _context;
        public PlayerService(Context context)
        {
            _context = context;
        }

        public List<Player> All()
        {
            if (!_context.Player.Any())
                throw new Exception("Não encontramos jogadores cadastradas em nosso banco de dados.");
            return _context.Player.ToList();
        }

        public Player Get(int? id)
        {
            try
            {
                return _context.Player.FirstOrDefault(p => p.Id == id);
            }
            catch
            {
                throw new Exception("Jogador não encontrada em nosso banco de dados.");
            }
        }

        public bool Create(Player player)
        {
            try
            {
                _context.Add(player);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Player player)
        {
            try
            {
                if (!_context.Player.Any(p => p.Id == player.Id))
                    throw new Exception("Não encontramos este jogador em nosso banco de dados.");

                _context.Update(player);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int? id)
        {
            try
            {
                if (!_context.Player.Any(p => p.Id == id))
                    throw new Exception("Não encontramos este jogador em nosso banco de dados.");

                _context.Remove(this.Get(id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
