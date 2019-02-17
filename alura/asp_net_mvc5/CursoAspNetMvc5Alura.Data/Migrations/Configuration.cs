namespace CursoAspNetMvc5Alura.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CursoAspNetMvc5AluraContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CursoAspNetMvc5AluraContext context)
        {

        }
    }
}
