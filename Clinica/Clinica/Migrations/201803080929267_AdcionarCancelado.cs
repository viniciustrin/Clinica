namespace Clinica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdcionarCancelado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agendamentoes", "Cancelado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Medicos", "Deletado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pacientes", "Deletado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pacientes", "Deletado");
            DropColumn("dbo.Medicos", "Deletado");
            DropColumn("dbo.Agendamentoes", "Cancelado");
        }
    }
}
