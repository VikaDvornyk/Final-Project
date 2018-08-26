namespace FinalProjectDTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableQuestions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qn = c.String(),
                        Option1 = c.String(),
                        Option2 = c.String(),
                        Option3 = c.String(),
                        Option4 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.User", "Score", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Score");
            DropTable("dbo.Question");
        }
    }
}
