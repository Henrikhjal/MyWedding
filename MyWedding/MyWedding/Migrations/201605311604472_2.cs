namespace MyWedding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WishlistItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Details = c.String(maxLength: 200),
                        Price = c.Int(),
                        Hyperlink = c.String(maxLength: 300),
                        Quantity = c.Int(nullable: false),
                        Reserved = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WishlistItems");
        }
    }
}
