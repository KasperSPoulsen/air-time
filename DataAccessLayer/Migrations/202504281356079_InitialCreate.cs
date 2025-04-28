namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bil",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KontaktPerson_Id = c.Int(),
                        Konkurrence_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KontaktPerson", t => t.KontaktPerson_Id)
                .ForeignKey("dbo.Konkurrence", t => t.Konkurrence_Id)
                .Index(t => t.KontaktPerson_Id)
                .Index(t => t.Konkurrence_Id);
            
            CreateTable(
                "dbo.KontaktPerson",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Navn = c.String(),
                        TlfNr = c.String(),
                        Mail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Springer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Navn = c.String(),
                        Foedselsdato = c.DateTime(nullable: false),
                        TraeningsMaal = c.String(),
                        KontaktPerson_Id = c.Int(),
                        Bil_Id = c.Int(),
                        Konkurrence_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KontaktPerson", t => t.KontaktPerson_Id)
                .ForeignKey("dbo.Bil", t => t.Bil_Id)
                .ForeignKey("dbo.Konkurrence", t => t.Konkurrence_Id)
                .Index(t => t.KontaktPerson_Id)
                .Index(t => t.Bil_Id)
                .Index(t => t.Konkurrence_Id);
            
            CreateTable(
                "dbo.Hold",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoldNavn = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Traening",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dato = c.DateTime(nullable: false),
                        Hold_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hold", t => t.Hold_Id)
                .Index(t => t.Hold_Id);
            
            CreateTable(
                "dbo.Fremmoederegistrering",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MoedeStatus = c.Int(nullable: false),
                        Springer_Id = c.Int(),
                        Traening_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Springer", t => t.Springer_Id)
                .ForeignKey("dbo.Traening", t => t.Traening_Id)
                .Index(t => t.Springer_Id)
                .Index(t => t.Traening_Id);
            
            CreateTable(
                "dbo.Konkurrence",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adresse = c.String(),
                        Navn = c.String(),
                        Dato = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HoldSpringer",
                c => new
                    {
                        Hold_Id = c.Int(nullable: false),
                        Springer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Hold_Id, t.Springer_Id })
                .ForeignKey("dbo.Hold", t => t.Hold_Id, cascadeDelete: true)
                .ForeignKey("dbo.Springer", t => t.Springer_Id, cascadeDelete: true)
                .Index(t => t.Hold_Id)
                .Index(t => t.Springer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Springer", "Konkurrence_Id", "dbo.Konkurrence");
            DropForeignKey("dbo.Bil", "Konkurrence_Id", "dbo.Konkurrence");
            DropForeignKey("dbo.Springer", "Bil_Id", "dbo.Bil");
            DropForeignKey("dbo.Springer", "KontaktPerson_Id", "dbo.KontaktPerson");
            DropForeignKey("dbo.Traening", "Hold_Id", "dbo.Hold");
            DropForeignKey("dbo.Fremmoederegistrering", "Traening_Id", "dbo.Traening");
            DropForeignKey("dbo.Fremmoederegistrering", "Springer_Id", "dbo.Springer");
            DropForeignKey("dbo.HoldSpringer", "Springer_Id", "dbo.Springer");
            DropForeignKey("dbo.HoldSpringer", "Hold_Id", "dbo.Hold");
            DropForeignKey("dbo.Bil", "KontaktPerson_Id", "dbo.KontaktPerson");
            DropIndex("dbo.HoldSpringer", new[] { "Springer_Id" });
            DropIndex("dbo.HoldSpringer", new[] { "Hold_Id" });
            DropIndex("dbo.Fremmoederegistrering", new[] { "Traening_Id" });
            DropIndex("dbo.Fremmoederegistrering", new[] { "Springer_Id" });
            DropIndex("dbo.Traening", new[] { "Hold_Id" });
            DropIndex("dbo.Springer", new[] { "Konkurrence_Id" });
            DropIndex("dbo.Springer", new[] { "Bil_Id" });
            DropIndex("dbo.Springer", new[] { "KontaktPerson_Id" });
            DropIndex("dbo.Bil", new[] { "Konkurrence_Id" });
            DropIndex("dbo.Bil", new[] { "KontaktPerson_Id" });
            DropTable("dbo.HoldSpringer");
            DropTable("dbo.Konkurrence");
            DropTable("dbo.Fremmoederegistrering");
            DropTable("dbo.Traening");
            DropTable("dbo.Hold");
            DropTable("dbo.Springer");
            DropTable("dbo.KontaktPerson");
            DropTable("dbo.Bil");
        }
    }
}
