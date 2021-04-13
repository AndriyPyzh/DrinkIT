namespace DrinkIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedFieldsFromAccount : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "Data_Id", "dbo.Accounts");
            DropIndex("dbo.Accounts", new[] { "Data_Id" });
            DropColumn("dbo.Accounts", "DateOfBirth");
            DropColumn("dbo.Accounts", "Data_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "Data_Id", c => c.Int());
            AddColumn("dbo.Accounts", "DateOfBirth", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Accounts", "Data_Id");
            AddForeignKey("dbo.Accounts", "Data_Id", "dbo.Accounts", "Id");
        }
    }
}
