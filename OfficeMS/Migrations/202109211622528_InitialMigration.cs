namespace OfficeMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authorization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Character = c.String(maxLength: 1),
                        Year = c.String(),
                        Office = c.String(),
                        Client_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Client", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Address = c.String(),
                        Mobile = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lawsuit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Year = c.String(),
                        Court = c.String(),
                        Circle = c.String(),
                        Day = c.String(),
                        Cost = c.Double(nullable: false),
                        ClientDescription = c.String(),
                        OpponentName = c.String(),
                        Client_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Client", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.Expense",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Statment = c.String(),
                        Lawsuit_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lawsuit", t => t.Lawsuit_Id)
                .Index(t => t.Lawsuit_Id);
            
            CreateTable(
                "dbo.Income",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Lawsuit_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lawsuit", t => t.Lawsuit_Id)
                .Index(t => t.Lawsuit_Id);
            
            CreateTable(
                "dbo.LawsuitRecord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Decision = c.String(),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Lawsuit_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lawsuit", t => t.Lawsuit_Id)
                .Index(t => t.Lawsuit_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LawsuitRecord", "Lawsuit_Id", "dbo.Lawsuit");
            DropForeignKey("dbo.Income", "Lawsuit_Id", "dbo.Lawsuit");
            DropForeignKey("dbo.Expense", "Lawsuit_Id", "dbo.Lawsuit");
            DropForeignKey("dbo.Lawsuit", "Client_Id", "dbo.Client");
            DropForeignKey("dbo.Authorization", "Client_Id", "dbo.Client");
            DropIndex("dbo.LawsuitRecord", new[] { "Lawsuit_Id" });
            DropIndex("dbo.Income", new[] { "Lawsuit_Id" });
            DropIndex("dbo.Expense", new[] { "Lawsuit_Id" });
            DropIndex("dbo.Lawsuit", new[] { "Client_Id" });
            DropIndex("dbo.Authorization", new[] { "Client_Id" });
            DropTable("dbo.LawsuitRecord");
            DropTable("dbo.Income");
            DropTable("dbo.Expense");
            DropTable("dbo.Lawsuit");
            DropTable("dbo.Client");
            DropTable("dbo.Authorization");
        }
    }
}
