using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Musical_Quiz.Models;

namespace Musical_Quiz.Data
{
    public class Context : IdentityDbContext
    {
        public Context(DbContextOptions<Context> options) : base (options) { }

        public DbSet<Player> Player { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Option> Option { get; set; }
        public DbSet<PlayerAnswers> PlayerAnswers { get; set; }
    }
}
