namespace TestPrismApp1.Persistence.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSeed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FieldString = c.String(maxLength: 50),
                        FieldInt = c.Int(nullable: false),
                        FieldDouble = c.Double(nullable: false),
                        FieldSingle = c.Single(nullable: false),
                        FieldDate = c.DateTime(nullable: false),
                        FieldDate2 = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateModified = c.DateTime(),
                        DateCreated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dog");
        }
    }
}
