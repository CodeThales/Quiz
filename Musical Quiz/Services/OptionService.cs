using Musical_Quiz.Data;
using Musical_Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Musical_Quiz.Services
{
    public class OptionService : IOptionService
    {
        Context _context;
        public OptionService(Context context)
        {
            _context = context;
        }

        public List<Option> All()
        {            
            if (!_context.Option.Any())
                throw new Exception("Não encontramos opções cadastradas em nosso banco de dados.");
            return _context.Option.ToList();           
        }

        public Option Get(int? id)
        {
            try
            {
                return _context.Option.FirstOrDefault(o => o.Id == id);
            }
            catch
            {
                throw new Exception("Opção não encontrada em nosso banco de dados.");
            }
        }

        public bool Create(Option option)
        {
            try
            {
                _context.Add(option);
                _context.SaveChanges();
                return true;
            }
            catch
            {                
                return false;
            }            
        }

        public bool Update(Option option)
        {
            try
            {
                if (!_context.Option.Any(o => o.Id == option.Id))
                    throw new Exception("Não encontramos esta opção em nosso banco de dados.");

                _context.Update(option);
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
                if (!_context.Option.Any(o => o.Id == id))
                    throw new Exception("Não encontramos esta opção em nosso banco de dados.");

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
