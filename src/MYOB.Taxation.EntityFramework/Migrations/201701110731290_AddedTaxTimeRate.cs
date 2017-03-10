namespace MYOB.Taxation.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTaxTimeRate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaxTimeRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        TenantId = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_TaxTimeRate_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.TaxRates",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_TaxRate_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TaxRates",
                c => new
                    {
                        SalaryBand = c.String(nullable: false, maxLength: 128),
                        StartDate = c.DateTime(nullable: false),
                        TaxLevel_MinLevel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxLevel_MaxLevel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxLevel_BaseTaxRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxLevel_ExtraTaxRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxLevel_Super = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TenantId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_TaxRate_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.SalaryBand);
            
            DropTable("dbo.TaxTimeRates",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_TaxTimeRate_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
