// <auto-generated />
namespace MYOB.Taxation.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class Upgraded_To_V0_9 : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(Upgraded_To_V0_9));
        
        string IMigrationMetadata.Id
        {
            get { return "201604271412090_Upgraded_To_V0_9"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return "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"; }
        }
    }
}
