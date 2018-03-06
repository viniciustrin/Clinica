namespace Clinica.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CriacaoTabelaEspecialidades : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Especialidades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO ESPECIALIDADES (NOME) VALUES ('Pediatria' )");
            Sql("INSERT INTO ESPECIALIDADES (NOME) VALUES ('Ginecologia' )");
            Sql("INSERT INTO ESPECIALIDADES (NOME) VALUES ('Cardiologia' )");
            Sql("INSERT INTO ESPECIALIDADES (NOME) VALUES ('Geral' )");
        }
        
        public override void Down()
        {
            DropTable("dbo.Especialidades");
        }
    }
}
