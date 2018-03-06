namespace Clinica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefatorandoTabelas : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Agendamentoes", name: "Medico_ID", newName: "MedicoID");
            RenameColumn(table: "dbo.Agendamentoes", name: "Paciente_Id", newName: "PacienteID");
            RenameColumn(table: "dbo.Agendamentoes", name: "Usuario_Id", newName: "UsuarioId");
            RenameIndex(table: "dbo.Agendamentoes", name: "IX_Usuario_Id", newName: "IX_UsuarioId");
            RenameIndex(table: "dbo.Agendamentoes", name: "IX_Paciente_Id", newName: "IX_PacienteID");
            RenameIndex(table: "dbo.Agendamentoes", name: "IX_Medico_ID", newName: "IX_MedicoID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Agendamentoes", name: "IX_MedicoID", newName: "IX_Medico_ID");
            RenameIndex(table: "dbo.Agendamentoes", name: "IX_PacienteID", newName: "IX_Paciente_Id");
            RenameIndex(table: "dbo.Agendamentoes", name: "IX_UsuarioId", newName: "IX_Usuario_Id");
            RenameColumn(table: "dbo.Agendamentoes", name: "UsuarioId", newName: "Usuario_Id");
            RenameColumn(table: "dbo.Agendamentoes", name: "PacienteID", newName: "Paciente_Id");
            RenameColumn(table: "dbo.Agendamentoes", name: "MedicoID", newName: "Medico_ID");
        }
    }
}
