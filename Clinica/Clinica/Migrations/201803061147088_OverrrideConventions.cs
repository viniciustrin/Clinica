namespace Clinica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrrideConventions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agendamentoes", "Medico_ID", "dbo.Medicos");
            DropForeignKey("dbo.Agendamentoes", "Paciente_Id", "dbo.Pacientes");
            DropForeignKey("dbo.Agendamentoes", "Usuario_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Agendamentoes", new[] { "Medico_ID" });
            DropIndex("dbo.Agendamentoes", new[] { "Paciente_Id" });
            DropIndex("dbo.Agendamentoes", new[] { "Usuario_Id" });
            AlterColumn("dbo.Agendamentoes", "Medico_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Agendamentoes", "Paciente_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Agendamentoes", "Usuario_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Medicos", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Medicos", "Especialidade", c => c.String(nullable: false));
            AlterColumn("dbo.Pacientes", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Pacientes", "Endereco", c => c.String(nullable: false));
            AlterColumn("dbo.Pacientes", "RG", c => c.String(nullable: false));
            CreateIndex("dbo.Agendamentoes", "Medico_ID");
            CreateIndex("dbo.Agendamentoes", "Paciente_Id");
            CreateIndex("dbo.Agendamentoes", "Usuario_Id");
            AddForeignKey("dbo.Agendamentoes", "Medico_ID", "dbo.Medicos", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Agendamentoes", "Paciente_Id", "dbo.Pacientes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Agendamentoes", "Usuario_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agendamentoes", "Usuario_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Agendamentoes", "Paciente_Id", "dbo.Pacientes");
            DropForeignKey("dbo.Agendamentoes", "Medico_ID", "dbo.Medicos");
            DropIndex("dbo.Agendamentoes", new[] { "Usuario_Id" });
            DropIndex("dbo.Agendamentoes", new[] { "Paciente_Id" });
            DropIndex("dbo.Agendamentoes", new[] { "Medico_ID" });
            AlterColumn("dbo.Pacientes", "RG", c => c.String());
            AlterColumn("dbo.Pacientes", "Endereco", c => c.String());
            AlterColumn("dbo.Pacientes", "Nome", c => c.String());
            AlterColumn("dbo.Medicos", "Especialidade", c => c.String());
            AlterColumn("dbo.Medicos", "Nome", c => c.String());
            AlterColumn("dbo.Agendamentoes", "Usuario_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Agendamentoes", "Paciente_Id", c => c.Int());
            AlterColumn("dbo.Agendamentoes", "Medico_ID", c => c.Int());
            CreateIndex("dbo.Agendamentoes", "Usuario_Id");
            CreateIndex("dbo.Agendamentoes", "Paciente_Id");
            CreateIndex("dbo.Agendamentoes", "Medico_ID");
            AddForeignKey("dbo.Agendamentoes", "Usuario_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Agendamentoes", "Paciente_Id", "dbo.Pacientes", "Id");
            AddForeignKey("dbo.Agendamentoes", "Medico_ID", "dbo.Medicos", "ID");
        }
    }
}
