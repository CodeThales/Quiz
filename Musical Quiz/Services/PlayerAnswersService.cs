using Musical_Quiz.Data;
using Musical_Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Musical_Quiz.Services
{
    public class PlayerAnswersService : IPlayerAnswersService
    {
        Context _context;

        public PlayerAnswersService(Context context)
        {
            _context = context;
        }

        public List<PlayerAnswers> All()
        {
            if (!_context.PlayerAnswers.Any())
                throw new Exception("Não encontramos respostas do jogador em nosso banco de dados.");
            return _context.PlayerAnswers.ToList();
        }

        public PlayerAnswers Get(int? id)
        {
            try
            {
                return _context.PlayerAnswers.FirstOrDefault(pa => pa.Id == id);
            }
            catch
            {
                throw new Exception("Resposta do jogador não encontrada em nosso banco de dados.");
            }
        }

        public bool Create(PlayerAnswers playerAnswers)
        {
            try
            {
                _context.Add(playerAnswers);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(PlayerAnswers playerAnswers)
        {
            try
            {
                if (!_context.PlayerAnswers.Any(pa => pa.Id == playerAnswers.Id))
                    throw new Exception("Não encontramos esta resposta do jogador em nosso banco de dados.");

                _context.Update(playerAnswers);
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
                if (!_context.PlayerAnswers.Any(pa => pa.Id == id))
                    throw new Exception("Não encontramos esta resposta do jogador em nosso banco de dados.");

                _context.Remove(this.Get(id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int PlayerAnswersList()
        {
            return _context.PlayerAnswers.Count();
        }
    }
}
