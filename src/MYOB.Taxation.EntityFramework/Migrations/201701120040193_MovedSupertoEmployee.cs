namespace MYOB.Taxation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovedSupertoEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "PaymentStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "SuperRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.TaxRates", "TaxLevel_Super");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TaxRates", "TaxLevel_Super", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Employees", "SuperRate");
            DropColumn("dbo.Employees", "PaymentStartDate");
        }
    }
}
