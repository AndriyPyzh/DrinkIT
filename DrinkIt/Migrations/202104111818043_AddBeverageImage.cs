namespace DrinkIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBeverageImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Beverages", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Beverages", "Image");
        }
    }
}
