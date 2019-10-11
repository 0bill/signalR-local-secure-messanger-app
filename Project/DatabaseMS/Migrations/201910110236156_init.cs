namespace DatabaseMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conversations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Time = c.DateTime(nullable: false),
                        AuthorId = c.String(),
                        Conversation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Conversations", t => t.Conversation_Id)
                .Index(t => t.Conversation_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        ConnectionId = c.String(),
                        Token = c.String(),
                        Conversation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Conversations", t => t.Conversation_Id)
                .Index(t => t.Conversation_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Conversation_Id", "dbo.Conversations");
            DropForeignKey("dbo.Messages", "Conversation_Id", "dbo.Conversations");
            DropIndex("dbo.Users", new[] { "Conversation_Id" });
            DropIndex("dbo.Messages", new[] { "Conversation_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Messages");
            DropTable("dbo.Conversations");
        }
    }
}
