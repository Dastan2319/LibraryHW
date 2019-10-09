namespace DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGanreForBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Ganre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Ganre");
        }
    }
}
