// <auto-generated />
namespace Store.Domain.DataContexts.StoreMigrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.0.2-21211")]
    public sealed partial class FirstName : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(FirstName));
        
        string IMigrationMetadata.Id
        {
            get { return "201312301313522_FirstName"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
