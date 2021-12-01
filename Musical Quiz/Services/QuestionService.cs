using Musical_Quiz.Data;
using Musical_Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Musical_Quiz.Services
{
    public class QuestionService : IQuestionService
    {
        Context _context;

        public QuestionService(Context context)
        {
            _context = context;
        }

        public List<Question> All()
        {
            if (!_context.Question.Any())
                throw new Exception("Não encontramos perguntas cadastradas em nosso banco de dados.");
            return _context.Question.ToList();
        }

        public Question Get(int? id)
        {
            try
            {
                return _context.Question.FirstOrDefault(q => q.Id == id);
            }
            catch
            {
                throw new Exception("Pergunta não encontrada em nosso banco de dados.");
            }
        }

        public bool Create(Question question)
        {
            try
            {
                _context.Add(question);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Question question)
        {
            try
            {
                if (!_context.Question.Any(q => q.Id == question.Id))
                    throw new Exception("Não encontramos esta pergunta em nosso banco de dados.");

                _context.Update(question);
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
                if (!_context.Question.Any(q => q.Id == id))
                    throw new Exception("Não encontramos esta pergunta em nosso banco de dados.");

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
