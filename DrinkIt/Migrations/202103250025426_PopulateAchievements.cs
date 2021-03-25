namespace DrinkIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAchievements : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Achievements (Name) VALUES ('1 day');");
            Sql("INSERT INTO Achievements (Name) VALUES ('7 days');");
            Sql("INSERT INTO Achievements (Name) VALUES ('30 days');");
            Sql("INSERT INTO Achievements (Name) VALUES ('90 days');");
            Sql("INSERT INTO Achievements (Name) VALUES ('180 days');");
            Sql("INSERT INTO Achievements (Name) VALUES ('365 days');");
            Sql("INSERT INTO Achievements (Name) VALUES ('Invite Friend');");
        }
        
        public override void Down()
        {
        }
    }
}
