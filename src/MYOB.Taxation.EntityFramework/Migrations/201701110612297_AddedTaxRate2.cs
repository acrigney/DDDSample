namespace MYOB.Taxation.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTaxRate2 : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
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
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_TaxRate_MustHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AddColumn("dbo.TaxRates", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.TaxRates", "Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TaxRates", "Id");
            DropColumn("dbo.TaxRates", "TenantId");
            AlterTableAnnotations(
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
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_TaxRate_MustHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
        }
    }
}
