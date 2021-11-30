using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Musical_Quiz.Models;
using System;
using System.Linq;

namespace Musical_Quiz.Data
{
    public static class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(
                serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                if (!context.Quiz.Any())
                {
                    context.Quiz.Add(new Quiz { Theme = "Rock" });
                    context.Quiz.Add(new Quiz { Theme = "Samba" });
                    context.Quiz.Add(new Quiz { Theme = "Sertanejo" });                    
                }

                if (!context.Question.Any())
                {
                    context.Question.Add(new Question { Quest = "Qual a melhor banda de todos os tempos da última semana?" });
                    context.Question.Add(new Question { Quest = "Complete a música: Diga aonde você vai, que eu vou:" });
                    context.Question.Add(new Question { Quest = "Qual famosa dupla sertaneja foi tema de filme e é conhecida como os 2 filhos de Francisco?" });
                }

                if (!context.Option.Any())
                {
                    context.Option.Add(new Option { Alternative = "Titãs", IsCorrect = true });
                    context.Option.Add(new Option { Alternative = "que eu vou varrendo.", IsCorrect = true });
                    context.Option.Add(new Option { Alternative = "Zezé de Camargo e Luciano", IsCorrect = true });
                }

                context.SaveChanges();
            }
        }
    }
}
