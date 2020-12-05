namespace PrismApp1.Persistence.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FieldMods : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Domain.Cat", "FieldInt", c => c.Int());
            AlterColumn("Domain.Cat", "FieldDouble", c => c.Double());
            AlterColumn("Domain.Cat", "FieldSingle", c => c.Single());
            AlterColumn("Domain.Cat", "FieldDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("Domain.Cat", "FieldDate", c => c.DateTime(nullable: false));
            AlterColumn("Domain.Cat", "FieldSingle", c => c.Single(nullable: false));
            AlterColumn("Domain.Cat", "FieldDouble", c => c.Double(nullable: false));
            AlterColumn("Domain.Cat", "FieldInt", c => c.Int(nullable: false));
        }
    }
}
