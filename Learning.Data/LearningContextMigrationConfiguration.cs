using System.Data.Entity.Migrations;

namespace Learning.Data
{
    public class LearningContextMigrationConfiguration : DbMigrationsConfiguration<LearningContext>
    {
        public LearningContextMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LearningContext context)
        {
            new LearningDataSeeder(context).Seed();
        }
    }
}
