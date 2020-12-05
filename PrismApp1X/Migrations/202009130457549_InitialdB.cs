namespace PrismApp1.Persistence.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialdB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Domain.Cat",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FieldString = c.String(maxLength: 50),
                        FieldInt = c.Int(nullable: false),
                        FieldDouble = c.Double(nullable: false),
                        FieldSingle = c.Single(nullable: false),
                        FieldDate = c.DateTime(nullable: false),
                        DateModified = c.DateTime(),
                        DateCreated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Domain.Cat");
        }
    }
}
