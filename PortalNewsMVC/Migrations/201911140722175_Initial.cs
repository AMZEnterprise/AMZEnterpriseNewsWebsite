namespace PortalNewsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoryes",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryTitle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsID = c.Int(nullable: false, identity: true),
                        NewsCategoryID = c.Int(),
                        SubCategoryID = c.Int(),
                        NewsTitle = c.String(nullable: false),
                        NewsDescription = c.String(nullable: false),
                        NewsDate = c.DateTime(nullable: false),
                        NewsImage = c.String(maxLength: 150, unicode: false),
                        LogUser = c.Int(),
                        LogDate = c.DateTime(),
                        Categorye_CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.NewsID)
                .ForeignKey("dbo.Categoryes", t => t.Categorye_CategoryID)
                .ForeignKey("dbo.SubCategoryes", t => t.SubCategoryID)
                .ForeignKey("dbo.Users", t => t.LogUser)
                .Index(t => t.SubCategoryID)
                .Index(t => t.LogUser)
                .Index(t => t.Categorye_CategoryID);
            
            CreateTable(
                "dbo.Galleryes",
                c => new
                    {
                        GalleryID = c.Int(nullable: false, identity: true),
                        NewsID = c.Int(nullable: false),
                        Image = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.GalleryID)
                .ForeignKey("dbo.News", t => t.NewsID)
                .Index(t => t.NewsID);
            
            CreateTable(
                "dbo.SubCategoryes",
                c => new
                    {
                        SubCategoryID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        SubCategoryName = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.SubCategoryID)
                .ForeignKey("dbo.Categoryes", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagID = c.Int(nullable: false, identity: true),
                        NewsID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TagID)
                .ForeignKey("dbo.News", t => t.NewsID)
                .Index(t => t.NewsID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        Username = c.String(nullable: false, maxLength: 150),
                        Password = c.String(nullable: false, maxLength: 150),
                        Email = c.String(nullable: false, maxLength: 150),
                        FullName = c.String(nullable: false, maxLength: 150),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Roles", t => t.RoleID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false),
                        RoleTitle = c.String(nullable: false, maxLength: 150),
                        RoleName = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Note = c.String(),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewsLatters",
                c => new
                    {
                        NewsLaterID = c.Int(nullable: false),
                        FullName = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.NewsLaterID);
            
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        SiteID = c.Int(nullable: false, identity: true),
                        SiteName = c.String(maxLength: 150),
                        SiteDescription = c.String(maxLength: 250),
                        SiteAbout = c.String(),
                    })
                .PrimaryKey(t => t.SiteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCategoryes", "CategoryID", "dbo.Categoryes");
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.News", "LogUser", "dbo.Users");
            DropForeignKey("dbo.Tags", "NewsID", "dbo.News");
            DropForeignKey("dbo.News", "SubCategoryID", "dbo.SubCategoryes");
            DropForeignKey("dbo.Galleryes", "NewsID", "dbo.News");
            DropForeignKey("dbo.News", "Categorye_CategoryID", "dbo.Categoryes");
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.Tags", new[] { "NewsID" });
            DropIndex("dbo.SubCategoryes", new[] { "CategoryID" });
            DropIndex("dbo.Galleryes", new[] { "NewsID" });
            DropIndex("dbo.News", new[] { "Categorye_CategoryID" });
            DropIndex("dbo.News", new[] { "LogUser" });
            DropIndex("dbo.News", new[] { "SubCategoryID" });
            DropTable("dbo.Sites");
            DropTable("dbo.NewsLatters");
            DropTable("dbo.ContactUs");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Tags");
            DropTable("dbo.SubCategoryes");
            DropTable("dbo.Galleryes");
            DropTable("dbo.News");
            DropTable("dbo.Categoryes");
        }
    }
}
