using Microsoft.EntityFrameworkCore;

namespace IntegralService146.Models
{
    public class QuestionContext : DbContext
    {
        public QuestionContext(DbContextOptions<QuestionContext> options) : base(options) { }

        public DbSet<Question> Questions { get; set; }
    }
}


/* 
  public QuestionContext(DbContextOptions<QuestionContext> dbContextOptions) : base(dbContextOptions) { 
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if(databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
 */