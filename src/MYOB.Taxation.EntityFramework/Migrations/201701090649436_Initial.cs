namespace MYOB.Taxation.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        GrossIncome = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TenantId = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Employee_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payslips",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Name = c.String(),
                        PayPeriod = c.String(),
                        GrossIncome = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IncomeTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetIncome = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Super = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmployeeId = c.Long(),
                        TenantId = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Payslip_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payslips", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Payslips", new[] { "EmployeeId" });
            DropTable("dbo.Payslips",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Payslip_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Employees",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Employee_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
