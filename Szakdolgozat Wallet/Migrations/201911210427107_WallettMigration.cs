namespace Szakdolgozat_Wallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WallettMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategória",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Kategoria_Nev = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Kölcségvetés",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ev = c.String(nullable: false, maxLength: 5, storeType: "nvarchar"),
                        Honap = c.String(nullable: false, maxLength: 2, storeType: "nvarchar"),
                        Havi_keret = c.Int(nullable: false),
                        Felhasznalt_keret = c.Int(nullable: false),
                        Megtakaritott_penz = c.Int(nullable: false),
                        Atlepett_keret = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Tétel",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Tetel_Neve = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                    Vasarlas_Ideje = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                    Menyiseg = c.Int(nullable: false),
                    Erteke = c.Int(nullable: false),
                    Vasarlas_Helye = c.String(maxLength: 50, storeType: "nvarchar"),
                    Kategoria_ID_ID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kategória", t => t.Kategoria_ID_ID, cascadeDelete: true);
                //.Index(t => t.Kategoria_ID_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tétel", "Kategoria_ID_ID", "dbo.Kategória");
            //DropIndex("dbo.Tétel", new[] { "Kategoria_ID_ID" });
            DropTable("dbo.Tétel");
            DropTable("dbo.Kölcségvetés");
            DropTable("dbo.Kategória");
        }
    }
}
