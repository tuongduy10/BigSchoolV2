namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CATEGORY (Name) VALUES ('Development')");
            Sql("INSERT INTO CATEGORY (Name) VALUES ('Business')");
            Sql("INSERT INTO CATEGORY (Name) VALUES ('Marketing')");
        }
        
        public override void Down()
        {
        }
    }
}
