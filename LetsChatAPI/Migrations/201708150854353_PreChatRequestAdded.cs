namespace LetsChatAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PreChatRequestAdded : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ChatRequests", newName: "PreChatRequests");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.PreChatRequests", newName: "ChatRequests");
        }
    }
}
