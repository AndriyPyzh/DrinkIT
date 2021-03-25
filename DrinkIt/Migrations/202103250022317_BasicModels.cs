namespace DrinkIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WaterNorm = c.Int(nullable: false),
                        WakeUpTime = c.Time(nullable: false, precision: 7),
                        SleepTime = c.Time(nullable: false, precision: 7),
                        PeriodOfNotification = c.Time(nullable: false, precision: 7),
                        Age = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        Goal = c.Double(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Data_Id = c.Int(),
                        Gender_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Data_Id)
                .ForeignKey("dbo.Genders", t => t.Gender_Id)
                .Index(t => t.Data_Id)
                .Index(t => t.Gender_Id);
            
            CreateTable(
                "dbo.AccountAchievements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Achievement_Id = c.Int(),
                        Account_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Achievements", t => t.Achievement_Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .Index(t => t.Achievement_Id)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.Achievements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DrunkDrinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Volume = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Beverage_Id = c.Int(),
                        Account_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Beverages", t => t.Beverage_Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .Index(t => t.Beverage_Id)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.Beverages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Account_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Accounts", "Gender_Id", "dbo.Genders");
            DropForeignKey("dbo.DrunkDrinks", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.DrunkDrinks", "Beverage_Id", "dbo.Beverages");
            DropForeignKey("dbo.Accounts", "Data_Id", "dbo.Accounts");
            DropForeignKey("dbo.AccountAchievements", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.AccountAchievements", "Achievement_Id", "dbo.Achievements");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Account_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.DrunkDrinks", new[] { "Account_Id" });
            DropIndex("dbo.DrunkDrinks", new[] { "Beverage_Id" });
            DropIndex("dbo.AccountAchievements", new[] { "Account_Id" });
            DropIndex("dbo.AccountAchievements", new[] { "Achievement_Id" });
            DropIndex("dbo.Accounts", new[] { "Gender_Id" });
            DropIndex("dbo.Accounts", new[] { "Data_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Genders");
            DropTable("dbo.Beverages");
            DropTable("dbo.DrunkDrinks");
            DropTable("dbo.Achievements");
            DropTable("dbo.AccountAchievements");
            DropTable("dbo.Accounts");
        }
    }
}
