namespace MYOB.Taxation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTaxRate3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TaxRates", "TaxTimeRate_Id", "dbo.TaxTimeRates");
            DropIndex("dbo.TaxRates", new[] { "TaxTimeRate_Id" });
            RenameColumn(table: "dbo.TaxRates", name: "TaxTimeRate_Id", newName: "TaxTimeRateId");
            DropPrimaryKey("dbo.TaxRates");
            DropPrimaryKey("dbo.TaxTimeRates");
            AlterColumn("dbo.TaxRates", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.TaxRates", "TaxTimeRateId", c => c.Long());
            AlterColumn("dbo.TaxTimeRates", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.TaxRates", "Id");
            AddPrimaryKey("dbo.TaxTimeRates", "Id");
            CreateIndex("dbo.TaxRates", "TaxTimeRateId");
            AddForeignKey("dbo.TaxRates", "TaxTimeRateId", "dbo.TaxTimeRates", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaxRates", "TaxTimeRateId", "dbo.TaxTimeRates");
            DropIndex("dbo.TaxRates", new[] { "TaxTimeRateId" });
            DropPrimaryKey("dbo.TaxTimeRates");
            DropPrimaryKey("dbo.TaxRates");
            AlterColumn("dbo.TaxTimeRates", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.TaxRates", "TaxTimeRateId", c => c.Int());
            AlterColumn("dbo.TaxRates", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.TaxTimeRates", "Id");
            AddPrimaryKey("dbo.TaxRates", "Id");
            RenameColumn(table: "dbo.TaxRates", name: "TaxTimeRateId", newName: "TaxTimeRate_Id");
            CreateIndex("dbo.TaxRates", "TaxTimeRate_Id");
            AddForeignKey("dbo.TaxRates", "TaxTimeRate_Id", "dbo.TaxTimeRates", "Id");
        }
    }
}
