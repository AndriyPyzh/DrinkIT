namespace DrinkIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBeverages : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Beverages (Name) VALUES ('Tea');");
            Sql("INSERT INTO Beverages (Name) VALUES ('Water');");
            Sql("INSERT INTO Beverages (Name) VALUES ('Coffee');");
            Sql("INSERT INTO Beverages (Name) VALUES ('Juice');");
            Sql("INSERT INTO Beverages (Name) VALUES ('Milk');");
        }
        
        public override void Down()
        {
        }
    }
}
