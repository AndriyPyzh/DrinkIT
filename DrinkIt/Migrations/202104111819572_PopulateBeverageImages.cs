namespace DrinkIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateBeverageImages : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Beverages SET Image='beer.png' WHERE Name='Beer';");
            Sql("UPDATE Beverages SET Image='cocktail.png' WHERE Name='Cocktail';");
            Sql("UPDATE Beverages SET Image='coffee.png' WHERE Name='Coffee';");
            Sql("UPDATE Beverages SET Image='energy_drink.png' WHERE Name='Energy Drink';");
            Sql("UPDATE Beverages SET Image='juice.png' WHERE Name='Juice';");
            Sql("UPDATE Beverages SET Image='milk.png' WHERE Name='Milk';");
            Sql("UPDATE Beverages SET Image='soda.png' WHERE Name='Soda';");
            Sql("UPDATE Beverages SET Image='tea.png' WHERE Name='Tea';");
            Sql("UPDATE Beverages SET Image='wine.png' WHERE Name='Wine';");
            Sql("UPDATE Beverages SET Image='water.png' WHERE Name='Water';");
        }

        public override void Down()
        {
        }
    }
}