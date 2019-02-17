namespace CursoAspNetMvc5Alura.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cliente_Data_Cadastro : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "DataCadastro", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "DataCadastro", c => c.DateTime(nullable: false));
        }
    }
}
