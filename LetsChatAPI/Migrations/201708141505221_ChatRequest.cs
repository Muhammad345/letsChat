namespace LetsChatAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChatRequest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChatRequests",
                c => new
                    {
                        ChatRequestId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        EmailAddress = c.String(maxLength: 300),
                        Reason = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.ChatRequestId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ChatRequests");
        }
    }
}
