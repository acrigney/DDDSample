namespace MYOB.Taxation.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class TaxTimeRateIsForAllTenants : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
                "dbo.TaxTimeRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_TaxTimeRate_MustHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            DropColumn("dbo.TaxTimeRates", "TenantId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TaxTimeRates", "TenantId", c => c.Int(nullable: false));
            AlterTableAnnotations(
                "dbo.TaxTimeRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_TaxTimeRate_MustHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
        }
    }
}
