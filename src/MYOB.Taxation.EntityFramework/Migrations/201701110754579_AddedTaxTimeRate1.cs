namespace MYOB.Taxation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTaxTimeRate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaxRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SalaryBand = c.String(),
                        TaxLevel_MinLevel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxLevel_MaxLevel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxLevel_BaseTaxRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxLevel_ExtraTaxRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxLevel_Super = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxTimeRate_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TaxTimeRates", t => t.TaxTimeRate_Id)
                .Index(t => t.TaxTimeRate_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaxRates", "TaxTimeRate_Id", "dbo.TaxTimeRates");
            DropIndex("dbo.TaxRates", new[] { "TaxTimeRate_Id" });
            DropTable("dbo.TaxRates");
        }
    }
}
