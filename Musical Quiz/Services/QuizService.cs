using Musical_Quiz.Data;
using Musical_Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Musical_Quiz.Services
{
    public class QuizService : IQuizService
    {
        Context _context;

        public QuizService(Context context)
        {
            _context = context;
        }
        public List<Quiz> All()
        {
            if (!_context.Quiz.Any())
                throw new Exception("Não encontramos temas cadastrados em nosso banco de dados.");
            return _context.Quiz.ToList();
        }

        public Quiz Get(int? id)
        {
            try
            {
                return _context.Quiz.FirstOrDefault(q => q.Id == id);
            }
            catch
            {
                throw new Exception("Tema não encontrado em nosso banco de dados.");
            }
        }

        public bool Create(Quiz quiz)
        {
            try
            {
                _context.Add(quiz);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Quiz quiz)
        {
            try
            {
                if (!_context.Quiz.Any(q => q.Id == quiz.Id))
                    throw new Exception("Não encontramos este tema em nosso banco de dados.");

                _context.Update(quiz);
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
                if (!_context.Quiz.Any(q => q.Id == id))
                    throw new Exception("Não encontramos este tema em nosso banco de dados.");

                _context.Remove(this.Get(id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int QuizList()
        {
            return _context.Quiz.Count();
        }
    }
}
