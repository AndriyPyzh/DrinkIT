namespace DrinkIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenders : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genders (Id, Name) VALUES (1, 'male');");
            Sql("INSERT INTO Genders (Id, Name) VALUES (2, 'female');");
            Sql("INSERT INTO Genders (Id, Name) VALUES (3, 'mixed');");
        }
        
        public override void Down()
        {
        }
    }
}
