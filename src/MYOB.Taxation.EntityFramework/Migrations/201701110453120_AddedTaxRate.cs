namespace MYOB.Taxation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTaxRate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaxRates",
                c => new
                    {
                        SalaryBand = c.String(nullable: false, maxLength: 128),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SalaryBand);
            
            AddColumn("dbo.Employees", "SalaryBand", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "SalaryBand");
            DropTable("dbo.TaxRates");
        }
    }
}
