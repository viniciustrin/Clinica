namespace Clinica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoTabelas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agendamentoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Medico_ID = c.Int(),
                        Paciente_Id = c.Int(),
                        Usuario_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Medicos", t => t.Medico_ID)
                .ForeignKey("dbo.Pacientes", t => t.Paciente_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Usuario_Id)
                .Index(t => t.Medico_ID)
                .Index(t => t.Paciente_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Especialidade = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Endereco = c.String(),
                        RG = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agendamentoes", "Usuario_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Agendamentoes", "Paciente_Id", "dbo.Pacientes");
            DropForeignKey("dbo.Agendamentoes", "Medico_ID", "dbo.Medicos");
            DropIndex("dbo.Agendamentoes", new[] { "Usuario_Id" });
            DropIndex("dbo.Agendamentoes", new[] { "Paciente_Id" });
            DropIndex("dbo.Agendamentoes", new[] { "Medico_ID" });
            DropTable("dbo.Pacientes");
            DropTable("dbo.Medicos");
            DropTable("dbo.Agendamentoes");
        }
    }
}
