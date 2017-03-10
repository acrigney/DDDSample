namespace MYOB.Taxation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTaxLevel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaxRates", "TaxLevel_MinLevel", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TaxRates", "TaxLevel_MaxLevel", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TaxRates", "TaxLevel_BaseTaxRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TaxRates", "TaxLevel_ExtraTaxRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TaxRates", "TaxLevel_Super", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TaxRates", "TaxLevel_Super");
            DropColumn("dbo.TaxRates", "TaxLevel_ExtraTaxRate");
            DropColumn("dbo.TaxRates", "TaxLevel_BaseTaxRate");
            DropColumn("dbo.TaxRates", "TaxLevel_MaxLevel");
            DropColumn("dbo.TaxRates", "TaxLevel_MinLevel");
        }
    }
}
